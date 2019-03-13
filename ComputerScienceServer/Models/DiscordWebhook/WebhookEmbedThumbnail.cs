using Newtonsoft.Json;

namespace ComputerScienceServer.Models.DiscordWebhook
{
	public class WebhookEmbedThumbnail
	{
		[JsonProperty("url")]
		public string Url { get; set; }
	}
}