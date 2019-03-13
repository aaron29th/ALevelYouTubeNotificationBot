using Newtonsoft.Json;

namespace ComputerScienceServer.Models.DiscordWebhook
{
	public class WebhookEmbedImage
	{
		[JsonProperty("url")]
		public string Url { get; set; }
	}
}