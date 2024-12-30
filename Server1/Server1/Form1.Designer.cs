namespace Server1
{
    partial class Form1
    {
         // Set the title of the form
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelMessages;
        private System.Windows.Forms.Button chatHistory;
        private System.Windows.Forms.Button textSend;
        private System.Windows.Forms.Button imageSend;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label connectionStatusLabel; // Replace Button with Label

        // Constructor and Dispose method are unchanged

        private void InitializeComponent()
        {
            this.panelMessages = new System.Windows.Forms.Panel();
            this.chatHistory = new System.Windows.Forms.Button();
            this.textSend = new System.Windows.Forms.Button();
            this.imageSend = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.connectionStatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panelMessages
            // 
            this.panelMessages.AutoScroll = true;
            this.panelMessages.BackColor = System.Drawing.SystemColors.Window;
            this.panelMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMessages.Location = new System.Drawing.Point(13, 47);
            this.panelMessages.Margin = new System.Windows.Forms.Padding(2);
            this.panelMessages.Name = "panelMessages";
            this.panelMessages.Size = new System.Drawing.Size(363, 370);
            this.panelMessages.TabIndex = 0;
            // 
            // chatHistory
            // 
            this.chatHistory.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.chatHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chatHistory.Location = new System.Drawing.Point(12, 426);
            this.chatHistory.Name = "chatHistory";
            this.chatHistory.Size = new System.Drawing.Size(47, 30);
            this.chatHistory.TabIndex = 1;
            this.chatHistory.Text = "Export";
            this.chatHistory.UseVisualStyleBackColor = false;
            this.chatHistory.Click += new System.EventHandler(this.chatHistory_Click);
            // 
            // textSend
            // 
            this.textSend.BackColor = System.Drawing.SystemColors.Highlight;
            this.textSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textSend.Location = new System.Drawing.Point(275, 426);
            this.textSend.Name = "textSend";
            this.textSend.Size = new System.Drawing.Size(55, 31);
            this.textSend.TabIndex = 2;
            this.textSend.Text = "Send";
            this.textSend.UseVisualStyleBackColor = false;
            this.textSend.Click += new System.EventHandler(this.textSend_Click);
            // 
            // imageSend
            // 
            this.imageSend.BackgroundImage = global::Server1.Properties.Resources.image_icon3;
            this.imageSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imageSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.imageSend.Location = new System.Drawing.Point(336, 426);
            this.imageSend.Name = "imageSend";
            this.imageSend.Size = new System.Drawing.Size(40, 31);
            this.imageSend.TabIndex = 3;
            this.imageSend.UseVisualStyleBackColor = true;
            this.imageSend.Click += new System.EventHandler(this.imageSend_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Location = new System.Drawing.Point(65, 426);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(204, 30);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.AutoSize = true;
            this.connectionStatusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.connectionStatusLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.connectionStatusLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectionStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectionStatusLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.connectionStatusLabel.Location = new System.Drawing.Point(13, 21);
            this.connectionStatusLabel.Margin = new System.Windows.Forms.Padding(2);
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Padding = new System.Windows.Forms.Padding(2);
            this.connectionStatusLabel.Size = new System.Drawing.Size(6, 19);
            this.connectionStatusLabel.TabIndex = 1;
            this.connectionStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 481);
            this.Controls.Add(this.connectionStatusLabel);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.imageSend);
            this.Controls.Add(this.textSend);
            this.Controls.Add(this.chatHistory);
            this.Controls.Add(this.panelMessages);
            this.Name = "Form1";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
