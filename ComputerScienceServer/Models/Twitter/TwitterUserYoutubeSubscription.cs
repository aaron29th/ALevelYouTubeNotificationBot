﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerScienceServer.Models.Youtube;
using Newtonsoft.Json;

namespace ComputerScienceServer.Models.Twitter
{
	public class TwitterUserYoutubeSubscription
	{
		public long TwitterUserId { get; set; }
		[JsonIgnore]
		public TwitterUser TwitterUser { get; set; }

		public string YoutubeChannelId { get; set; }
		[JsonIgnore]
		public virtual YoutubeSubscription YoutubeSubscription { get; set; }
	}
}