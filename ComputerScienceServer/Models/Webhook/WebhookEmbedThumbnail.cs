using Newtonsoft.Json;

namespace ComputerScienceServer.Models.Webhook
{
	public class WebhookEmbedThumbnail
	{
		[JsonProperty("url")]
		public string Url { get; set; }
	}
}