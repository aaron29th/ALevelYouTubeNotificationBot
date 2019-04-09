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
			//Send a request to get all the webhooks in the database and await the response
			var webhooksResponse = await Network.GetAsync("Discord/GetAllWebhooks");

			//Check if the request was successful
			if (!webhooksResponse.IsSuccessStatusCode)
			{
				//Output the error code to the status bar
				statusLabel.Text = $"An error occured getting webhooks - {webhooksResponse.StatusCode.ToString()}";
				return;
			}

			//Deserialize the response body to a lst of webhooks
			var jsonString = await webhooksResponse.Content.ReadAsStringAsync();
			var webhooks = JsonConvert.DeserializeObject<List<Webhook>>(jsonString);

			//Clear the message template text boxes
			messageTemplate.Text = "";
			embedTemplate.Text = "";
			//Update the list of webhooks
			existingWebhooks.DataSource = webhooks;
			existingWebhooks.DisplayMember = "WebhookId";

			//Enable / disable the save and delete buttons
			webhookSave.Enabled = webhooks.Count > 0;
			webhookDelete.Enabled = webhooks.Count > 0;
		}

		private async void webhookAdd_Click(object sender, EventArgs e)
		{
			//Regex pattern for discord webhook urls
			var pattern = @"https://discordapp.com/api/webhooks/([0-9]+)/([A-Za-z0-9_-]+)";
			//Ensure the webhook URL is in the correct format
			var matches = Regex.Matches(webhookUrl.Text, pattern);
			if (matches.Count < 1 || matches[0].Groups.Count < 3)
			{
				statusLabel.Text = "Status: Invalid webhook URL";
				return;
			}

			//Get the webhook id and token from url
			ulong webhookId = Convert.ToUInt64(matches[0].Groups[1].Value);
			string token = matches[0].Groups[2].Value;

			//Post the add webhook request with the webhook token as a form parameter
			var response = await Network.PostFormAsync("Discord/AddWebhook",
				new Dictionary<string, string>()
				{
					{"webhookId", webhookId.ToString() },
					{"token", token}
				});

			//Output the result of the request to the status bar
			statusLabel.Text = response.IsSuccessStatusCode ? "Status: Successfully added webhook" : 
				$"Status: Add webhook failed {response.StatusCode}";
			//Refresh the webhooks
			await RefreshWebhooks();
		}

		private async void webhookSave_Click(object sender, EventArgs e)
		{
			//Get the selected webhook's id
			ulong webhookId = ((Webhook)existingWebhooks.SelectedValue).WebhookId;
			
			//Create the post request's body
			var values = new Dictionary<string, string>()
			{
				{ "messageTemplate", messageTemplate.Text },
				{ "embedTemplate", embedTemplate.Text }
			};

			//Send a post request to set the webhook message templates and await the response
			var response = await Network.PostFormAsync($"Discord/{webhookId}/SetMessageTemplate", values);

			//Output the result to the status bar
			if (response.IsSuccessStatusCode)
			{
				statusLabel.Text = "Status: Successfully updated template messages";
				await RefreshWebhooks();
			}
			else
			{
				statusLabel.Text = $"Status: An error occured - {response.StatusCode}";
			}
		}

		private async void webhookDelete_Click(object sender, EventArgs e)
		{
			//Ask the user if they are sure they want to delete the twitter user
			var dialogResult = MessageBox.Show("Are you sure you wish to delete the selected webhook?",
				"Delete webhook", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (dialogResult == DialogResult.No)
			{
				statusLabel.Text = "Deletion cancelled";
				return;
			}

			//Get the selected webhook's id
			ulong webhookId = ((Webhook)existingWebhooks.SelectedValue).WebhookId;

			//Send the delete request to the server and await the response
			var response = await Network.DeleteAsync($"Discord/{webhookId}");

			//Output the response to the status bar
			statusLabel.Text = response.IsSuccessStatusCode ? "Status: Successfully deleted webhook" : 
				$"Status: An error occured - {response.StatusCode}";
			//Reload the webhooks from the web server
			await RefreshWebhooks();
		}

		private async void refreshAll_Click(object sender, EventArgs e)
		{
			//Reload the webhooks from the web server
			await RefreshWebhooks();
		}

		private void existingWebhooks_SelectedIndexChanged(object sender, EventArgs e)
		{
			//Get the selected webhook
			Webhook selectedWebhook = (Webhook)existingWebhooks.SelectedValue;
			//Set the template message text boxes to the webhooks template messages
			messageTemplate.Text = selectedWebhook.MessageTemplate;
			embedTemplate.Text = selectedWebhook.EmbedTemplate;
		}
	}
}
