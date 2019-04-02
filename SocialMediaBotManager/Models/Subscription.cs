using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaBotManager.Models
{
	class Subscription
	{
		public string YoutubeChannelId { get; set; }

		public List<Webhook> WebhookYoutubeSubscriptions { get; set; }
		public List<TwitterUser> TwitterYoutubeSubscriptions { get; set; }
	}
}
