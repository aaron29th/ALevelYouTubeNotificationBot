namespace SocialMediaBotManager
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.mainTabControl = new System.Windows.Forms.TabControl();
			this.mainTabPage = new System.Windows.Forms.TabPage();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.youtubeChannelIdLink = new System.Windows.Forms.LinkLabel();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.youtubeTabPage = new System.Windows.Forms.TabPage();
			this.youtubeControl1 = new SocialMediaBotManager.Forms.YoutubeControl();
			this.discordTabPage = new System.Windows.Forms.TabPage();
			this.discordControl1 = new SocialMediaBotManager.Forms.DiscordControl();
			this.twitterTabPage = new System.Windows.Forms.TabPage();
			this.twitterControl1 = new SocialMediaBotManager.Forms.TwitterControl();
			this.label8 = new System.Windows.Forms.Label();
			this.embedVisualizerLink = new System.Windows.Forms.LinkLabel();
			this.webhooksIntroLink = new System.Windows.Forms.LinkLabel();
			this.mainTabControl.SuspendLayout();
			this.mainTabPage.SuspendLayout();
			this.youtubeTabPage.SuspendLayout();
			this.discordTabPage.SuspendLayout();
			this.twitterTabPage.SuspendLayout();
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
			this.mainTabControl.Size = new System.Drawing.Size(799, 348);
			this.mainTabControl.TabIndex = 0;
			// 
			// mainTabPage
			// 
			this.mainTabPage.Controls.Add(this.webhooksIntroLink);
			this.mainTabPage.Controls.Add(this.embedVisualizerLink);
			this.mainTabPage.Controls.Add(this.label8);
			this.mainTabPage.Controls.Add(this.label7);
			this.mainTabPage.Controls.Add(this.label6);
			this.mainTabPage.Controls.Add(this.label5);
			this.mainTabPage.Controls.Add(this.youtubeChannelIdLink);
			this.mainTabPage.Controls.Add(this.label4);
			this.mainTabPage.Controls.Add(this.label3);
			this.mainTabPage.Controls.Add(this.label2);
			this.mainTabPage.Controls.Add(this.label1);
			this.mainTabPage.Location = new System.Drawing.Point(4, 22);
			this.mainTabPage.Name = "mainTabPage";
			this.mainTabPage.Size = new System.Drawing.Size(791, 322);
			this.mainTabPage.TabIndex = 3;
			this.mainTabPage.Text = "General";
			this.mainTabPage.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(20, 273);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(277, 25);
			this.label7.TabIndex = 7;
			this.label7.Text = "Created by Aaron Rosser";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(22, 190);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(383, 52);
			this.label6.TabIndex = 6;
			this.label6.Text = resources.GetString("label6.Text");
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(19, 159);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(215, 31);
			this.label5.TabIndex = 5;
			this.label5.Text = "Template strings";
			// 
			// youtubeChannelIdLink
			// 
			this.youtubeChannelIdLink.AutoSize = true;
			this.youtubeChannelIdLink.Location = new System.Drawing.Point(462, 119);
			this.youtubeChannelIdLink.Name = "youtubeChannelIdLink";
			this.youtubeChannelIdLink.Size = new System.Drawing.Size(28, 13);
			this.youtubeChannelIdLink.TabIndex = 4;
			this.youtubeChannelIdLink.TabStop = true;
			this.youtubeChannelIdLink.Text = "here";
			this.youtubeChannelIdLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.youtubeChannelIdLink_LinkClicked);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(22, 93);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(532, 52);
			this.label4.TabIndex = 3;
			this.label4.Text = resources.GetString("label4.Text");
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(19, 58);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(158, 31);
			this.label3.TabIndex = 2;
			this.label3.Text = "Setup steps";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Wide Latin", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(14, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(304, 46);
			this.label2.TabIndex = 1;
			this.label2.Text = "Welcome";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(0, 13);
			this.label1.TabIndex = 0;
			// 
			// youtubeTabPage
			// 
			this.youtubeTabPage.Controls.Add(this.youtubeControl1);
			this.youtubeTabPage.Location = new System.Drawing.Point(4, 22);
			this.youtubeTabPage.Name = "youtubeTabPage";
			this.youtubeTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.youtubeTabPage.Size = new System.Drawing.Size(791, 322);
			this.youtubeTabPage.TabIndex = 0;
			this.youtubeTabPage.Text = "YouTube";
			this.youtubeTabPage.UseVisualStyleBackColor = true;
			// 
			// youtubeControl1
			// 
			this.youtubeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.youtubeControl1.Location = new System.Drawing.Point(3, 3);
			this.youtubeControl1.Name = "youtubeControl1";
			this.youtubeControl1.Size = new System.Drawing.Size(785, 316);
			this.youtubeControl1.TabIndex = 0;
			// 
			// discordTabPage
			// 
			this.discordTabPage.Controls.Add(this.discordControl1);
			this.discordTabPage.Location = new System.Drawing.Point(4, 22);
			this.discordTabPage.Name = "discordTabPage";
			this.discordTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.discordTabPage.Size = new System.Drawing.Size(791, 322);
			this.discordTabPage.TabIndex = 1;
			this.discordTabPage.Text = "Discord";
			this.discordTabPage.UseVisualStyleBackColor = true;
			// 
			// discordControl1
			// 
			this.discordControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.discordControl1.Location = new System.Drawing.Point(3, 3);
			this.discordControl1.Name = "discordControl1";
			this.discordControl1.Size = new System.Drawing.Size(785, 316);
			this.discordControl1.TabIndex = 0;
			// 
			// twitterTabPage
			// 
			this.twitterTabPage.Controls.Add(this.twitterControl1);
			this.twitterTabPage.Location = new System.Drawing.Point(4, 22);
			this.twitterTabPage.Name = "twitterTabPage";
			this.twitterTabPage.Size = new System.Drawing.Size(791, 322);
			this.twitterTabPage.TabIndex = 2;
			this.twitterTabPage.Text = "Twitter";
			this.twitterTabPage.UseVisualStyleBackColor = true;
			// 
			// twitterControl1
			// 
			this.twitterControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.twitterControl1.Location = new System.Drawing.Point(0, 0);
			this.twitterControl1.Name = "twitterControl1";
			this.twitterControl1.Size = new System.Drawing.Size(791, 322);
			this.twitterControl1.TabIndex = 0;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(421, 159);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(161, 31);
			this.label8.TabIndex = 8;
			this.label8.Text = "Helpful links";
			// 
			// embedVisualizerLink
			// 
			this.embedVisualizerLink.AutoSize = true;
			this.embedVisualizerLink.Location = new System.Drawing.Point(424, 203);
			this.embedVisualizerLink.Name = "embedVisualizerLink";
			this.embedVisualizerLink.Size = new System.Drawing.Size(187, 13);
			this.embedVisualizerLink.TabIndex = 9;
			this.embedVisualizerLink.TabStop = true;
			this.embedVisualizerLink.Text = "Discord embedded message visualizer";
			this.embedVisualizerLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.embedVisualizerLink_LinkClicked);
			// 
			// webhooksIntroLink
			// 
			this.webhooksIntroLink.AutoSize = true;
			this.webhooksIntroLink.Location = new System.Drawing.Point(424, 190);
			this.webhooksIntroLink.Name = "webhooksIntroLink";
			this.webhooksIntroLink.Size = new System.Drawing.Size(127, 13);
			this.webhooksIntroLink.TabIndex = 10;
			this.webhooksIntroLink.TabStop = true;
			this.webhooksIntroLink.Text = "Discord - Webhooks intro";
			this.webhooksIntroLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.webhooksIntroLink_LinkClicked);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(799, 348);
			this.Controls.Add(this.mainTabControl);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainWindow";
			this.Text = "Social media bot manager";
			this.mainTabControl.ResumeLayout(false);
			this.mainTabPage.ResumeLayout(false);
			this.mainTabPage.PerformLayout();
			this.youtubeTabPage.ResumeLayout(false);
			this.discordTabPage.ResumeLayout(false);
			this.twitterTabPage.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl mainTabControl;
		private System.Windows.Forms.TabPage youtubeTabPage;
		private Forms.YoutubeControl youtubeControl1;
		private System.Windows.Forms.TabPage discordTabPage;
		private System.Windows.Forms.TabPage twitterTabPage;
		private System.Windows.Forms.TabPage mainTabPage;
		private Forms.DiscordControl discordControl1;
		private Forms.TwitterControl twitterControl1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.LinkLabel youtubeChannelIdLink;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.LinkLabel webhooksIntroLink;
		private System.Windows.Forms.LinkLabel embedVisualizerLink;
		private System.Windows.Forms.Label label8;
	}
}

