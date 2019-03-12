using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerScienceServer.Models
{
	public class YoutubeSubscription
	{
		[Key]
		public string ChannelId { get; set; }
		public string VerifyToken { get; set; }
		public string HmacToken { get; set; }

		public ICollection<DiscordWebhookYoutubeSubscription> DiscordWebhooksYoutubeSubscriptions { get; set; }
		public ICollection<TwitterYoutubeSubscription> TwitterYoutubeSubscriptions { get; set; }
	}
}
