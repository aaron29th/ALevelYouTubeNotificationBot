using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ComputerScienceServer.Models.PubSub;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TweetSharp;

namespace ComputerScienceServer.Models
{
	public class TwitterUser
	{
		private static string _consumerKey = "***REMOVED***";
		private static string _consumerSecret = "***REMOVED***";

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
