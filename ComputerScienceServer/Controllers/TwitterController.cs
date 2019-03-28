using System;
using System.Collections.Generic;
using System.Linq;
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
		/// Gets a link to oauth authorization page
		/// </summary>
		/// <returns></returns>
        [HttpGet("GetOauthLink")]
        public ActionResult GetOauthLink()
        {
			//Retrieve an OAuth Request Token
			TwitterService service = new TwitterService(Config.TwitterConsumerKey, Config.TwitterConsumerSecret);

			OAuthRequestToken requestToken = service.GetRequestToken(Config.TwitterCallbackUrl);
			if (requestToken.Token == "?") return StatusCode(500);

			//Generate oauth link
			Uri uri = service.GetAuthorizationUri(requestToken);
			return Ok(uri.ToString());
		}

		/// <summary>
		/// Handles callback from twitter authorization
		/// </summary>
		/// <param name="oauth_token">Twitter oauth token</param>
		/// <param name="oauth_verifier">Twitter oauth verifier</param>
		/// <returns></returns>
		[AllowAnonymous]
        [HttpGet("OauthCallback")]
        // ReSharper disable twice InconsistentNaming
        public async Task<ActionResult> OauthCallback([FromQuery] string oauth_token, 
			[FromQuery] string oauth_verifier)
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
		/// Sets the templates for tweets sent from the account
		/// </summary>
		/// <param name="id">Twitter users id</param>
		/// <param name="tweetTemplate">Template for tweets</param>
		/// <returns></returns>
        [HttpPost("SetTweetTemplate/{id}")]
        public async Task<ActionResult> SetTweetTemplate(long id, [FromForm] string tweetTemplate)
        {
			//Check twitter user exists
	        if (await _context.TwitterUsers.AnyAsync(x => x.TwitterUserId == id)) return BadRequest();

	        var twitterUser = await _context.TwitterUsers.FirstAsync(x => x.TwitterUserId == id);
	        twitterUser.TweetTemplate = tweetTemplate;
	        await _context.SaveChangesAsync();
			return NoContent();
        }

		/// <summary>
		/// Returns all twitter users
		/// </summary>
		/// <returns></returns>
		[HttpGet("GetAll")]
		public async Task<ActionResult> GetAll()
		{
			var twitterUsers = await _context.TwitterUsers.ToArrayAsync();
			return Ok(twitterUsers);
		}

		/// <summary>
		/// Deletes twitter user from database
		/// </summary>
		/// <param name="id">Twitter users id</param>
		/// <returns></returns>
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
