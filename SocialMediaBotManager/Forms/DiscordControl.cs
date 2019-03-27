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
			var client = Network.Client;

			var webhooksResponse = await client.GetAsync("Discord/GetAll");
			if (webhooksResponse.StatusCode == HttpStatusCode.Unauthorized)
			{
				statusLabel.Text = "Authentication failed. Please login again.";
			}

			if (!webhooksResponse.IsSuccessStatusCode)
			{
				statusLabel.Text = $"An error occured - {webhooksResponse.StatusCode.ToString()}";
				return;
			}

			var jsonString = await webhooksResponse.Content.ReadAsStringAsync();
			var webhooks = JsonConvert.DeserializeObject<List<Webhook>>(jsonString);

			existingWebhooks.DataSource = webhooks;
			existingWebhooks.DisplayMember = "WebhookId";
		}

		private void webhookAdd_Click(object sender, EventArgs e)
		{
			//Regex pattern for webhook urls
			var pattern = @"https://discordapp.com/api/webhooks/([0-9]+)/([A-Za-z_-]+)";
			var matches = Regex.Matches(webhookUrl.Text, pattern);
			if (matches.Count < 1 || matches[0].Groups.Count < 3)
			{
				statusLabel.Text = "Status: Invalid webhook URL";
				return;
			}

			//Get webhook id and token from url
			ulong webhookId = Convert.ToUInt64(matches[0].Groups[1].Value);
			string token = matches[0].Groups[2].Value;

			var client = Network.Client;
			var values = new Dictionary<string, string>
			{
				{ "username", username },
				{ "password", password }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await client.PostAsync("User/GetToken", content);

			if (!response.IsSuccessStatusCode) return false;
		}

		private void webhookSave_Click(object sender, EventArgs e)
		{

		}

		private void webhookDelete_Click(object sender, EventArgs e)
		{

		}

		private void refreshAll_Click(object sender, EventArgs e)
		{
			RefreshWebhooks();
		}
	}
}
