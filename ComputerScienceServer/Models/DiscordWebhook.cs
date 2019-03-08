using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ComputerScienceServer.Models.PubSub;
using Discord;
using Discord.Webhook;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using ComputerScienceServer.Models.Webhook;

namespace ComputerScienceServer.Models
{
	public class DiscordWebhook
	{
		[Key]
		public ulong Id { get; set; }
		public string Token { get; set; }
		
		public string MessageTemplate { get; set; }
		public string EmbedTemplate { get; set; }

		public async Task SendMessage(PubSubFeed youtubeData)
		{
			string message = TextFormatter.Format(youtubeData, MessageTemplate);
			string embedsText = TextFormatter.Format(youtubeData, EmbedTemplate);

			var embedObj = embedsText != null ? 
				JsonConvert.DeserializeObject<WebhookEmbed>(embedsText) : null;
			Embed[] embeds = embedsText != null ? new Embed[]{ embedObj.CreateEmbed() } : null;
			try
			{
				DiscordWebhookClient client = new DiscordWebhookClient(Id, Token);
				ulong i = await client.SendMessageAsync(message, false, embeds);
			}
			catch
			{

			}
		}

		public bool VerifyExistence()
		{
			try
			{
				DiscordWebhookClient client = new DiscordWebhookClient(Id, Token);
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
