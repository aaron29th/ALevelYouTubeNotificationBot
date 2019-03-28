using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YoutubeNotifyBot.Models.Youtube;
using Newtonsoft.Json;
using TweetSharp;

namespace YoutubeNotifyBot.Models.Twitter
{
	public class TwitterUser
	{
		[Key]
		public long TwitterUserId { get; set; }
		[JsonIgnore]
		public string Token { get; set; }
		[JsonIgnore]
		public string TokenSecret { get; set; }
		public string Name { get; set; }
		public string TweetTemplate { get; set; }
		
		public virtual ICollection<TwitterUserYoutubeSubscription> TwitterYoutubeSubscription { get; set; }

		public void GetAccountInfo()
		{
			TwitterService service = new TwitterService(Config.TwitterConsumerKey, Config.TwitterConsumerSecret);

			service.AuthenticateWith(Token, TokenSecret);
			var user = service.GetUserProfile(new GetUserProfileOptions());
			Name = user.Name;
		}

		public void SendTweet(PubSubFeed youtubeVideoData)
		{
			//If no template is set cancel
			if (TweetTemplate == null) return;

			//Format the tweet template
			string body = youtubeVideoData.FormatTemplateString(TweetTemplate);

			TwitterService service = new TwitterService(Config.TwitterConsumerKey, Config.TwitterConsumerSecret);

			service.AuthenticateWith(Token, TokenSecret);
			service.SendTweet(new SendTweetOptions()
			{
				Status = body
			});
		}
	}
}
