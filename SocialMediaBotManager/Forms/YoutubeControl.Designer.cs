namespace SocialMediaBotManager.Forms
{
	partial class YoutubeControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.webhookLinkSubscription = new System.Windows.Forms.Button();
			this.subscriptions = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.webhooksListbox = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.twitterUsersListbox = new System.Windows.Forms.ListBox();
			this.label5 = new System.Windows.Forms.Label();
			this.webhookUnlinkSubscription = new System.Windows.Forms.Button();
			this.twitterUnlinkSubscription = new System.Windows.Forms.Button();
			this.twitterLinkSubscription = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.subscriptionAddNew = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.discordWebhookId = new System.Windows.Forms.TextBox();
			this.twitterUserId = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// webhookLinkSubscription
			// 
			this.webhookLinkSubscription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.webhookLinkSubscription.Location = new System.Drawing.Point(9, 45);
			this.webhookLinkSubscription.Name = "webhookLinkSubscription";
			this.webhookLinkSubscription.Size = new System.Drawing.Size(217, 23);
			this.webhookLinkSubscription.TabIndex = 0;
			this.webhookLinkSubscription.Text = "Link to subscription";
			this.webhookLinkSubscription.UseVisualStyleBackColor = true;
			this.webhookLinkSubscription.Click += new System.EventHandler(this.webhookLinkSubscription_Click);
			// 
			// subscriptions
			// 
			this.subscriptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.subscriptions.FormattingEnabled = true;
			this.subscriptions.Location = new System.Drawing.Point(6, 62);
			this.subscriptions.Name = "subscriptions";
			this.subscriptions.Size = new System.Drawing.Size(125, 173);
			this.subscriptions.TabIndex = 1;
			this.subscriptions.SelectedIndexChanged += new System.EventHandler(this.subscriptions_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Existing subscriptions";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(10, 32);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(500, 20);
			this.textBox1.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Channel Id";
			// 
			// webhooksListbox
			// 
			this.webhooksListbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.webhooksListbox.FormattingEnabled = true;
			this.webhooksListbox.Location = new System.Drawing.Point(140, 36);
			this.webhooksListbox.Name = "webhooksListbox";
			this.webhooksListbox.Size = new System.Drawing.Size(125, 199);
			this.webhooksListbox.TabIndex = 5;
			this.webhooksListbox.SelectedIndexChanged += new System.EventHandler(this.webhooksListbox_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(137, 21);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Webhooks";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(272, 21);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(67, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Twitter users";
			// 
			// twitterUsersListbox
			// 
			this.twitterUsersListbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.twitterUsersListbox.FormattingEnabled = true;
			this.twitterUsersListbox.Location = new System.Drawing.Point(275, 36);
			this.twitterUsersListbox.Name = "twitterUsersListbox";
			this.twitterUsersListbox.Size = new System.Drawing.Size(125, 199);
			this.twitterUsersListbox.TabIndex = 7;
			this.twitterUsersListbox.SelectedIndexChanged += new System.EventHandler(this.twitterAccountsListbox_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 22);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(16, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "Id";
			// 
			// webhookUnlinkSubscription
			// 
			this.webhookUnlinkSubscription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.webhookUnlinkSubscription.Location = new System.Drawing.Point(9, 74);
			this.webhookUnlinkSubscription.Name = "webhookUnlinkSubscription";
			this.webhookUnlinkSubscription.Size = new System.Drawing.Size(217, 23);
			this.webhookUnlinkSubscription.TabIndex = 13;
			this.webhookUnlinkSubscription.Text = "Unlink from subscription";
			this.webhookUnlinkSubscription.UseVisualStyleBackColor = true;
			this.webhookUnlinkSubscription.Click += new System.EventHandler(this.webhookUnlinkSubscription_Click);
			// 
			// twitterUnlinkSubscription
			// 
			this.twitterUnlinkSubscription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.twitterUnlinkSubscription.Location = new System.Drawing.Point(9, 74);
			this.twitterUnlinkSubscription.Name = "twitterUnlinkSubscription";
			this.twitterUnlinkSubscription.Size = new System.Drawing.Size(217, 23);
			this.twitterUnlinkSubscription.TabIndex = 15;
			this.twitterUnlinkSubscription.Text = "Unlink from subscription";
			this.twitterUnlinkSubscription.UseVisualStyleBackColor = true;
			this.twitterUnlinkSubscription.Click += new System.EventHandler(this.twitterUnlinkSubscription_Click);
			// 
			// twitterLinkSubscription
			// 
			this.twitterLinkSubscription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.twitterLinkSubscription.Location = new System.Drawing.Point(9, 45);
			this.twitterLinkSubscription.Name = "twitterLinkSubscription";
			this.twitterLinkSubscription.Size = new System.Drawing.Size(217, 23);
			this.twitterLinkSubscription.TabIndex = 14;
			this.twitterLinkSubscription.Text = "Link to subscription";
			this.twitterLinkSubscription.UseVisualStyleBackColor = true;
			this.twitterLinkSubscription.Click += new System.EventHandler(this.twitterLinkSubscription_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 22);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(16, 13);
			this.label6.TabIndex = 16;
			this.label6.Text = "Id";
			// 
			// subscriptionAddNew
			// 
			this.subscriptionAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.subscriptionAddNew.Location = new System.Drawing.Point(516, 30);
			this.subscriptionAddNew.Name = "subscriptionAddNew";
			this.subscriptionAddNew.Size = new System.Drawing.Size(125, 23);
			this.subscriptionAddNew.TabIndex = 17;
			this.subscriptionAddNew.Text = "Subscribe";
			this.subscriptionAddNew.UseVisualStyleBackColor = true;
			this.subscriptionAddNew.Click += new System.EventHandler(this.subscriptionAddNew_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(6, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(125, 23);
			this.button1.TabIndex = 18;
			this.button1.Text = "Refresh";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.subscriptionAddNew);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(654, 66);
			this.groupBox1.TabIndex = 19;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Add new";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.groupBox4);
			this.groupBox2.Controls.Add(this.groupBox3);
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.subscriptions);
			this.groupBox2.Controls.Add(this.webhooksListbox);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.twitterUsersListbox);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 66);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(654, 249);
			this.groupBox2.TabIndex = 20;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Edit existing";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.discordWebhookId);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.webhookLinkSubscription);
			this.groupBox3.Controls.Add(this.webhookUnlinkSubscription);
			this.groupBox3.Location = new System.Drawing.Point(409, 16);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(239, 107);
			this.groupBox3.TabIndex = 19;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Webhook";
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.twitterUserId);
			this.groupBox4.Controls.Add(this.label6);
			this.groupBox4.Controls.Add(this.twitterLinkSubscription);
			this.groupBox4.Controls.Add(this.twitterUnlinkSubscription);
			this.groupBox4.Location = new System.Drawing.Point(409, 129);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(239, 107);
			this.groupBox4.TabIndex = 20;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Twitter user";
			// 
			// discordWebhookId
			// 
			this.discordWebhookId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.discordWebhookId.Location = new System.Drawing.Point(28, 19);
			this.discordWebhookId.Name = "discordWebhookId";
			this.discordWebhookId.Size = new System.Drawing.Size(198, 20);
			this.discordWebhookId.TabIndex = 18;
			// 
			// twitterUserId
			// 
			this.twitterUserId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.twitterUserId.Location = new System.Drawing.Point(28, 19);
			this.twitterUserId.Name = "twitterUserId";
			this.twitterUserId.Size = new System.Drawing.Size(198, 20);
			this.twitterUserId.TabIndex = 19;
			// 
			// YoutubeControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "YoutubeControl";
			this.Size = new System.Drawing.Size(654, 315);
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

		private System.Windows.Forms.Button webhookLinkSubscription;
		private System.Windows.Forms.ListBox subscriptions;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox webhooksListbox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ListBox twitterUsersListbox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button webhookUnlinkSubscription;
		private System.Windows.Forms.Button twitterUnlinkSubscription;
		private System.Windows.Forms.Button twitterLinkSubscription;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button subscriptionAddNew;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox twitterUserId;
		private System.Windows.Forms.TextBox discordWebhookId;
	}
}
