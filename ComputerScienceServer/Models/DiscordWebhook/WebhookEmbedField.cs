using Newtonsoft.Json;

namespace ComputerScienceServer.Models.DiscordWebhook
{
	public class WebhookEmbedField
	{
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("value")]
		public string Value { get; set; }
		[JsonProperty("inline")]
		public bool Inline { get; set; }
	}
}