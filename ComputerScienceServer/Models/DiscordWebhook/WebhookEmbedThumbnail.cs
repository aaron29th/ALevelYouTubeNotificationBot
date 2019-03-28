using Newtonsoft.Json;

namespace YoutubeNotifyBot.Models.DiscordWebhook
{
	public class WebhookEmbedThumbnail
	{
		[JsonProperty("url")]
		public string Url { get; set; }
	}
}