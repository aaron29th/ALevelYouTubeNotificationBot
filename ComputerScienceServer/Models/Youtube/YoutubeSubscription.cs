using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using ComputerScienceServer.Models.DiscordWebhook;
using ComputerScienceServer.Models.Twitter;
using Newtonsoft.Json;

namespace ComputerScienceServer.Models.Youtube
{
	public class YoutubeSubscription
	{
		[Key]
		public string ChannelId { get; set; }
		[JsonIgnore]
		public string VerifyToken { get; set; }
		[JsonIgnore]
		public string HmacToken { get; set; }
		[JsonIgnore]
		public DateTime Expires { get; set; }
		[JsonIgnore]
		public bool Verified { get; set; }

		public ICollection<WebhookYoutubeSubscription> WebhookYoutubeSubscriptions { get; set; }
		public ICollection<TwitterYoutubeSubscription> TwitterYoutubeSubscriptions { get; set; }

		public static YoutubeSubscription Subscribe(string channelId, List<string> webhookIds, List<string> twitterTokens)
		{
			return new YoutubeSubscription()
			{
				ChannelId = channelId,
				VerifyToken = "",
				HmacToken = "",
				Expires = DateTime.Now.AddSeconds(432000),
				Verified = false
			};
		}

		public void Renew()
		{

		}

		public void Unsubscribe()
		{

		}
	}
}
