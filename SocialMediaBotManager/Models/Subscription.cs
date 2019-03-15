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
		public string ChannelId { get; set; }

		public List<Webhook> Webhooks { get; set; }
		public List<TwitterUser> TwitterUsers { get; set; }

		public void Save()
		{
			  
		}
	}
}
