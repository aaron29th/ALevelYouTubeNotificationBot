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
		public ulong WebhookId { get; set; }
		[JsonIgnore]
		public Webhook Webhook { get; set; }
		[JsonIgnore]
		public string YoutubeChannelId { get; set; }
		[JsonIgnore]
		public virtual YoutubeSubscription YoutubeSubscription { get; set; }
	}
}
