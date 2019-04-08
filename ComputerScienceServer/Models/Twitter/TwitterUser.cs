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

		/// <summary>
		/// Formats tweet template with YouTube video information and sends the tweet
		/// </summary>
		/// <param name="youtubeVideoData"></param>
		public void SendTweet(PubSubFeed youtubeVideoData)
		{
			//If no template is set, cancel sending tweet
			if (TweetTemplate == null) return;

			//Format the tweet template
			string body = youtubeVideoData.FormatTemplateString(TweetTemplate);

			//Initialize twitter service
			TwitterService service = new TwitterService(Config.TwitterConsumerKey, Config.TwitterConsumerSecret);
			//Login to the twitter user
			service.AuthenticateWith(Token, TokenSecret);
			//Send the tweet
			service.SendTweet(new SendTweetOptions()
			{
				Status = body
			});
		}
	}
}
