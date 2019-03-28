using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace YoutubeNotifyBot.Models.Youtube
{
	public class PubSub
	{
		public string CallbackUrl { get; set; }
		public string Topic { get; set; }
		public string VerifyType { get; set; }
		public string Mode { get; set; }
		public string VerifyToken { get; set; }
		public string HmacSecret { get; set; }
		public ulong Lease { get; set; }
	}
}
