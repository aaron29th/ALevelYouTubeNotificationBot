using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Newtonsoft.Json;

namespace YoutubeNotifyBot.Models.DiscordWebhook
{
	public class WebhookEmbed
	{
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("url")]
		public string Url { get; set; }
		[JsonProperty("color")]
		public uint Color { get; set; }
		[JsonProperty("timestamp")]
		public DateTime Timestamp { get; set; }
		[JsonProperty("footer")]
		public WebhookEmbedFooter Footer { get; set; }
		[JsonProperty("thumbnail")]
		public WebhookEmbedThumbnail Thumbnail { get; set; }
		[JsonProperty("image")]
		public WebhookEmbedImage Image { get; set; }
		[JsonProperty("author")]
		public WebhookEmbedAuthor Author { get; set; }
		[JsonProperty("fields")]
		public List<WebhookEmbedField> Fields { get; set; }

		public void IgnoreExceptions(Action action)
		{
			try
			{
				action.Invoke();
			}
			catch { }
		}

		public Embed CreateEmbed()
		{
			//Create embed object builder
			EmbedBuilder eb = new EmbedBuilder();
			//Add all properties to the embed object, ignoring any null exceptions
			IgnoreExceptions(() => eb.WithTitle(Title));
			IgnoreExceptions(() => eb.WithDescription(Description));
			IgnoreExceptions(() => eb.WithUrl(Url));
			IgnoreExceptions(() => eb.WithColor(new Color(Color)));
			IgnoreExceptions(() => eb.WithTimestamp(Timestamp));
			IgnoreExceptions(() => eb.Footer.WithIconUrl(Footer.IconUrl));
			IgnoreExceptions(() => eb.Footer.WithText(Footer.Text));
			IgnoreExceptions(() => eb.WithThumbnailUrl(Thumbnail.Url));
			IgnoreExceptions(() => eb.WithImageUrl(Image.Url));
			IgnoreExceptions(() => eb.Author.WithName(Author.Name));
			IgnoreExceptions(() => eb.Author.WithIconUrl(Author.IconUrl));
			IgnoreExceptions(() => eb.Author.WithUrl(Author.Url));
			//Add all the fields in the list
			foreach (var field in Fields)
			{
				IgnoreExceptions(() => eb.AddField(field.Name, field.Value, field.Inline));
			}
			//Build the embed object
			return eb.Build();
		}
	}
}
