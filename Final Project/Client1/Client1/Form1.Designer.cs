namespace Client1
{
    partial class Form1
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
            this.panelMessages = new System.Windows.Forms.Panel();
            this.chatHistory = new System.Windows.Forms.Button();
            this.textSend = new System.Windows.Forms.Button();
            this.imageSend = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.connectServer = new System.Windows.Forms.Button();
            this.disconnectServer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelMessages
            // 
            this.panelMessages.AutoScroll = true;
            this.panelMessages.BackColor = System.Drawing.SystemColors.Window;
            this.panelMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMessages.Location = new System.Drawing.Point(17, 58);
            this.panelMessages.Name = "panelMessages";
            this.panelMessages.Size = new System.Drawing.Size(483, 455);
            this.panelMessages.TabIndex = 0;
            // 
            // chatHistory
            // 
            this.chatHistory.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.chatHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chatHistory.Location = new System.Drawing.Point(16, 524);
            this.chatHistory.Margin = new System.Windows.Forms.Padding(4);
            this.chatHistory.Name = "chatHistory";
            this.chatHistory.Size = new System.Drawing.Size(63, 37);
            this.chatHistory.TabIndex = 1;
            this.chatHistory.Text = "Export";
            this.chatHistory.UseVisualStyleBackColor = false;
            this.chatHistory.Click += new System.EventHandler(this.chatHistory_Click);
            // 
            // textSend
            // 
            this.textSend.BackColor = System.Drawing.SystemColors.Highlight;
            this.textSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textSend.Location = new System.Drawing.Point(367, 524);
            this.textSend.Margin = new System.Windows.Forms.Padding(4);
            this.textSend.Name = "textSend";
            this.textSend.Size = new System.Drawing.Size(73, 38);
            this.textSend.TabIndex = 2;
            this.textSend.Text = "Send";
            this.textSend.UseVisualStyleBackColor = false;
            this.textSend.Click += new System.EventHandler(this.textSend_Click);
            // 
            // imageSend
            // 
            this.imageSend.BackgroundImage = global::Client1.Properties.Resources.image_icon3;
            this.imageSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imageSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.imageSend.Location = new System.Drawing.Point(448, 524);
            this.imageSend.Margin = new System.Windows.Forms.Padding(4);
            this.imageSend.Name = "imageSend";
            this.imageSend.Size = new System.Drawing.Size(53, 38);
            this.imageSend.TabIndex = 3;
            this.imageSend.UseVisualStyleBackColor = true;
            this.imageSend.Click += new System.EventHandler(this.imageSend_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Location = new System.Drawing.Point(87, 524);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(271, 36);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // connectServer
            // 
            this.connectServer.BackColor = System.Drawing.Color.Lime;
            this.connectServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectServer.Location = new System.Drawing.Point(17, 14);
            this.connectServer.Margin = new System.Windows.Forms.Padding(4);
            this.connectServer.Name = "connectServer";
            this.connectServer.Size = new System.Drawing.Size(136, 37);
            this.connectServer.TabIndex = 5;
            this.connectServer.Text = "CONNECT";
            this.connectServer.UseVisualStyleBackColor = false;
            this.connectServer.Click += new System.EventHandler(this.connectServer_Click);
            // 
            // disconnectServer
            // 
            this.disconnectServer.BackColor = System.Drawing.Color.Red;
            this.disconnectServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disconnectServer.Location = new System.Drawing.Point(365, 15);
            this.disconnectServer.Margin = new System.Windows.Forms.Padding(4);
            this.disconnectServer.Name = "disconnectServer";
            this.disconnectServer.Size = new System.Drawing.Size(136, 37);
            this.disconnectServer.TabIndex = 6;
            this.disconnectServer.Text = "DISCONNECT";
            this.disconnectServer.UseVisualStyleBackColor = false;
            this.disconnectServer.Click += new System.EventHandler(this.disconnectServer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 592);
            this.Controls.Add(this.disconnectServer);
            this.Controls.Add(this.connectServer);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.imageSend);
            this.Controls.Add(this.textSend);
            this.Controls.Add(this.chatHistory);
            this.Controls.Add(this.panelMessages);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMessages;
        private System.Windows.Forms.Button chatHistory;
        private System.Windows.Forms.Button textSend;
        private System.Windows.Forms.Button imageSend;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button connectServer;
        private System.Windows.Forms.Button disconnectServer;
    }
}

