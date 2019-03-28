using Newtonsoft.Json;

namespace YoutubeNotifyBot.Models.DiscordWebhook
{
	public class WebhookEmbedImage
	{
		[JsonProperty("url")]
		public string Url { get; set; }
	}
}