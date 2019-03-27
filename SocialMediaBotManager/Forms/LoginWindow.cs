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
			bool success = await Auth.Login(usernameTextbox.Text, 
				passwordTextbox.Text);

			if (!success)
			{
				statusLabel.Text = "Status: Login failed";
				return;
			}

			this.Hide();
			var mainWindow = new MainWindow();
			mainWindow.Closed += (s, args) => this.Close();
			mainWindow.Show();
		}
	}
}
