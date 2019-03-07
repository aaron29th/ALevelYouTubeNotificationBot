using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TweetSharp;

namespace ComputerScienceServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwitterController : ControllerBase
    {
        // GET: api/Twitter
        [HttpGet]
        public string Get()
        {
	        string twitterToken = "***REMOVED***";
	        string twitterSecret = "***REMOVED***";
	        string consumerKey = "***REMOVED***";
	        string consumerSecret = "***REMOVED***";

			// Pass your credentials to the service
			TwitterService service = new TwitterService(consumerKey, consumerSecret);

	        // Step 4 - User authenticates using the Access Token
	        service.AuthenticateWith(twitterToken, twitterSecret);
	        service.SendTweet(new SendTweetOptions()
	        {
				Status = "Hello world..."
	        });
			return "";
        }

        // GET: api/Twitter/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(string id)
        {
	        return id;
        }
    }
}
