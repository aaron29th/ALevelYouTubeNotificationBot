using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerScienceServer.Models
{
	public class DiscordWebhookYoutubeSubscription
	{
		public string Token { get; set; }
		public DiscordWebhook Webhook { get; set; }

		public string ChannelId { get; set; }
		public YoutubeSubscription YoutubeSubscription { get; set; }
	}
}
