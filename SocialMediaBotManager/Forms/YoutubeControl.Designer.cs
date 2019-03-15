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
			this.twitterAccountsListbox = new System.Windows.Forms.ListBox();
			this.webhookId = new System.Windows.Forms.TextBox();
			this.twitterAccountToken = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.webhookUnlinkSubscription = new System.Windows.Forms.Button();
			this.twitterUnlinkSubscription = new System.Windows.Forms.Button();
			this.twitterLinkSubscription = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.subscriptionAddNew = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// webhookLinkSubscription
			// 
			this.webhookLinkSubscription.Location = new System.Drawing.Point(402, 64);
			this.webhookLinkSubscription.Name = "webhookLinkSubscription";
			this.webhookLinkSubscription.Size = new System.Drawing.Size(213, 23);
			this.webhookLinkSubscription.TabIndex = 0;
			this.webhookLinkSubscription.Text = "Link to subscription";
			this.webhookLinkSubscription.UseVisualStyleBackColor = true;
			this.webhookLinkSubscription.Click += new System.EventHandler(this.webhookLinkSubscription_Click);
			// 
			// subscriptions
			// 
			this.subscriptions.FormattingEnabled = true;
			this.subscriptions.Location = new System.Drawing.Point(6, 22);
			this.subscriptions.Name = "subscriptions";
			this.subscriptions.Size = new System.Drawing.Size(125, 238);
			this.subscriptions.TabIndex = 1;
			this.subscriptions.SelectedIndexChanged += new System.EventHandler(this.subscriptions_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Existing subscriptions";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(140, 22);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(125, 20);
			this.textBox1.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(137, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Channel Id";
			// 
			// webhooksListbox
			// 
			this.webhooksListbox.FormattingEnabled = true;
			this.webhooksListbox.Location = new System.Drawing.Point(140, 61);
			this.webhooksListbox.Name = "webhooksListbox";
			this.webhooksListbox.Size = new System.Drawing.Size(125, 199);
			this.webhooksListbox.TabIndex = 5;
			this.webhooksListbox.SelectedIndexChanged += new System.EventHandler(this.webhooksListbox_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(137, 45);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Linked discord webhooks";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(268, 45);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(117, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Linked twitter accounts";
			// 
			// twitterAccountsListbox
			// 
			this.twitterAccountsListbox.FormattingEnabled = true;
			this.twitterAccountsListbox.Location = new System.Drawing.Point(271, 61);
			this.twitterAccountsListbox.Name = "twitterAccountsListbox";
			this.twitterAccountsListbox.Size = new System.Drawing.Size(125, 199);
			this.twitterAccountsListbox.TabIndex = 7;
			this.twitterAccountsListbox.SelectedIndexChanged += new System.EventHandler(this.twitterAccountsListbox_SelectedIndexChanged);
			// 
			// webhookId
			// 
			this.webhookId.Location = new System.Drawing.Point(402, 22);
			this.webhookId.Multiline = true;
			this.webhookId.Name = "webhookId";
			this.webhookId.Size = new System.Drawing.Size(213, 36);
			this.webhookId.TabIndex = 9;
			// 
			// twitterAccountToken
			// 
			this.twitterAccountToken.Location = new System.Drawing.Point(402, 135);
			this.twitterAccountToken.Multiline = true;
			this.twitterAccountToken.Name = "twitterAccountToken";
			this.twitterAccountToken.Size = new System.Drawing.Size(213, 67);
			this.twitterAccountToken.TabIndex = 10;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(399, 6);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(101, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "Discord webhook id";
			// 
			// webhookUnlinkSubscription
			// 
			this.webhookUnlinkSubscription.Location = new System.Drawing.Point(402, 93);
			this.webhookUnlinkSubscription.Name = "webhookUnlinkSubscription";
			this.webhookUnlinkSubscription.Size = new System.Drawing.Size(213, 23);
			this.webhookUnlinkSubscription.TabIndex = 13;
			this.webhookUnlinkSubscription.Text = "Unlink to subscription";
			this.webhookUnlinkSubscription.UseVisualStyleBackColor = true;
			this.webhookUnlinkSubscription.Click += new System.EventHandler(this.webhookUnlinkSubscription_Click);
			// 
			// twitterUnlinkSubscription
			// 
			this.twitterUnlinkSubscription.Location = new System.Drawing.Point(402, 237);
			this.twitterUnlinkSubscription.Name = "twitterUnlinkSubscription";
			this.twitterUnlinkSubscription.Size = new System.Drawing.Size(213, 23);
			this.twitterUnlinkSubscription.TabIndex = 15;
			this.twitterUnlinkSubscription.Text = "Unlink to subscription";
			this.twitterUnlinkSubscription.UseVisualStyleBackColor = true;
			this.twitterUnlinkSubscription.Click += new System.EventHandler(this.twitterUnlinkSubscription_Click);
			// 
			// twitterLinkSubscription
			// 
			this.twitterLinkSubscription.Location = new System.Drawing.Point(402, 208);
			this.twitterLinkSubscription.Name = "twitterLinkSubscription";
			this.twitterLinkSubscription.Size = new System.Drawing.Size(213, 23);
			this.twitterLinkSubscription.TabIndex = 14;
			this.twitterLinkSubscription.Text = "Link to subscription";
			this.twitterLinkSubscription.UseVisualStyleBackColor = true;
			this.twitterLinkSubscription.Click += new System.EventHandler(this.twitterLinkSubscription_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(402, 119);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(111, 13);
			this.label6.TabIndex = 16;
			this.label6.Text = "Twitter account token";
			// 
			// subscriptionAddNew
			// 
			this.subscriptionAddNew.Location = new System.Drawing.Point(271, 20);
			this.subscriptionAddNew.Name = "subscriptionAddNew";
			this.subscriptionAddNew.Size = new System.Drawing.Size(125, 23);
			this.subscriptionAddNew.TabIndex = 17;
			this.subscriptionAddNew.Text = "Add new";
			this.subscriptionAddNew.UseVisualStyleBackColor = true;
			this.subscriptionAddNew.Click += new System.EventHandler(this.subscriptionAddNew_Click);
			// 
			// YoutubeControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.subscriptionAddNew);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.twitterUnlinkSubscription);
			this.Controls.Add(this.twitterLinkSubscription);
			this.Controls.Add(this.webhookUnlinkSubscription);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.twitterAccountToken);
			this.Controls.Add(this.webhookId);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.twitterAccountsListbox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.webhooksListbox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.subscriptions);
			this.Controls.Add(this.webhookLinkSubscription);
			this.Name = "YoutubeControl";
			this.Size = new System.Drawing.Size(629, 274);
			this.ResumeLayout(false);
			this.PerformLayout();

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
		private System.Windows.Forms.ListBox twitterAccountsListbox;
		private System.Windows.Forms.TextBox webhookId;
		private System.Windows.Forms.TextBox twitterAccountToken;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button webhookUnlinkSubscription;
		private System.Windows.Forms.Button twitterUnlinkSubscription;
		private System.Windows.Forms.Button twitterLinkSubscription;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button subscriptionAddNew;
	}
}
