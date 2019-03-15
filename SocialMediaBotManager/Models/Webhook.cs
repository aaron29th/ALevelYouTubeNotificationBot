using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaBotManager.Models
{
	class Webhook
	{
		public ulong Id { get; set; }
		public string Token { get; set; }

		public string MessageTemplate { get; set; }
		public string EmbedTemplate { get; set; }

		public void Save()
		{

		}
	}
}
