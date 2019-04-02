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
			//Get subscriptions
			var youtubeResponse = await Network.GetAsync("YoutubePubSub/GetAll");

			if (!youtubeResponse.IsSuccessStatusCode)
			{
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

			//Disable unsubscribe button if no subscriptions are returned
			subscriptionDelete.Enabled = youtubeSubscriptions.Count > 0;

			//Get webhooks
			{
				var webhooksResponse = await Network.GetAsync("Discord/GetAllWebhooks");

				if (!webhooksResponse.IsSuccessStatusCode)
				{
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

				//Enable / disable link webhook buttons
				webhookUnlinkSubscription.Enabled = webhooks.Count > 0 && youtubeSubscriptions[0].WebhookYoutubeSubscriptions
					                                  .Any(webhook => webhook.WebhookId == webhooks[0].WebhookId);
				webhookLinkSubscription.Enabled = webhooks.Count > 0 && !webhookUnlinkSubscription.Enabled;
			}

			//Get twitter users
			{
				var twitterResponse = await Network.GetAsync("Twitter/GetAll");

				if (!twitterResponse.IsSuccessStatusCode)
				{
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

				//Enable / disable link twitter user buttons
				twitterUnlinkSubscription.Enabled = twitterUsers.Count > 0 && youtubeSubscriptions[0].TwitterYoutubeSubscriptions
					                                    .Any(user =>
						                                    user.TwitterUserId == twitterUsers[0].TwitterUserId);
				twitterLinkSubscription.Enabled = twitterUsers.Count > 0 && !twitterUnlinkSubscription.Enabled;
			}
		}

		private async void subscriptionAddNew_Click(object sender, EventArgs e)
		{
			var response = await Network.PostFormAsync("YoutubePubSub/AddNew",
				new Dictionary<string, string>()
				{
					{"channelId", youtubeChannelId.Text }
				});

			statusLabel.Text = response.IsSuccessStatusCode ? "Status: Successfully subscribed" :
				$"Status: Subscribe failed - {response.StatusCode}";
		}

		private async void webhookLinkSubscription_Click(object sender, EventArgs e)
		{
			var subscription = (Subscription)subscriptions.SelectedItem;
			var webhook = (Webhook)webhooksListbox.SelectedItem;

			var response = await Network.PostFormAsync($"YoutubePubSub/{subscription.YoutubeChannelId}/LinkWebhook",
				new Dictionary<string, string>()
				{
					{"webhookId", webhook.WebhookId.ToString() }
				});

			statusLabel.Text = response.IsSuccessStatusCode ? "Status: Successfully linked webhook" :
				$"Status: Link webhook failed - {response.StatusCode}";

			await RefreshSubscriptions();
		}

		private async void webhookUnlinkSubscription_Click(object sender, EventArgs e)
		{
			var subscription = (Subscription)subscriptions.SelectedItem;
			var webhook = (Webhook)webhooksListbox.SelectedItem;

			var response = await Network.PostFormAsync($"YoutubePubSub/{subscription.YoutubeChannelId}/UnlinkWebhook",
				new Dictionary<string, string>()
				{
					{"webhookId", webhook.WebhookId.ToString() }
				});

			statusLabel.Text = response.IsSuccessStatusCode ? "Status: Successfully unlinked webhook" :
				$"Status: Unlink webhook failed - {response.StatusCode}";

			await RefreshSubscriptions();
		}

		private async void twitterLinkSubscription_Click(object sender, EventArgs e)
		{
			var subscription = (Subscription)subscriptions.SelectedItem;
			var twitterUser = (TwitterUser)twitterUsersListbox.SelectedItem;

			var response = await Network.PostFormAsync($"YoutubePubSub/{subscription.YoutubeChannelId}/LinkTwitter",
				new Dictionary<string, string>()
				{
					{"twitterId", twitterUser.TwitterUserId.ToString() }
				});

			statusLabel.Text = response.IsSuccessStatusCode ? "Status: Successfully linked twitter" :
				$"Status: Link twitter failed - {response.StatusCode}";

			await RefreshSubscriptions();
		}

		private async void twitterUnlinkSubscription_Click(object sender, EventArgs e)
		{
			var subscription = (Subscription)subscriptions.SelectedItem;
			var twitterUser = (TwitterUser)twitterUsersListbox.SelectedItem;

			var response = await Network.PostFormAsync($"YoutubePubSub/{subscription.YoutubeChannelId}/UnlinkTwitter",
				new Dictionary<string, string>()
				{
					{"twitterId", twitterUser.TwitterUserId.ToString() }
				});

			statusLabel.Text = response.IsSuccessStatusCode ? "Status: Successfully unlinked twitter" :
				$"Status: Unlink twitter failed - {response.StatusCode}";

			await RefreshSubscriptions();
		}

		private void webhooksListbox_SelectedIndexChanged(object sender, EventArgs e)
		{
			var subscription = (Subscription)subscriptions.SelectedItem;
			var webhook = (Webhook)webhooksListbox.SelectedItem;

			//Enable / disable link webhook buttons
			webhookUnlinkSubscription.Enabled = subscription != null && subscription.WebhookYoutubeSubscriptions
				                                    .Any(x => x.WebhookId == webhook.WebhookId);
			webhookLinkSubscription.Enabled = subscription != null && !webhookUnlinkSubscription.Enabled;
		}

		private void twitterAccountsListbox_SelectedIndexChanged(object sender, EventArgs e)
		{
			var subscription = (Subscription)subscriptions.SelectedItem;
			var twitterUser = (TwitterUser) twitterUsersListbox.SelectedItem;

			//Enable / disable link twitter user buttons
			twitterUnlinkSubscription.Enabled = subscription != null && subscription.TwitterYoutubeSubscriptions
				                                    .Any(user => user.TwitterUserId == twitterUser.TwitterUserId);
			twitterLinkSubscription.Enabled = subscription != null && !twitterUnlinkSubscription.Enabled;
		}

		private void subscriptions_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private async void refreshAll_Click(object sender, EventArgs e)
		{
			await RefreshSubscriptions();
		}

		private async void subscriptionDelete_Click(object sender, EventArgs e)
		{
			string channelId = ((Subscription)subscriptions.SelectedValue).YoutubeChannelId;

			var response = await Network.DeleteAsync($"YoutubePubSub/{channelId}");

			statusLabel.Text = response.IsSuccessStatusCode ? "Status: Successfully unsubscribed" :
				$"Status: Unsubscribe failed - {response.StatusCode}";
		}
	}
}
