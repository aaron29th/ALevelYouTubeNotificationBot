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

namespace ComputerScienceServer.Models
{
	public class DiscordWebhook
	{
		[Key]
		public ulong Id { get; set; }
		public string Token { get; set; }
		
		public string MessageTemplate { get; set; }
		public string EmbedTemplate { get; set; }

		public void SendMessage(PubSubFeed youtubeData)
		{
			string message = TextFormatter.Format(youtubeData, MessageTemplate);
			string embedsText = TextFormatter.Format(youtubeData, EmbedTemplate);

			Embed embed = JsonConvert.DeserializeObject<Embed>(embedsText);
			Embed[] embeds = { embed };

			DiscordWebhookClient client = new DiscordWebhookClient(Id, Token);
			client.SendMessageAsync(message, false, embeds);
		}
	}
}
