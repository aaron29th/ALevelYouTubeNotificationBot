using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SocialMediaBotManager.Models;

namespace SocialMediaBotManager
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private async void changePassword_Click(object sender, EventArgs e)
		{
			//Check the new password was repeated correctly
			if (newPassword.Text != newPasswordRepeat.Text)
			{
				//Show a message box to say the fields do no match
				MessageBox.Show("The new password fields must match", "New password fields do not match",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				//Clear the new password textboxes
				newPassword.Text = "";
				newPasswordRepeat.Text = "";
				return;
			}

			//Attempt to change the user's password
			if (await Auth.ChangePassword(currentPassword.Text, newPassword.Text))
			{
				//Clear the textboxes
				currentPassword.Text = "";
				newPassword.Text = "";
				newPasswordRepeat.Text = "";
				//SHow a success message box
				MessageBox.Show("Password successfully updated", "Success", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("Current password is incorrect", "Change password failed", 
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void youtubeChannelIdLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://www.youtube.com/account_advanced");
			((LinkLabel) sender).LinkVisited = true;
		}

		private void webhooksIntroLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://support.discordapp.com/hc/en-us/articles/228383668-Intro-to-Webhooks");
			((LinkLabel)sender).LinkVisited = true;
		}

		private void embedVisualizerLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://leovoel.github.io/embed-visualizer/");
			((LinkLabel)sender).LinkVisited = true;
		}

		private void youtubeChannelIdLink2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://www.youtube.com/account_advanced");
			((LinkLabel)sender).LinkVisited = true;
		}

		private void twitterApplicationsPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://twitter.com/settings/applications");
			((LinkLabel)sender).LinkVisited = true;
		}
	}
}
