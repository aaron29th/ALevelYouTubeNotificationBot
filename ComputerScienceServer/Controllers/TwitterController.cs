using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerScienceServer.Models;
using ComputerScienceServer.Models.Twitter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TweetSharp;

namespace ComputerScienceServer.Controllers
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

		//Gets oauth link for authenticating an account
        [HttpGet("GetOauthLink")]
        public ActionResult GetOauthLink()
        {
			//Retrieve an OAuth Request Token
			TwitterService service = new TwitterService(Config.TwitterConsumerKey, Config.TwitterConsumerSecret);

			OAuthRequestToken requestToken = service.GetRequestToken(Config.TwitterCallbackUrl);

			//Generate oauth link
			Uri uri = service.GetAuthorizationUri(requestToken);
			return Ok(uri.ToString());
		}

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
				Id = user.Id,
				Token =  accessToken.Token,
				TokenSecret = accessToken.Token,
				Name = accessToken.ScreenName
	        });
			await _context.SaveChangesAsync();
	        
	        return NoContent();
        }

        [HttpPost("SetTweetTemplate/{id}")]
        public async Task<ActionResult> SetTweetTemplate(long id, [FromForm] string tweetTemplate)
        {
			//Check twitter user exists
	        if (await _context.TwitterUsers.AnyAsync(x => x.Id == id)) return BadRequest();

	        var twitterUser = await _context.TwitterUsers.FirstAsync(x => x.Id == id);
	        twitterUser.TweetTemplate = tweetTemplate;
	        await _context.SaveChangesAsync();
			return NoContent();
        }

		[HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(long id)
        {
			//Check twitter user exists
	        if (await _context.TwitterUsers.AnyAsync(x => x.Id == id)) return BadRequest();

	        var twitterUser = await _context.TwitterUsers.FirstAsync(x => x.Id == id);
	        _context.Remove(twitterUser);
	        await _context.SaveChangesAsync();
	        return NoContent();
        }
	}
}
