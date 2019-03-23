namespace SocialMediaBotManager.Forms
{
	partial class DiscordControl
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
			this.webhookUrl = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.webhookAdd = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.embedTemplate = new System.Windows.Forms.TextBox();
			this.webhookDelete = new System.Windows.Forms.Button();
			this.webhookSave = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.messageTemplate = new System.Windows.Forms.TextBox();
			this.existingWebhooks = new System.Windows.Forms.ListBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// webhookUrl
			// 
			this.webhookUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.webhookUrl.Location = new System.Drawing.Point(9, 35);
			this.webhookUrl.Name = "webhookUrl";
			this.webhookUrl.Size = new System.Drawing.Size(486, 20);
			this.webhookUrl.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.webhookAdd);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.webhookUrl);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(586, 69);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Add new";
			// 
			// webhookAdd
			// 
			this.webhookAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.webhookAdd.Location = new System.Drawing.Point(501, 33);
			this.webhookAdd.Name = "webhookAdd";
			this.webhookAdd.Size = new System.Drawing.Size(75, 23);
			this.webhookAdd.TabIndex = 2;
			this.webhookAdd.Text = "Add";
			this.webhookAdd.UseVisualStyleBackColor = true;
			this.webhookAdd.Click += new System.EventHandler(this.webhookAdd_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Webhook URL";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.embedTemplate);
			this.groupBox2.Controls.Add(this.webhookDelete);
			this.groupBox2.Controls.Add(this.webhookSave);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.messageTemplate);
			this.groupBox2.Controls.Add(this.existingWebhooks);
			this.groupBox2.Location = new System.Drawing.Point(3, 78);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(586, 252);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Edit existing";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(135, 82);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(83, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Embed template";
			// 
			// embedTemplate
			// 
			this.embedTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.embedTemplate.Location = new System.Drawing.Point(138, 98);
			this.embedTemplate.Multiline = true;
			this.embedTemplate.Name = "embedTemplate";
			this.embedTemplate.Size = new System.Drawing.Size(438, 88);
			this.embedTemplate.TabIndex = 5;
			// 
			// webhookDelete
			// 
			this.webhookDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.webhookDelete.Location = new System.Drawing.Point(138, 221);
			this.webhookDelete.Name = "webhookDelete";
			this.webhookDelete.Size = new System.Drawing.Size(438, 23);
			this.webhookDelete.TabIndex = 4;
			this.webhookDelete.Text = "Delete";
			this.webhookDelete.UseVisualStyleBackColor = true;
			this.webhookDelete.Click += new System.EventHandler(this.webhookDelete_Click);
			// 
			// webhookSave
			// 
			this.webhookSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.webhookSave.Location = new System.Drawing.Point(138, 192);
			this.webhookSave.Name = "webhookSave";
			this.webhookSave.Size = new System.Drawing.Size(438, 23);
			this.webhookSave.TabIndex = 3;
			this.webhookSave.Text = "Save";
			this.webhookSave.UseVisualStyleBackColor = true;
			this.webhookSave.Click += new System.EventHandler(this.webhookSave_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(135, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(93, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Message template";
			// 
			// messageTemplate
			// 
			this.messageTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.messageTemplate.Location = new System.Drawing.Point(138, 32);
			this.messageTemplate.Multiline = true;
			this.messageTemplate.Name = "messageTemplate";
			this.messageTemplate.Size = new System.Drawing.Size(438, 47);
			this.messageTemplate.TabIndex = 1;
			// 
			// existingWebhooks
			// 
			this.existingWebhooks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.existingWebhooks.FormattingEnabled = true;
			this.existingWebhooks.Location = new System.Drawing.Point(9, 19);
			this.existingWebhooks.Name = "existingWebhooks";
			this.existingWebhooks.Size = new System.Drawing.Size(120, 225);
			this.existingWebhooks.TabIndex = 0;
			// 
			// DiscordControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "DiscordControl";
			this.Size = new System.Drawing.Size(598, 333);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox webhookUrl;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button webhookAdd;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox embedTemplate;
		private System.Windows.Forms.Button webhookDelete;
		private System.Windows.Forms.Button webhookSave;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox messageTemplate;
		private System.Windows.Forms.ListBox existingWebhooks;
	}
}
