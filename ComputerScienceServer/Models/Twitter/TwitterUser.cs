using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ComputerScienceServer.Models.Youtube;
using TweetSharp;

namespace ComputerScienceServer.Models.Twitter
{
	public class TwitterUser
	{
		private const string _consumerKey = "***REMOVED***";
		private const string _consumerSecret = "***REMOVED***";

		[Key]
		public string Token { get; set; }
		public string TokenSecret { get; set; }

		public string Name { get; set; }

		public string TweetTemplate { get; set; }

		public ICollection<TwitterYoutubeSubscription> TwitterYoutubePubSub { get; set; }

		public void GetInfo()
		{
			TwitterService service = new TwitterService(_consumerKey, _consumerSecret);

			service.AuthenticateWith(Token, TokenSecret);
			var user = service.GetUserProfile(new GetUserProfileOptions());
			Name = user.Name;
		}

		public void SendTweet(PubSubFeed youtubeVideoData)
		{
			string body = TextFormatter.Format(youtubeVideoData, TweetTemplate);

			TwitterService service = new TwitterService(_consumerKey, _consumerSecret);

			service.AuthenticateWith(Token, TokenSecret);
			service.SendTweet(new SendTweetOptions()
			{
				Status = body
			});
		}
	}
}
