using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Newtonsoft.Json;

namespace ComputerScienceServer.Models.Webhook
{
	public class WebhookEmbed
	{
		public string title { get; set; }
		public string description { get; set; }
		public string url { get; set; }
		public int color { get; set; }
		public DateTime timestamp { get; set; }
		public WebhookEmbedFooter footer { get; set; }
		public WebhookEmbedThumbnail thumbnail { get; set; }
		public WebhookEmbedImage image { get; set; }
		public WebhookEmbedAuthor author { get; set; }
		public List<WebhookEmbedField> fields { get; set; }

		public static Embed CreateEmbed(string json)
		{
			var embed = JsonConvert.DeserializeObject<WebhookEmbed>(json);
			EmbedBuilder eb = new EmbedBuilder();

			return eb.Build();
		}
	}
}
