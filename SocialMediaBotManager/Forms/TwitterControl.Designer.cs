namespace SocialMediaBotManager.Forms
{
	partial class TwitterControl
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
			this.twitterUserDelete = new System.Windows.Forms.Button();
			this.twitterUserSave = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.openTwitterOauth = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.refreshAll = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.label3 = new System.Windows.Forms.Label();
			this.messageTemplate = new System.Windows.Forms.TextBox();
			this.existingTwitterUsers = new System.Windows.Forms.ListBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// twitterUserDelete
			// 
			this.twitterUserDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.twitterUserDelete.Enabled = false;
			this.twitterUserDelete.Location = new System.Drawing.Point(138, 289);
			this.twitterUserDelete.Name = "twitterUserDelete";
			this.twitterUserDelete.Size = new System.Drawing.Size(615, 23);
			this.twitterUserDelete.TabIndex = 4;
			this.twitterUserDelete.Text = "Delete";
			this.twitterUserDelete.UseVisualStyleBackColor = true;
			this.twitterUserDelete.Click += new System.EventHandler(this.twitterUserDelete_Click);
			// 
			// twitterUserSave
			// 
			this.twitterUserSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.twitterUserSave.Enabled = false;
			this.twitterUserSave.Location = new System.Drawing.Point(138, 260);
			this.twitterUserSave.Name = "twitterUserSave";
			this.twitterUserSave.Size = new System.Drawing.Size(615, 23);
			this.twitterUserSave.TabIndex = 3;
			this.twitterUserSave.Text = "Save";
			this.twitterUserSave.UseVisualStyleBackColor = true;
			this.twitterUserSave.Click += new System.EventHandler(this.twitterUserSave_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.openTwitterOauth);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(763, 48);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Add new";
			// 
			// openTwitterOauth
			// 
			this.openTwitterOauth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.openTwitterOauth.Location = new System.Drawing.Point(9, 16);
			this.openTwitterOauth.Name = "openTwitterOauth";
			this.openTwitterOauth.Size = new System.Drawing.Size(744, 23);
			this.openTwitterOauth.TabIndex = 2;
			this.openTwitterOauth.Text = "Add";
			this.openTwitterOauth.UseVisualStyleBackColor = true;
			this.openTwitterOauth.Click += new System.EventHandler(this.openTwitterOauth_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(0, 13);
			this.label1.TabIndex = 1;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.refreshAll);
			this.groupBox2.Controls.Add(this.statusStrip1);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.messageTemplate);
			this.groupBox2.Controls.Add(this.twitterUserDelete);
			this.groupBox2.Controls.Add(this.twitterUserSave);
			this.groupBox2.Controls.Add(this.existingTwitterUsers);
			this.groupBox2.Location = new System.Drawing.Point(0, 136);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(763, 348);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Edit existing";
			// 
			// refreshAll
			// 
			this.refreshAll.Location = new System.Drawing.Point(9, 16);
			this.refreshAll.Name = "refreshAll";
			this.refreshAll.Size = new System.Drawing.Size(120, 23);
			this.refreshAll.TabIndex = 8;
			this.refreshAll.Text = "Refresh";
			this.refreshAll.UseVisualStyleBackColor = true;
			this.refreshAll.Click += new System.EventHandler(this.refreshAll_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
			this.statusStrip1.Location = new System.Drawing.Point(3, 323);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(757, 22);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 7;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// statusLabel
			// 
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(64, 17);
			this.statusLabel.Text = "Status: Idle";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(135, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Tweet template";
			// 
			// messageTemplate
			// 
			this.messageTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.messageTemplate.Location = new System.Drawing.Point(138, 32);
			this.messageTemplate.Multiline = true;
			this.messageTemplate.Name = "messageTemplate";
			this.messageTemplate.Size = new System.Drawing.Size(615, 222);
			this.messageTemplate.TabIndex = 5;
			// 
			// existingTwitterUsers
			// 
			this.existingTwitterUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.existingTwitterUsers.FormattingEnabled = true;
			this.existingTwitterUsers.Location = new System.Drawing.Point(9, 45);
			this.existingTwitterUsers.Name = "existingTwitterUsers";
			this.existingTwitterUsers.Size = new System.Drawing.Size(120, 251);
			this.existingTwitterUsers.TabIndex = 0;
			// 
			// TwitterControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Name = "TwitterControl";
			this.Size = new System.Drawing.Size(763, 484);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button twitterUserDelete;
		private System.Windows.Forms.Button twitterUserSave;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button openTwitterOauth;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button refreshAll;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel statusLabel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox messageTemplate;
		private System.Windows.Forms.ListBox existingTwitterUsers;
	}
}
