using System;
using System.Drawing;
using System.Windows.Forms;

namespace Server1
{
    public partial class BubbleChat : UserControl
    {
        public BubbleChat()
        {
            InitializeComponent();
        }

        private string messageText;
        private bool isIncoming;

        public string MessageText
        {
            get { return messageText; }
            set
            {
                messageText = value;
                lblMessage.Text = value;
            }
        }

        public bool IsIncoming
        {
            get { return isIncoming; }
            set
            {
                isIncoming = value;
                if (isIncoming)
                {
                    this.BackColor = Color.LightGreen;
                    lblMessage.TextAlign = ContentAlignment.MiddleLeft;
                }
                else
                {
                    this.BackColor = Color.LightBlue;
                    lblMessage.TextAlign = ContentAlignment.MiddleRight;
                }
            }
        }

        public void SetMessage(string message, bool isSent)
        {
            MessageText = message;
            IsIncoming = !isSent;
        }
    }
}
