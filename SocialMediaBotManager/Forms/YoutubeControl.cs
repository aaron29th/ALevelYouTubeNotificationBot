using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using SocialMediaBotManager.Models;

namespace SocialMediaBotManager.Forms
{
	public partial class YoutubeControl : UserControl
	{
		public YoutubeControl()
		{
			InitializeComponent();
		}

		public async Task RefreshSubscriptions()
		{
			//Send get subscriptions request
			var youtubeResponse = await Network.GetAsync("YoutubePubSub/GetAll");

			//Get for errors
			if (!youtubeResponse.IsSuccessStatusCode)
			{
				//Output error to user
				statusLabel.Text = "An error occured getting subscriptions - " +
				                   $"{youtubeResponse.StatusCode.ToString()}";
				return;
			}

			var youtubeJsonString = await youtubeResponse.Content.ReadAsStringAsync();
			//Convert the json to a list of subscriptions
			var youtubeSubscriptions = JsonConvert
				.DeserializeObject<List<Subscription>>(youtubeJsonString);

			//Display all the subscriptions in the listbox
			subscriptions.DataSource = youtubeSubscriptions;
			subscriptions.DisplayMember = "YoutubeChannelId";

			//Get webhooks
			{
				//Send get discord webhooks request
				var webhooksResponse = await Network.GetAsync("Discord/GetAllWebhooks");

				//Check for errors
				if (!webhooksResponse.IsSuccessStatusCode)
				{
					//Output error to user
					statusLabel.Text = "An error occured getting webhooks - " +
					                   $"{webhooksResponse.StatusCode.ToString()}";
					return;
				}

				var webhooksJsonString = await webhooksResponse.Content.ReadAsStringAsync();
				//Convert json to a list of webhooks
				var webhooks = JsonConvert.DeserializeObject<List<Webhook>>(webhooksJsonString);

				//Display webhooks in listbox
				webhooksListbox.DataSource = webhooks;
				webhooksListbox.DisplayMember = "WebhookId";
			}

			//Get twitter users
			{
				//Send get twitter users request
				var twitterResponse = await Network.GetAsync("Twitter/GetAll");

				//Check for errors
				if (!twitterResponse.IsSuccessStatusCode)
				{
					//Output error to user
					statusLabel.Text = "An error occured getting twitter users - " +
					                   $"{twitterResponse.StatusCode.ToString()}";
					return;
				}

				var twitterJsonString = await twitterResponse.Content.ReadAsStringAsync();
				//Convert json to a list of twitter users
				var twitterUsers = JsonConvert.DeserializeObject<List<TwitterUser>>(twitterJsonString);

				//Display users in list box
				twitterUsersListbox.DataSource = twitterUsers;
				twitterUsersListbox.DisplayMember = "Name";
			}

			//Refresh which buttons should be enabled / disabled
			SetEnabledButtons();
		}

		private void SetEnabledButtons()
		{
			//Get selected subscription, webhook and twitter user
			var subscription = (Subscription)subscriptions.SelectedItem;
			var twitterUser = (TwitterUser)twitterUsersListbox.SelectedItem;
			var webhook = (Webhook)webhooksListbox.SelectedItem;

			//Enable / disable unsubscribe button
			subscriptionDelete.Enabled = subscription != null;

			//Enable / disable link twitter user buttons
			twitterUnlinkSubscription.Enabled = subscription != null && 
			                                    twitterUser != null &&
			                                    subscription.TwitterYoutubeSubscriptions != null &&
												subscription.TwitterYoutubeSubscriptions
				                                    .Any(user => user.TwitterUserId == twitterUser.TwitterUserId);
			twitterLinkSubscription.Enabled = subscription != null && 
			                                  twitterUser != null && 
			                                  !twitterUnlinkSubscription.Enabled;

			//Enable / disable link webhook buttons
			webhookUnlinkSubscription.Enabled = subscription != null &&
			                                    webhook != null && 
			                                    subscription.WebhookYoutubeSubscriptions != null &&
												subscription.WebhookYoutubeSubscriptions
				                                    .Any(x => x.WebhookId == webhook.WebhookId);
			webhookLinkSubscription.Enabled = subscription != null && 
			                                  webhook != null &&
			                                  !webhookUnlinkSubscription.Enabled;
		}

		private async void subscriptionAddNew_Click(object sender, EventArgs e)
		{
			//Send add new subscription request
			var response = await Network.PostFormAsync("YoutubePubSub/AddNew",
				new Dictionary<string, string>()
				{
					{"channelId", youtubeChannelId.Text }
				});

			//Output result to user
			statusLabel.Text = response.IsSuccessStatusCode ? "Status: Successfully subscribed" :
				$"Status: Subscribe failed - {response.StatusCode}";

			await RefreshSubscriptions();
		}

