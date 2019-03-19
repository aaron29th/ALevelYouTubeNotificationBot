using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerScienceServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

		[HttpGet("SendHelloWorld")]
        public string SendHelloWorld()
        {
	        string twitterToken = "***REMOVED***";
	        string twitterSecret = "***REMOVED***";

			TwitterService service = new TwitterService(Config.TwitterConsumerKey, Config.TwitterConsumerSecret);

	        service.AuthenticateWith(twitterToken, twitterSecret);
	        service.SendTweet(new SendTweetOptions()
	        {
				Status = "Hello world..."
	        });
			return "";
        }

        [HttpGet("GetOauthLink")]
        public ActionResult GetOauthLink()
        {
			// Step 1 - Retrieve an OAuth Request Token
			TwitterService service = new TwitterService(
				Config.TwitterConsumerKey, Config.TwitterConsumerSecret);

			// This is the registered callback URL
			OAuthRequestToken requestToken = service.GetRequestToken(
				Config.TwitterCallbackUrl);

			// Step 2 - Redirect to the OAuth Authorization URL
			Uri uri = service.GetAuthorizationUri(requestToken);
			return Ok(uri.ToString());
		}

        [HttpGet("OauthCallback")]
        // ReSharper disable twice InconsistentNaming
        public ActionResult OauthCallback([FromQuery] string oauth_token, [FromQuery] string oauth_verifier)
        {
	        var requestToken = new OAuthRequestToken { Token = oauth_token };

	        // Step 3 - Exchange the Request Token for an Access Token
	        TwitterService service = new TwitterService(
		        Config.TwitterConsumerKey, Config.TwitterConsumerSecret);

	        OAuthAccessToken accessToken = service.GetAccessToken(requestToken,
		        oauth_verifier);

	        // Step 4 - User authenticates using the Access Token
	        service.AuthenticateWith(accessToken.Token,
		        accessToken.TokenSecret);

	        TweetSharp.TwitterUser user = service.VerifyCredentials(
		        new VerifyCredentialsOptions());

	        string username = user.ScreenName;
	        return Ok(username);
        }
    }
}
