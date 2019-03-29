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
			//Retrieve an OAuth Request Token
			TwitterService service = new TwitterService(Config.TwitterConsumerKey, Config.TwitterConsumerSecret);

			OAuthRequestToken requestToken = service.GetRequestToken(Config.TwitterCallbackUrl);
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
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		[HttpGet("OauthCallback")]
        // ReSharper disable twice InconsistentNaming
        public async Task<ActionResult> OauthCallback([Required][FromQuery] string oauth_token,
			[Required][FromQuery] string oauth_verifier)
        {
	        var requestToken = new OAuthRequestToken { Token = oauth_token };

	        var service = new TwitterService(Config.TwitterConsumerKey, Config.TwitterConsumerSecret);

			//Get access token
	        var accessToken = service.GetAccessToken(requestToken, oauth_verifier);

			//Check auth was successful
	        if (String.IsNullOrWhiteSpace(accessToken.ScreenName)) return BadRequest();

	        //User authenticates using the Access Token
	        service.AuthenticateWith(accessToken.Token, accessToken.TokenSecret);
			TweetSharp.TwitterUser user = service.VerifyCredentials(new VerifyCredentialsOptions());
			//string username = user.ScreenName;

			await _context.TwitterUsers.AddAsync(new Models.Twitter.TwitterUser()
	        {
				TwitterUserId = user.Id,
				Token =  accessToken.Token,
				TokenSecret = accessToken.Token,
				Name = accessToken.ScreenName
	        });
			await _context.SaveChangesAsync();
	        
	        return NoContent();
        }

		/// <summary>
		/// Sets the template for tweets sent from the account
		/// </summary>
		/// <param name="id">Twitter users id</param>
		/// <param name="tweetTemplate">Template for tweets</param>
		/// <returns></returns>
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		[HttpPost("{id}/SetTweetTemplate")]
        public async Task<ActionResult> SetTweetTemplate(long id, [Required][FromForm] string tweetTemplate)
        {
			//Check twitter user exists
	        if (await _context.TwitterUsers.AnyAsync(x => x.TwitterUserId == id)) return BadRequest();

	        var twitterUser = await _context.TwitterUsers.FirstAsync(x => x.TwitterUserId == id);
	        twitterUser.TweetTemplate = tweetTemplate;
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
			var twitterUsers = await _context.TwitterUsers.ToArrayAsync();
			return Ok(twitterUsers);
		}

		/// <summary>
		/// Deletes the given twitter user from database
		/// </summary>
		/// <param name="id">Twitter users id</param>
		/// <returns></returns>
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		[HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(long id)
        {
			//Check twitter user exists
	        if (!await _context.TwitterUsers.AnyAsync(x => x.TwitterUserId == id)) return BadRequest();

	        var twitterUser = await _context.TwitterUsers.FirstAsync(x => x.TwitterUserId == id);
	        _context.Remove(twitterUser);
	        await _context.SaveChangesAsync();
	        return NoContent();
        }
	}
}
