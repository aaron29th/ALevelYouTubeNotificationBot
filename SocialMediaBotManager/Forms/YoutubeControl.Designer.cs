﻿namespace SocialMediaBotManager.Forms
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
			this.youtubeChannelId = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.webhooksListbox = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.twitterUsersListbox = new System.Windows.Forms.ListBox();
			this.webhookUnlinkSubscription = new System.Windows.Forms.Button();
			this.twitterUnlinkSubscription = new System.Windows.Forms.Button();
			this.twitterLinkSubscription = new System.Windows.Forms.Button();
			this.subscriptionAddNew = new System.Windows.Forms.Button();
			this.refreshAll = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.subscriptionDelete = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// webhookLinkSubscription
			// 
			this.webhookLinkSubscription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.webhookLinkSubscription.Enabled = false;
			this.webhookLinkSubscription.Location = new System.Drawing.Point(9, 19);
			this.webhookLinkSubscription.Name = "webhookLinkSubscription";
			this.webhookLinkSubscription.Size = new System.Drawing.Size(169, 23);
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
			this.subscriptions.Size = new System.Drawing.Size(180, 147);
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
			// youtubeChannelId
			// 
			this.youtubeChannelId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.youtubeChannelId.Location = new System.Drawing.Point(10, 32);
			this.youtubeChannelId.Name = "youtubeChannelId";
			this.youtubeChannelId.Size = new System.Drawing.Size(500, 20);
			this.youtubeChannelId.TabIndex = 3;
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
			this.webhooksListbox.Location = new System.Drawing.Point(192, 35);
			this.webhooksListbox.Name = "webhooksListbox";
			this.webhooksListbox.Size = new System.Drawing.Size(124, 173);
			this.webhooksListbox.TabIndex = 5;
			this.webhooksListbox.SelectedIndexChanged += new System.EventHandler(this.webhooksListbox_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(189, 20);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Webhooks";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(319, 21);
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
			this.twitterUsersListbox.Location = new System.Drawing.Point(322, 36);
			this.twitterUsersListbox.Name = "twitterUsersListbox";
			this.twitterUsersListbox.Size = new System.Drawing.Size(125, 173);
			this.twitterUsersListbox.TabIndex = 7;
			this.twitterUsersListbox.SelectedIndexChanged += new System.EventHandler(this.twitterAccountsListbox_SelectedIndexChanged);
			// 
			// webhookUnlinkSubscription
			// 
			this.webhookUnlinkSubscription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.webhookUnlinkSubscription.Enabled = false;
			this.webhookUnlinkSubscription.Location = new System.Drawing.Point(9, 48);
			this.webhookUnlinkSubscription.Name = "webhookUnlinkSubscription";
			this.webhookUnlinkSubscription.Size = new System.Drawing.Size(169, 23);
			this.webhookUnlinkSubscription.TabIndex = 13;
			this.webhookUnlinkSubscription.Text = "Unlink from subscription";
			this.webhookUnlinkSubscription.UseVisualStyleBackColor = true;
			this.webhookUnlinkSubscription.Click += new System.EventHandler(this.webhookUnlinkSubscription_Click);
			// 
			// twitterUnlinkSubscription
			// 
			this.twitterUnlinkSubscription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.twitterUnlinkSubscription.Enabled = false;
			this.twitterUnlinkSubscription.Location = new System.Drawing.Point(9, 48);
			this.twitterUnlinkSubscription.Name = "twitterUnlinkSubscription";
			this.twitterUnlinkSubscription.Size = new System.Drawing.Size(169, 23);
			this.twitterUnlinkSubscription.TabIndex = 15;
			this.twitterUnlinkSubscription.Text = "Unlink from subscription";
			this.twitterUnlinkSubscription.UseVisualStyleBackColor = true;
			this.twitterUnlinkSubscription.Click += new System.EventHandler(this.twitterUnlinkSubscription_Click);
			// 
			// twitterLinkSubscription
			// 
			this.twitterLinkSubscription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.twitterLinkSubscription.Enabled = false;
			this.twitterLinkSubscription.Location = new System.Drawing.Point(9, 19);
			this.twitterLinkSubscription.Name = "twitterLinkSubscription";
			this.twitterLinkSubscription.Size = new System.Drawing.Size(169, 23);
			this.twitterLinkSubscription.TabIndex = 14;
			this.twitterLinkSubscription.Text = "Link to subscription";
			this.twitterLinkSubscription.UseVisualStyleBackColor = true;
			this.twitterLinkSubscription.Click += new System.EventHandler(this.twitterLinkSubscription_Click);
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
			// refreshAll
			// 
			this.refreshAll.Location = new System.Drawing.Point(6, 16);
			this.refreshAll.Name = "refreshAll";
			this.refreshAll.Size = new System.Drawing.Size(180, 23);
			this.refreshAll.TabIndex = 18;
			this.refreshAll.Text = "Refresh";
			this.refreshAll.UseVisualStyleBackColor = true;
			this.refreshAll.Click += new System.EventHandler(this.refreshAll_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.youtubeChannelId);
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
			this.groupBox2.Controls.Add(this.statusStrip1);
			this.groupBox2.Controls.Add(this.subscriptionDelete);
			this.groupBox2.Controls.Add(this.groupBox4);
			this.groupBox2.Controls.Add(this.groupBox3);
			this.groupBox2.Controls.Add(this.refreshAll);
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
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
			this.statusStrip1.Location = new System.Drawing.Point(3, 224);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(648, 22);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 22;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// statusLabel
			// 
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(64, 17);
			this.statusLabel.Text = "Status: Idle";
			// 
			// subscriptionDelete
			// 
			this.subscriptionDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.subscriptionDelete.Enabled = false;
			this.subscriptionDelete.Location = new System.Drawing.Point(466, 189);
			this.subscriptionDelete.Name = "subscriptionDelete";
			this.subscriptionDelete.Size = new System.Drawing.Size(169, 23);
			this.subscriptionDelete.TabIndex = 21;
			this.subscriptionDelete.Text = "Unsubscribe";
			this.subscriptionDelete.UseVisualStyleBackColor = true;
			this.subscriptionDelete.Click += new System.EventHandler(this.subscriptionDelete_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.twitterLinkSubscription);
			this.groupBox4.Controls.Add(this.twitterUnlinkSubscription);
			this.groupBox4.Location = new System.Drawing.Point(457, 102);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(191, 81);
			this.groupBox4.TabIndex = 20;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Twitter user";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.webhookLinkSubscription);
			this.groupBox3.Controls.Add(this.webhookUnlinkSubscription);
			this.groupBox3.Location = new System.Drawing.Point(457, 16);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(191, 79);
			this.groupBox3.TabIndex = 19;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Webhook";
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
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button webhookLinkSubscription;
		private System.Windows.Forms.ListBox subscriptions;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox youtubeChannelId;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox webhooksListbox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ListBox twitterUsersListbox;
		private System.Windows.Forms.Button webhookUnlinkSubscription;
		private System.Windows.Forms.Button twitterUnlinkSubscription;
		private System.Windows.Forms.Button twitterLinkSubscription;
		private System.Windows.Forms.Button subscriptionAddNew;
		private System.Windows.Forms.Button refreshAll;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button subscriptionDelete;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel statusLabel;
	}
}
