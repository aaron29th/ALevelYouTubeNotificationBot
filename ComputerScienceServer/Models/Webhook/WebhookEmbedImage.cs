using Newtonsoft.Json;

namespace ComputerScienceServer.Models.Webhook
{
	public class WebhookEmbedImage
	{
		[JsonProperty("url")]
		public string Url { get; set; }
	}
}