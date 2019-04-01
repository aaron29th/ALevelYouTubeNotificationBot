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
	public partial class TwitterControl : UserControl
	{
		public TwitterControl()
		{
			InitializeComponent();
		}

		public async Task RefreshTwitterUsers()
		{
			var response = await Network.GetAsync("Twitter/GetAll");

			if (!response.IsSuccessStatusCode)
			{
				statusLabel.Text = $"An error occured - {response.StatusCode.ToString()}";
				return;
			}

			var jsonString = await response.Content.ReadAsStringAsync();
			var twitterUsers = JsonConvert.DeserializeObject<List<TwitterUser>>(jsonString);

			existingTwitterUsers.DataSource = twitterUsers;
			existingTwitterUsers.DisplayMember = "Name";

			//Enable save and delete buttons if webhooks exist
			twitterUserSave.Enabled = twitterUsers.Count > 0;
			twitterUserDelete.Enabled = twitterUsers.Count > 0;
		}

		private async void openTwitterOauth_Click(object sender, EventArgs e)
		{
			var response = await Network.GetAsync("Twitter/GetOauthLink");
			string responseStr = await response.Content.ReadAsStringAsync();
			var content = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseStr);

			//Check uri exists
			if (!content.ContainsKey("uri") || !content["uri"].StartsWith("https://")) return;
			System.Diagnostics.Process.Start(content["uri"]);
		}

		private async void twitterUserSave_Click(object sender, EventArgs e)
		{
			long twitterId = ((TwitterUser)existingTwitterUsers.SelectedValue).TwitterUserId;
			var values = new Dictionary<string, string>()
			{
				{ "tweetTemplate", tweetTemplate.Text }
			};

			var response = await Network.PostFormAsync($"Twitter/{twitterId}/SetTweetTemplate", values);

			statusLabel.Text = response.IsSuccessStatusCode ? "Status: Successfully updated template tweet" : 
				$"Status: An error occured - {response.StatusCode}";
		}

		private void twitterUserDelete_Click(object sender, EventArgs e)
		{

		}

		private async void refreshAll_Click(object sender, EventArgs e)
		{
			await RefreshTwitterUsers();
		}

		private void existingTwitterUsers_SelectedIndexChanged(object sender, EventArgs e)
		{
			TwitterUser selectedUser = (TwitterUser)existingTwitterUsers.SelectedValue;
			tweetTemplate.Text = selectedUser.TweetTemplate;
		}
	}
}
