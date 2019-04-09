using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SocialMediaBotManager.Models;

namespace SocialMediaBotManager.Forms
{
	public partial class LoginWindow : Form
	{
		public LoginWindow()
		{
			InitializeComponent();
		}

		private async void loginBtn_Click(object sender, EventArgs e)
		{
			//Send the login request and get whether it was successful
			bool success = await Auth.Login(usernameTextbox.Text, passwordTextbox.Text);

			//If login failed
			if (!success)
			{
				//Set the status label to say the login faied
				statusLabel.Text = "Status: Login failed";
				return;
			}

			//Hide the login window
			this.Hide();
			//Initialize the main window
			var mainWindow = new MainWindow();
			//Set the main window to close the application on close
			mainWindow.Closed += (s, args) => this.Close();
			//Show the main window
			mainWindow.Show();
		}
	}
}
