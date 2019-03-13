using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerScienceServer.Models.Youtube;
using Newtonsoft.Json;

namespace ComputerScienceServer.Models.Twitter
{
	public class TwitterYoutubeSubscription
	{
		public string Token { get; set; }
		[JsonIgnore]
		public TwitterUser TwitterUser { get; set; }

		public string ChannelId { get; set; }
		[JsonIgnore]
		public YoutubeSubscription YoutubeSubscription { get; set; }
	}
}
