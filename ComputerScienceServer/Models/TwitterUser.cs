using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerScienceServer.Models.PubSub;
using TweetSharp;

namespace ComputerScienceServer.Models
{
	public class TwitterUser
	{
		public string Token { get; set; }
		public string TokenSecret { get; set; }

		public string TweetTemplate { get; set; }

		public async void SendTweet(PubSubFeed youtubeVideoData)
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
		}
	}
}
