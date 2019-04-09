using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using SocialMediaBotManager.Models;

namespace SocialMediaBotManager.Forms
{
	public partial class DiscordControl : UserControl
	{
		public DiscordControl()
		{
			InitializeComponent();
		}

		public async Task RefreshWebhooks()
		{
			var webhooksResponse = await Network.GetAsync("Discord/GetAllWebhooks");

			if (!webhooksResponse.IsSuccessStatusCode)
			{
				statusLabel.Text = $"An error occured - {webhooksResponse.StatusCode.ToString()}";
				return;
			}

			var jsonString = await webhooksResponse.Content.ReadAsStringAsync();
			var webhooks = JsonConvert.DeserializeObject<List<Webhook>>(jsonString);

			messageTemplate.Text = "";
			embedTemplate.Text = "";
			existingWebhooks.DataSource = webhooks;
			existingWebhooks.DisplayMember = "WebhookId";

			//Enable save and delete buttons if webhooks exist
			webhookSave.Enabled = webhooks.Count > 0;
			webhookDelete.Enabled = webhooks.Count > 0;
		}

		private async void webhookAdd_Click(object sender, EventArgs e)
		{
			//Regex pattern for webhook urls
			var pattern = @"https://discordapp.com/api/webhooks/([0-9]+)/([A-Za-z0-9_-]+)";
			var matches = Regex.Matches(webhookUrl.Text, pattern);
			if (matches.Count < 1 || matches[0].Groups.Count < 3)
			{
				statusLabel.Text = "Status: Invalid webhook URL";
				return;
			}

			//Get webhook id and token from url
			ulong webhookId = Convert.ToUInt64(matches[0].Groups[1].Value);
			string token = matches[0].Groups[2].Value;

			var response = await Network.PostFormAsync("Discord/AddWebhook",
				new Dictionary<string, string>()
				{
					{"webhookId", webhookId.ToString() },
					{"token", token}
				});

			statusLabel.Text = response.IsSuccessStatusCode ? "Status: Successfully added webhook" : 
				$"Status: Add webhook failed {response.StatusCode}";
			await RefreshWebhooks();
		}

		private async void webhookSave_Click(object sender, EventArgs e)
		{
			ulong webhookId = ((Webhook)existingWebhooks.SelectedValue).WebhookId;
			var values = new Dictionary<string, string>()
			{
				{ "messageTemplate", messageTemplate.Text },
				{ "embedTemplate", embedTemplate.Text }
			};

			var response = await Network.PostFormAsync($"Discord/{webhookId}/SetMessageTemplate", values);

			statusLabel.Text = response.IsSuccessStatusCode ? "Status: Successfully updated template messages" : 
				$"Status: An error occured - {response.StatusCode}";
		}

		private async void webhookDelete_Click(object sender, EventArgs e)
		{
			ulong webhookId = ((Webhook)existingWebhooks.SelectedValue).WebhookId;

			var response = await Network.DeleteAsync($"Discord/{webhookId}");

			statusLabel.Text = response.IsSuccessStatusCode ? "Status: Successfully deleted webhook" : 
				$"Status: An error occured - {response.StatusCode}";
			await RefreshWebhooks();
		}

		private async void refreshAll_Click(object sender, EventArgs e)
		{
			await RefreshWebhooks();
		}

		private void existingWebhooks_SelectedIndexChanged(object sender, EventArgs e)
		{
			Webhook selectedWebhook = (Webhook)existingWebhooks.SelectedValue;
			messageTemplate.Text = selectedWebhook.MessageTemplate;
			embedTemplate.Text = selectedWebhook.EmbedTemplate;
		}
	}
}
