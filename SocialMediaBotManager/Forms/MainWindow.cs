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

namespace SocialMediaBotManager
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();
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
	}
}
