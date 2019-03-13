using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerScienceServer.Models
{
	public class WebhookYoutubeSubscription
	{
		public ulong Id { get; set; }
		public Webhook Webhook { get; set; }

		public string ChannelId { get; set; }
		public YoutubeSubscription YoutubeSubscription { get; set; }
	}
}
