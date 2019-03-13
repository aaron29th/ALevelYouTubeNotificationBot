using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerScienceServer.Models.Youtube;
using Newtonsoft.Json;

namespace ComputerScienceServer.Models.DiscordWebhook
{
	public class WebhookYoutubeSubscription
	{
		public ulong Id { get; set; }
		[JsonIgnore]
		public Webhook Webhook { get; set; }

		public string ChannelId { get; set; }
		[JsonIgnore]
		public YoutubeSubscription YoutubeSubscription { get; set; }
	}
}
