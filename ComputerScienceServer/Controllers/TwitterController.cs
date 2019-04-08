using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using YoutubeNotifyBot.Models;
using YoutubeNotifyBot.Models.Twitter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TweetSharp;

namespace YoutubeNotifyBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwitterController : ControllerBase
    {
	    private readonly WebApiContext _context;

	    public TwitterController(WebApiContext context)
	    {
			//Set the database context
		    _context = context;
	    }

		/// <summary>
		/// Gets a link to the oauth authorization page
		/// </summary>
		/// <returns></returns>
		[Produces("application/json")]
		[HttpGet("GetOauthLink")]
        public ActionResult GetOauthLink()
        {
	        //Initialize the twitter service
	        TwitterService service = new TwitterService(Config.TwitterConsumerKey, Config.TwitterConsumerSecret);
	        //Retrieve an OAuth Request Token
	        OAuthRequestToken requestToken = service.GetRequestToken(Config.TwitterCallbackUrl);
	        //Check get token succeeded
	        if (requestToken.Token == "?") return StatusCode(500);

	        //Generate oauth link
	        Uri uri = service.GetAuthorizationUri(requestToken);
	        return Ok(new Dictionary<string, string>(){
		        {"uri", uri.ToString()}
	        });
		}

		/// <summary>
		/// Handles callback the from twitter authorization (No auth token required)
		/// </summary>
		/// <param name="oauth_token">Twitter oauth token</param>
		/// <param name="oauth_verifier">Twitter oauth verifier</param>
		/// <returns></returns>
		[AllowAnonymous]
		[HttpGet("OauthCallback")]
        public async Task<ActionResult> OauthCallback([Required][FromQuery] string oauth_token,
			[Required][FromQuery] string oauth_verifier)
		{
			//Get the request token
	        var requestToken = new OAuthRequestToken { Token = oauth_token };
			//Initialize the twitter service
	        var service = new TwitterService(Config.TwitterConsumerKey, Config.TwitterConsumerSecret);

			//Get access token
	        var accessToken = service.GetAccessToken(requestToken, oauth_verifier);
			//Check auth was successful
	        if (String.IsNullOrWhiteSpace(accessToken.ScreenName)) return BadRequest();

	        //User authenticates using the Access Token
	        service.AuthenticateWith(accessToken.Token, accessToken.TokenSecret);
	        
			//Gets the users profile
			var user = service.GetUserProfile(new GetUserProfileOptions());

			//Adds the user to the database
			await _context.TwitterUsers.AddAsync(new Models.Twitter.TwitterUser()
	        {
				TwitterUserId = user.Id,
				Token =  accessToken.Token,
				TokenSecret = accessToken.Token,
				Name = accessToken.ScreenName
	        });
			//Saves the changes to the database
			await _context.SaveChangesAsync();
			return NoContent();
		}

		/// <summary>
		/// Sets the template for tweets sent from the account
		/// </summary>
		/// <param name="id">Twitter users id</param>
		/// <param name="tweetTemplate">Template for tweets</param>
		/// <returns></returns>
		[HttpPost("{id}/SetTweetTemplate")]
        public async Task<ActionResult> SetTweetTemplate(long id, [Required][FromForm] string tweetTemplate)
        {
	        //Check the twitter user exists
	        if (!await _context.TwitterUsers.AnyAsync(x => x.TwitterUserId == id)) return BadRequest();

	        //Get the twitter user with the given id
	        var twitterUser = await _context.TwitterUsers.FirstAsync(x => x.TwitterUserId == id);
	        //Set the user's tweet template
	        twitterUser.TweetTemplate = tweetTemplate;
	        //Save the changes to the database
	        await _context.SaveChangesAsync();
	        return NoContent();
		}

		/// <summary>
		/// Returns all the twitter users in the database
		/// </summary>
		/// <returns></returns>
		[Produces("application/json")]
		[HttpGet("GetAll")]
		public async Task<ActionResult> GetAll()
		{
			//Get all twitter users as an array
			var twitterUsers = await _context.TwitterUsers.ToArrayAsync();
			//Return all the users as JSON
			return Ok(twitterUsers);
		}

		/// <summary>
		/// Deletes the given twitter user from database
		/// </summary>
		/// <param name="id">Twitter users id</param>
		/// <returns></returns>
		[HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(long id)
        {
	        //Check the twitter user exists
	        if (!await _context.TwitterUsers.AnyAsync(x => x.TwitterUserId == id)) return BadRequest();

	        //Get the twitter user with the given id
	        var twitterUser = await _context.TwitterUsers.FirstAsync(x => x.TwitterUserId == id);
	        //Delete the twitter user
	        _context.Remove(twitterUser);
	        //Save all the changes
	        await _context.SaveChangesAsync();
	        return NoContent();
		}
	}
}
