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
			//Send request to get all the twitter users and await the response
			var response = await Network.GetAsync("Twitter/GetAll");

			//Check the request was successful
			if (!response.IsSuccessStatusCode)
			{
				//Output the error code to the status bar
				statusLabel.Text = $"An error occured getting twitter users - {response.StatusCode.ToString()}";
				return;
			}

			//Deserialize the response to a list of twitter users
			var jsonString = await response.Content.ReadAsStringAsync();
			var twitterUsers = JsonConvert.DeserializeObject<List<TwitterUser>>(jsonString);

			//Set the tweet template to nothing
			tweetTemplate.Text = "";
			//Update the list of twitter users
			existingTwitterUsers.DataSource = twitterUsers;
			existingTwitterUsers.DisplayMember = "Name";

			//Enable / disable save and delete buttons
			twitterUserSave.Enabled = twitterUsers.Count > 0;
			twitterUserDelete.Enabled = twitterUsers.Count > 0;
		}

		private async void openTwitterOauth_Click(object sender, EventArgs e)
		{
			//Send the request to get a twitter oauth link
			var response = await Network.GetAsync("Twitter/GetOauthLink");
			
			//Deserialize the response body
			string responseStr = await response.Content.ReadAsStringAsync();
			var content = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseStr);

			//Check uri exists
			if (!content.ContainsKey("uri") || !content["uri"].StartsWith("https://")) return;
			//Open the oauth link in the default browser
			System.Diagnostics.Process.Start(content["uri"]);
		}

		private async void twitterUserSave_Click(object sender, EventArgs e)
		{
			//Get the selected twitter user's id
			long twitterId = ((TwitterUser)existingTwitterUsers.SelectedValue).TwitterUserId;
			//Create the post request's body
			var values = new Dictionary<string, string>()
			{
				{ "tweetTemplate", tweetTemplate.Text }
			};
			//Send the post request and await its response
			var response = await Network.PostFormAsync($"Twitter/{twitterId}/SetTweetTemplate", values);

			//Output the result to the status bar
			statusLabel.Text = response.IsSuccessStatusCode ? "Status: Successfully updated template tweet" : 
				$"Status: An error occured - {response.StatusCode}";
		}

		private async void twitterUserDelete_Click(object sender, EventArgs e)
		{
			//Ask the user if they are sure they want to delete the twitter user
			var dialogResult = MessageBox.Show("Are you sure you wish to delete the selected twitter user?",
				"Delete twitter user", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (dialogResult == DialogResult.No)
			{
				statusLabel.Text = "Deletion cancelled";
				return;
			}

			//Gets the selected twitter user's id
			long twitterId = ((TwitterUser)existingTwitterUsers.SelectedValue).TwitterUserId;

			//Sends a delete request to the server and awaits its response
			var response = await Network.DeleteAsync($"Twitter/{twitterId}");

			//Output the result to the status bar
			statusLabel.Text = response.IsSuccessStatusCode ? "Status: Successfully deleted twitter user" :
				$"Status: An error occured deleting twitter user - {response.StatusCode}";
			//Refresh the twitter users
			await RefreshTwitterUsers();
		}

		private async void refreshAll_Click(object sender, EventArgs e)
		{
			//Refresh the twitter users
			await RefreshTwitterUsers();
		}

		private void existingTwitterUsers_SelectedIndexChanged(object sender, EventArgs e)
		{
			//Get the selected twitter user
			TwitterUser selectedUser = (TwitterUser)existingTwitterUsers.SelectedValue;
			//Set the tweet template text box to the twitter users tweet template
			tweetTemplate.Text = selectedUser.TweetTemplate;
		}
	}
}
