using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ComputerScienceServer.Models.DiscordWebhook;
using ComputerScienceServer.Models.Twitter;

namespace ComputerScienceServer.Models.Youtube
{
	public class YoutubeSubscription
	{
		[Key]
		public string ChannelId { get; set; }
		public string VerifyToken { get; set; }
		public string HmacToken { get; set; }

		public ICollection<WebhookYoutubeSubscription> WebhookYoutubeSubscriptions { get; set; }
		public ICollection<TwitterYoutubeSubscription> TwitterYoutubeSubscriptions { get; set; }
	}
}
