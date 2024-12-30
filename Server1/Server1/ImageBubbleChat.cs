using System;
using System.Drawing;
using System.Windows.Forms;

namespace Server1
{
    public partial class ImageBubbleChat : UserControl
    {
        public ImageBubbleChat()
        {
            InitializeComponent();
        }

        public void SetImage(Image image, bool isSent)
        {
            pictureBox.Image = image;
            if (isSent)
            {
                this.BackColor = Color.LightBlue;
                this.Dock = DockStyle.Right;
            }
            else
            {
                this.BackColor = Color.LightGreen;
                this.Dock = DockStyle.Left;
            }
        }
    }
}
