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
			this.webhooksIntroLink = new System.Windows.Forms.LinkLabel();
			this.embedVisualizerLink = new System.Windows.Forms.LinkLabel();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.youtubeChannelIdLink = new System.Windows.Forms.LinkLabel();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.youtubeTabPage = new System.Windows.Forms.TabPage();
			this.discordTabPage = new System.Windows.Forms.TabPage();
			this.twitterTabPage = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.currentPassword = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.newPassword = new System.Windows.Forms.TextBox();
			this.newPasswordRepeat = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.changePassword = new System.Windows.Forms.Button();
			this.youtubeChannelIdLink2 = new System.Windows.Forms.LinkLabel();
			this.youtubeControl1 = new SocialMediaBotManager.Forms.YoutubeControl();
			this.discordControl1 = new SocialMediaBotManager.Forms.DiscordControl();
			this.twitterControl1 = new SocialMediaBotManager.Forms.TwitterControl();
			this.twitterApplicationsPage = new System.Windows.Forms.LinkLabel();
			this.mainTabControl.SuspendLayout();
			this.mainTabPage.SuspendLayout();
			this.youtubeTabPage.SuspendLayout();
			this.discordTabPage.SuspendLayout();
			this.twitterTabPage.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
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
			this.mainTabPage.Controls.Add(this.groupBox4);
			this.mainTabPage.Controls.Add(this.groupBox3);
			this.mainTabPage.Controls.Add(this.label7);
			this.mainTabPage.Controls.Add(this.groupBox2);
			this.mainTabPage.Controls.Add(this.groupBox1);
			this.mainTabPage.Controls.Add(this.label2);
			this.mainTabPage.Controls.Add(this.label1);
			this.mainTabPage.Location = new System.Drawing.Point(4, 22);
			this.mainTabPage.Name = "mainTabPage";
			this.mainTabPage.Size = new System.Drawing.Size(791, 322);
			this.mainTabPage.TabIndex = 3;
			this.mainTabPage.Text = "General";
			this.mainTabPage.UseVisualStyleBackColor = true;
			// 
			// webhooksIntroLink
			// 
			this.webhooksIntroLink.AutoSize = true;
			this.webhooksIntroLink.Location = new System.Drawing.Point(6, 16);
			this.webhooksIntroLink.Name = "webhooksIntroLink";
			this.webhooksIntroLink.Size = new System.Drawing.Size(127, 13);
			this.webhooksIntroLink.TabIndex = 10;
			this.webhooksIntroLink.TabStop = true;
			this.webhooksIntroLink.Text = "Discord - Webhooks intro";
			this.webhooksIntroLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.webhooksIntroLink_LinkClicked);
			// 
			// embedVisualizerLink
			// 
			this.embedVisualizerLink.AutoSize = true;
			this.embedVisualizerLink.Location = new System.Drawing.Point(6, 32);
			this.embedVisualizerLink.Name = "embedVisualizerLink";
			this.embedVisualizerLink.Size = new System.Drawing.Size(194, 13);
			this.embedVisualizerLink.TabIndex = 9;
			this.embedVisualizerLink.TabStop = true;
			this.embedVisualizerLink.Text = "Discord - Embedded message visualizer";
			this.embedVisualizerLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.embedVisualizerLink_LinkClicked);
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(605, 285);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(183, 32);
			this.label7.TabIndex = 7;
			this.label7.Text = "Created by Aaron Rosser\r\nVersion 1.0.0";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 17);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(383, 52);
			this.label6.TabIndex = 6;
			this.label6.Text = resources.GetString("label6.Text");
			// 
			// youtubeChannelIdLink
			// 
			this.youtubeChannelIdLink.AutoSize = true;
			this.youtubeChannelIdLink.Location = new System.Drawing.Point(442, 41);
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
			this.label4.Location = new System.Drawing.Point(6, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(532, 52);
			this.label4.TabIndex = 3;
			this.label4.Text = resources.GetString("label4.Text");
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(185, 43);
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
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.twitterApplicationsPage);
			this.groupBox1.Controls.Add(this.youtubeChannelIdLink2);
			this.groupBox1.Controls.Add(this.embedVisualizerLink);
			this.groupBox1.Controls.Add(this.webhooksIntroLink);
			this.groupBox1.Location = new System.Drawing.Point(8, 221);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(542, 82);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Helpful links";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Location = new System.Drawing.Point(8, 133);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(542, 82);
			this.groupBox2.TabIndex = 13;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Template strings";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.youtubeChannelIdLink);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Location = new System.Drawing.Point(8, 46);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(542, 81);
			this.groupBox3.TabIndex = 14;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Setup steps";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.changePassword);
			this.groupBox4.Controls.Add(this.label8);
			this.groupBox4.Controls.Add(this.label5);
			this.groupBox4.Controls.Add(this.newPasswordRepeat);
			this.groupBox4.Controls.Add(this.newPassword);
			this.groupBox4.Controls.Add(this.label3);
			this.groupBox4.Controls.Add(this.currentPassword);
			this.groupBox4.Location = new System.Drawing.Point(556, 46);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(200, 169);
			this.groupBox4.TabIndex = 15;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Change password";
			// 
			// currentPassword
			// 
			this.currentPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.currentPassword.Location = new System.Drawing.Point(9, 31);
			this.currentPassword.Name = "currentPassword";
			this.currentPassword.PasswordChar = '•';
			this.currentPassword.Size = new System.Drawing.Size(185, 20);
			this.currentPassword.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(89, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Current password";
			// 
			// newPassword
			// 
			this.newPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.newPassword.Location = new System.Drawing.Point(9, 72);
			this.newPassword.Name = "newPassword";
			this.newPassword.PasswordChar = '•';
			this.newPassword.Size = new System.Drawing.Size(185, 20);
			this.newPassword.TabIndex = 2;
			// 
			// newPasswordRepeat
			// 
			this.newPasswordRepeat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.newPasswordRepeat.Location = new System.Drawing.Point(9, 111);
			this.newPasswordRepeat.Name = "newPasswordRepeat";
			this.newPasswordRepeat.PasswordChar = '•';
			this.newPasswordRepeat.Size = new System.Drawing.Size(185, 20);
			this.newPasswordRepeat.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 56);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(77, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "New password";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 95);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(112, 13);
			this.label8.TabIndex = 5;
			this.label8.Text = "New password (again)";
			// 
			// changePassword
			// 
			this.changePassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.changePassword.Location = new System.Drawing.Point(9, 137);
			this.changePassword.Name = "changePassword";
			this.changePassword.Size = new System.Drawing.Size(185, 23);
			this.changePassword.TabIndex = 6;
			this.changePassword.Text = "Change password";
			this.changePassword.UseVisualStyleBackColor = true;
			this.changePassword.Click += new System.EventHandler(this.changePassword_Click);
			// 
			// youtubeChannelIdLink2
			// 
			this.youtubeChannelIdLink2.AutoSize = true;
			this.youtubeChannelIdLink2.Location = new System.Drawing.Point(6, 48);
			this.youtubeChannelIdLink2.Name = "youtubeChannelIdLink2";
			this.youtubeChannelIdLink2.Size = new System.Drawing.Size(136, 13);
			this.youtubeChannelIdLink2.TabIndex = 11;
			this.youtubeChannelIdLink2.TabStop = true;
			this.youtubeChannelIdLink2.Text = "YouTube - channel id page";
			this.youtubeChannelIdLink2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.youtubeChannelIdLink2_LinkClicked);
			// 
			// youtubeControl1
			// 
			this.youtubeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.youtubeControl1.Location = new System.Drawing.Point(3, 3);
			this.youtubeControl1.Name = "youtubeControl1";
			this.youtubeControl1.Size = new System.Drawing.Size(785, 316);
			this.youtubeControl1.TabIndex = 0;
			// 
			// discordControl1
			// 
			this.discordControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.discordControl1.Location = new System.Drawing.Point(3, 3);
			this.discordControl1.Name = "discordControl1";
			this.discordControl1.Size = new System.Drawing.Size(785, 316);
			this.discordControl1.TabIndex = 0;
			// 
			// twitterControl1
			// 
			this.twitterControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.twitterControl1.Location = new System.Drawing.Point(0, 0);
			this.twitterControl1.Name = "twitterControl1";
			this.twitterControl1.Size = new System.Drawing.Size(791, 322);
			this.twitterControl1.TabIndex = 0;
			// 
			// twitterApplicationsPage
			// 
			this.twitterApplicationsPage.AutoSize = true;
			this.twitterApplicationsPage.Location = new System.Drawing.Point(224, 16);
			this.twitterApplicationsPage.Name = "twitterApplicationsPage";
			this.twitterApplicationsPage.Size = new System.Drawing.Size(158, 13);
			this.twitterApplicationsPage.TabIndex = 12;
			this.twitterApplicationsPage.TabStop = true;
			this.twitterApplicationsPage.Text = "Twitter - authorizied applications";
			this.twitterApplicationsPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.twitterApplicationsPage_LinkClicked);
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
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
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
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.LinkLabel webhooksIntroLink;
		private System.Windows.Forms.LinkLabel embedVisualizerLink;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button changePassword;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox newPasswordRepeat;
		private System.Windows.Forms.TextBox newPassword;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox currentPassword;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.LinkLabel youtubeChannelIdLink2;
		private System.Windows.Forms.LinkLabel twitterApplicationsPage;
	}
}

