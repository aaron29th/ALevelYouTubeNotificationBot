using Newtonsoft.Json;

namespace YoutubeNotifyBot.Models.DiscordWebhook
{
	public class WebhookEmbedFooter
	{
		[JsonProperty("icon_url")]
		public string IconUrl { get; set; }
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}