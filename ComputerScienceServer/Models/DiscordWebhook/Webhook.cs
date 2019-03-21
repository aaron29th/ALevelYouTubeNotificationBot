using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ComputerScienceServer.Models.Youtube;
using Discord;
using Discord.Webhook;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using ComputerScienceServer.Models.DiscordWebhook;

namespace ComputerScienceServer.Models.DiscordWebhook
{
	public class Webhook
	{
		[Key]
		public ulong Id { get; set; }
		public string Token { get; set; }
		
		public string MessageTemplate { get; set; }
		public string EmbedTemplate { get; set; }

		public ICollection<WebhookYoutubeSubscription> WebhookYoutubeSubscriptions { get; set; }

		public void SendMessage(PubSubFeed youtubeData)
		{
			//Format template messages with video information
			string message = TextFormatter.Format(youtubeData, MessageTemplate);
			string embedsText = TextFormatter.Format(youtubeData, EmbedTemplate);

			//Create embed obj
			var embedObj = embedsText != null ? 
				JsonConvert.DeserializeObject<WebhookEmbed>(embedsText) : null;
			Embed[] embeds = embedObj != null ? new Embed[]{ embedObj.CreateEmbed() } : null;
			
			//Send message
			DiscordWebhookClient client = new DiscordWebhookClient(Id, Token);
			client.SendMessageAsync(message, false, embeds);
		}

		public bool VerifyExistence()
		{
			try
			{
				//Check webhook exists
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