		private async void webhookLinkSubscription_Click(object sender, EventArgs e)
		{
			//Get selected subscription and webhook
			var subscription = (Subscription)subscriptions.SelectedItem;
			var webhook = (Webhook)webhooksListbox.SelectedItem;

			//Send link webhook request
			var response = await Network.PostFormAsync($"YoutubePubSub/{subscription.YoutubeChannelId}/LinkWebhook",
				new Dictionary<string, string>()
				{
					{"webhookId", webhook.WebhookId.ToString() }
				});

			//Output result to user
			statusLabel.Text = response.IsSuccessStatusCode ? "Status: Successfully linked webhook" :
				$"Status: Link webhook failed - {response.StatusCode}";

			await RefreshSubscriptions();
		}

		private async void webhookUnlinkSubscription_Click(object sender, EventArgs e)
		{
			//Get selected subscription and webhook
			var subscription = (Subscription)subscriptions.SelectedItem;
			var webhook = (Webhook)webhooksListbox.SelectedItem;

			//Send unlink webhook request
			var response = await Network.PostFormAsync($"YoutubePubSub/{subscription.YoutubeChannelId}/UnlinkWebhook",
				new Dictionary<string, string>()
				{
					{"webhookId", webhook.WebhookId.ToString() }
				});

			//Output result to user
			statusLabel.Text = response.IsSuccessStatusCode ? "Status: Successfully unlinked webhook" :
				$"Status: Unlink webhook failed - {response.StatusCode}";

			await RefreshSubscriptions();
		}

		private async void twitterLinkSubscription_Click(object sender, EventArgs e)
		{
			//Get selected subscription and twitter user
			var subscription = (Subscription)subscriptions.SelectedItem;
			var twitterUser = (TwitterUser)twitterUsersListbox.SelectedItem;

			//Send link twitter user request
			var response = await Network.PostFormAsync($"YoutubePubSub/{subscription.YoutubeChannelId}/LinkTwitter",
				new Dictionary<string, string>()
				{
					{"twitterId", twitterUser.TwitterUserId.ToString() }
				});

			//Output the result to the user
			statusLabel.Text = response.IsSuccessStatusCode ? "Status: Successfully linked twitter" :
				$"Status: Link twitter failed - {response.StatusCode}";

			await RefreshSubscriptions();
		}

		private async void twitterUnlinkSubscription_Click(object sender, EventArgs e)
		{
			//Get selected subscription and twitter user
			var subscription = (Subscription)subscriptions.SelectedItem;
			var twitterUser = (TwitterUser)twitterUsersListbox.SelectedItem;

			//Send unlink twitter user request
			var response = await Network.PostFormAsync($"YoutubePubSub/{subscription.YoutubeChannelId}/UnlinkTwitter",
				new Dictionary<string, string>()
				{
					{"twitterId", twitterUser.TwitterUserId.ToString() }
				});

			//Output result to user
			statusLabel.Text = response.IsSuccessStatusCode ? "Status: Successfully unlinked twitter" :
				$"Status: Unlink twitter failed - {response.StatusCode}";

			await RefreshSubscriptions();
		}

		private async void subscriptionDelete_Click(object sender, EventArgs e)
		{
			//Get the selected youtube channel's id
			string channelId = ((Subscription)subscriptions.SelectedValue).YoutubeChannelId;
			
			//Send a delete request
			var response = await Network.DeleteAsync($"YoutubePubSub/{channelId}");

			//Output the result
			statusLabel.Text = response.IsSuccessStatusCode ? "Status: Successfully unsubscribed" :
				$"Status: Unsubscribe failed - {response.StatusCode}";

			await RefreshSubscriptions();
		}

		private void webhooksListbox_SelectedIndexChanged(object sender, EventArgs e)
		{
			//Refresh which buttons should be enabled / disabled
			SetEnabledButtons();
		}

		private void twitterAccountsListbox_SelectedIndexChanged(object sender, EventArgs e)
		{
			//Refresh which buttons should be enabled / disabled
			SetEnabledButtons();
		}

		private void subscriptions_SelectedIndexChanged(object sender, EventArgs e)
		{
			//Refresh which buttons should be enabled / disabled
			SetEnabledButtons();
		}

		private async void refreshAll_Click(object sender, EventArgs e)
		{
			await RefreshSubscriptions();
		}
	}
}
