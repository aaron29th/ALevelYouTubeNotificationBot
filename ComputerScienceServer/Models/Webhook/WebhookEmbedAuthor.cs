﻿using Newtonsoft.Json;

namespace ComputerScienceServer.Models.Webhook
{
	public class WebhookEmbedAuthor
	{
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("url")]
		public string Url { get; set; }
		[JsonProperty("icon_url")]
		public string IconUrl { get; set; }
	}
}