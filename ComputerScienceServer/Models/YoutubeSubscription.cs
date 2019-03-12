﻿using System;
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

		//public ICollection<DiscordWebhook> DiscordWebhooks { get; set; }
		public ICollection<TwitterYoutubeSubscription> TwitterYoutubePubSub { get; set; }
	}
}