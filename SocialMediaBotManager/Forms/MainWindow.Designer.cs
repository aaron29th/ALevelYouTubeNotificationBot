﻿namespace SocialMediaBotManager
{
	partial class MainWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mainTabControl = new System.Windows.Forms.TabControl();
			this.youtubeTabPage = new System.Windows.Forms.TabPage();
			this.discordTabPage = new System.Windows.Forms.TabPage();
			this.twitterTabPage = new System.Windows.Forms.TabPage();
			this.youtubeControl1 = new SocialMediaBotManager.Forms.YoutubeControl();
			this.discordControl1 = new SocialMediaBotManager.Forms.DiscordControl();
			this.twitterControl1 = new SocialMediaBotManager.Forms.TwitterControl();
			this.mainTabPage = new System.Windows.Forms.TabPage();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.mainTabControl.SuspendLayout();
			this.youtubeTabPage.SuspendLayout();
			this.discordTabPage.SuspendLayout();
			this.twitterTabPage.SuspendLayout();
			this.mainTabPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainTabControl
			// 
			this.mainTabControl.Controls.Add(this.mainTabPage);
			this.mainTabControl.Controls.Add(this.youtubeTabPage);
			this.mainTabControl.Controls.Add(this.discordTabPage);
			this.mainTabControl.Controls.Add(this.twitterTabPage);
			this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainTabControl.Location = new System.Drawing.Point(0, 0);
			this.mainTabControl.Name = "mainTabControl";
			this.mainTabControl.SelectedIndex = 0;
			this.mainTabControl.Size = new System.Drawing.Size(480, 348);
			this.mainTabControl.TabIndex = 0;
			// 
			// youtubeTabPage
			// 
			this.youtubeTabPage.Controls.Add(this.youtubeControl1);
			this.youtubeTabPage.Location = new System.Drawing.Point(4, 22);
			this.youtubeTabPage.Name = "youtubeTabPage";
			this.youtubeTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.youtubeTabPage.Size = new System.Drawing.Size(472, 322);
			this.youtubeTabPage.TabIndex = 0;
			this.youtubeTabPage.Text = "Youtube";
			this.youtubeTabPage.UseVisualStyleBackColor = true;
			// 
			// discordTabPage
			// 
			this.discordTabPage.Controls.Add(this.discordControl1);
			this.discordTabPage.Location = new System.Drawing.Point(4, 22);
			this.discordTabPage.Name = "discordTabPage";
			this.discordTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.discordTabPage.Size = new System.Drawing.Size(472, 322);
			this.discordTabPage.TabIndex = 1;
			this.discordTabPage.Text = "Discord";
			this.discordTabPage.UseVisualStyleBackColor = true;
			// 
			// twitterTabPage
			// 
			this.twitterTabPage.Controls.Add(this.twitterControl1);
			this.twitterTabPage.Location = new System.Drawing.Point(4, 22);
			this.twitterTabPage.Name = "twitterTabPage";
			this.twitterTabPage.Size = new System.Drawing.Size(472, 322);
			this.twitterTabPage.TabIndex = 2;
			this.twitterTabPage.Text = "Twitter";
			this.twitterTabPage.UseVisualStyleBackColor = true;
			// 
			// youtubeControl1
			// 
			this.youtubeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.youtubeControl1.Location = new System.Drawing.Point(3, 3);
			this.youtubeControl1.Name = "youtubeControl1";
			this.youtubeControl1.Size = new System.Drawing.Size(466, 316);
			this.youtubeControl1.TabIndex = 0;
			// 
			// discordControl1
			// 
			this.discordControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.discordControl1.Location = new System.Drawing.Point(3, 3);
			this.discordControl1.Name = "discordControl1";
			this.discordControl1.Size = new System.Drawing.Size(466, 316);
			this.discordControl1.TabIndex = 0;
			// 
			// twitterControl1
			// 
			this.twitterControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.twitterControl1.Location = new System.Drawing.Point(0, 0);
			this.twitterControl1.Name = "twitterControl1";
			this.twitterControl1.Size = new System.Drawing.Size(472, 322);
			this.twitterControl1.TabIndex = 0;
			// 
			// mainTabPage
			// 
			this.mainTabPage.Controls.Add(this.label1);
			this.mainTabPage.Controls.Add(this.textBox1);
			this.mainTabPage.Location = new System.Drawing.Point(4, 22);
			this.mainTabPage.Name = "mainTabPage";
			this.mainTabPage.Size = new System.Drawing.Size(472, 322);
			this.mainTabPage.TabIndex = 3;
			this.mainTabPage.Text = "General";
			this.mainTabPage.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 25);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(456, 50);
			this.textBox1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Token";
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(480, 348);
			this.Controls.Add(this.mainTabControl);
			this.Name = "MainWindow";
			this.Text = "Social media bot manager";
			this.mainTabControl.ResumeLayout(false);
			this.youtubeTabPage.ResumeLayout(false);
			this.discordTabPage.ResumeLayout(false);
			this.twitterTabPage.ResumeLayout(false);
			this.mainTabPage.ResumeLayout(false);
			this.mainTabPage.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl mainTabControl;
		private System.Windows.Forms.TabPage youtubeTabPage;
		private Forms.YoutubeControl youtubeControl1;
		private System.Windows.Forms.TabPage discordTabPage;
		private System.Windows.Forms.TabPage twitterTabPage;
		private System.Windows.Forms.TabPage mainTabPage;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private Forms.DiscordControl discordControl1;
		private Forms.TwitterControl twitterControl1;
	}
}
