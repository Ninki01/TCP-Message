using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Client1
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private Thread listenThread;
        private bool isDisconnecting = false;
        private delegate void SafeCallDelegate(string text, bool isImage, bool isSent, Image image);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Disable disconnect button initially
            disconnectServer.Enabled = false;
        }

        private void connectServer_Click(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient(GetLocalIPAddress(), 5000); // Connect to the specified IP address and port
                stream = client.GetStream();
                UpdateConnectionStatus(true, false);
                listenThread = new Thread(new ThreadStart(ListenForMessages));
                listenThread.IsBackground = true;
                listenThread.Start();
            }
            catch (Exception ex)
            {
                AddMessage($"Error: {ex.Message}", false, true, null);
                UpdateConnectionStatus(false, false);
            }
        }

        private void disconnectServer_Click(object sender, EventArgs e)
        {
            try
            {
                isDisconnecting = true;

                if (client != null && client.Connected)
                {
                    SendMessage("DISCONNECT", false);
                    client.Close();
                }

                // Wait for the listening thread to finish
                if (listenThread != null && listenThread.IsAlive)
                {
                    listenThread.Join(500); // Wait for up to 500 ms
                }

                UpdateConnectionStatus(false, false);
            }
            catch (Exception ex)
            {
                AddMessage($"Error: {ex.Message}", false, true, null);
            }
            finally
            {
                isDisconnecting = false;
            }
        }
        private void ListenForMessages()
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[1024 * 1024]; // Increased buffer size for larger messages
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    if (bytesRead > 0)
                    {
                        string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        ProcessReceivedData(receivedMessage);
                    }
                }
            }
            catch (IOException ex)
            {
                if (!isDisconnecting)
                {
                    AddMessage($"Error: {ex.Message}", false, true, null);
                }
            }
            catch (Exception ex)
            {
                if (!(ex is ThreadAbortException))
                {
                    AddMessage($"Error: {ex.Message}", false, true, null);
                }
            }
        }

        private void ProcessReceivedData(string receivedData)
        {
            // Split received data into messages
            string[] messages = receivedData.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string message in messages)
            {
                if (message.StartsWith("IMG:"))
                {
                    string base64String = message.Substring(4);
                    byte[] imageBytes = Convert.FromBase64String(base64String);

                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        Image image = Image.FromStream(ms);
                        AddMessage("", true, false, image); // Display received image
                    }
                }
                else
                {
                    AddMessage(message, false, false, null); // Display received text message
                }
            }
        }

        private void AddMessage(string text, bool isImage, bool isSent, Image image)
        {
            if (panelMessages.InvokeRequired)
            {
                var d = new SafeCallDelegate(AddMessage);
                panelMessages.Invoke(d, new object[] { text, isImage, isSent, image });
            }
            else
            {
                try
                {
                    Panel bubble = new Panel
                    {
                        BackColor = isSent ? Color.LightGreen : Color.LightBlue,
                        Padding = new Padding(10), // Padding around the bubble content
                        Margin = new Padding(10),   // Margin around the entire bubble
                        AutoSize = true,
                        MaximumSize = new Size(panelMessages.Width - 30, 0)
                    };

                    if (isImage && image != null)
                    {
                        PictureBox pictureBox = new PictureBox
                        {
                            Image = image,
                            SizeMode = PictureBoxSizeMode.Zoom, // Set size mode to zoom to fit the image
                            Size = new Size(200, 200), // Set a fixed size for image display         
                        };
                        bubble.Controls.Add(pictureBox);
                    }
                    else
                    {
                        Label label = new Label
                        {
                            Text = text,
                            AutoSize = true,
                            MaximumSize = new Size(bubble.Width - 20, 0),
                            ForeColor = Color.Black,
                            TextAlign = isSent ? ContentAlignment.MiddleRight : ContentAlignment.MiddleLeft,
                            Dock = DockStyle.Fill // Fill the entire space within the bubble
                        };
                        bubble.Controls.Add(label);

                        // Adjust bubble width based on label size
                        bubble.Width = Math.Min(panelMessages.Width - 30, label.PreferredWidth + bubble.Padding.Horizontal + bubble.Margin.Horizontal);
                    }

                    // Position the bubble based on sent or received
                    int yPosition = panelMessages.Controls.Count > 0 ?
                                        panelMessages.Controls[panelMessages.Controls.Count - 1].Bottom + 20 :
                                        0;

                    int xPosition = isSent ?
                                        panelMessages.Width - bubble.Width - 2 :
                                        2;

                    bubble.Location = new Point(xPosition, yPosition);
                    panelMessages.Controls.Add(bubble);
                    panelMessages.ScrollControlIntoView(bubble); // Scroll to the latest message
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding message: {ex.Message}");
                    MessageBox.Show($"Error adding message: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateConnectionStatus(bool isConnected, bool changeButtonText)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateConnectionStatus(isConnected, changeButtonText)));
            }
            else
            {
                disconnectServer.Enabled = isConnected;

                if (changeButtonText)
                {
                    string status = isConnected ? "CONNECTED" : "DISCONNECTED";
                    Color color = isConnected ? Color.Green : Color.Red;

                    connectServer.BackColor = color;
                    connectServer.Text = status;
                }
            }
        }

        private void textSend_Click(object sender, EventArgs e)
        {
            try
            {
                string message = richTextBox1.Text.Trim(); // Trim to remove leading/trailing whitespace

                // Check if message is not empty
                if (!string.IsNullOrWhiteSpace(message))
                {
                    // Check if client is connected before sending the message
                    if (client != null && client.Connected)
                    {
                        SendMessage(message, false);
                        AddMessage(message, false, true, null);
                        richTextBox1.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Not connected to server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Cannot send empty message.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void imageSend_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // Check if client is connected before sending the image
                    if (client != null && client.Connected)
                    {
                        // Check file size before reading the bytes
                        FileInfo fileInfo = new FileInfo(filePath);
                        long fileSizeInBytes = fileInfo.Length;
                        long fileSizeInMB = fileSizeInBytes / (1024 * 1024); // Convert bytes to MB

                        // Check if file size exceeds 1MB
                        if (fileSizeInMB > 0.9)
                        {
                            MessageBox.Show("Image size exceeds 1MB. Please select an image file smaller than 1MB.", "Image Size Limit Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Exit without sending the image
                        }

                        byte[] imageBytes = File.ReadAllBytes(filePath);
                        string base64String = Convert.ToBase64String(imageBytes);
                        SendMessage(base64String, true);

                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            Image image = Image.FromStream(ms);
                            AddMessage("", true, true, image);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not connected to server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Image selection was cancelled.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SendMessage(string message, bool isImage)
        {
            if (client != null && client.Connected)
            {
                try
                {
                    byte[] buffer;
                    if (isImage)
                    {
                        buffer = Encoding.UTF8.GetBytes("IMG:" + message + "\n");
                    }
                    else
                    {
                        buffer = Encoding.UTF8.GetBytes(message + "\n");
                    }
                    stream.Write(buffer, 0, buffer.Length);
                }
                catch (Exception )
                {

                }
            }
        }
        private void chatHistory_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files|*.txt",
                Title = "Save Chat History"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (Control control in panelMessages.Controls)
                    {
                        if (control is Panel bubble)
                        {
                            string speaker = GetSpeaker(bubble); // Determine who is speaking (Client or Server)

                            foreach (Control bubbleControl in bubble.Controls)
                            {
                                if (bubbleControl is Label label)
                                {
                                    // Add timestamp, speaker, and message text
                                    string timeStampedMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {speaker}: {label.Text}";
                                    sw.WriteLine(timeStampedMessage);
                                }
                                else if (bubbleControl is PictureBox)
                                {
                                    // Add timestamp and speaker for image messages
                                    string timeStampedImage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {speaker}: [Image]";
                                    sw.WriteLine(timeStampedImage);
                                }
                            }
                        }
                    }
                }
            }
        }

        // Helper method to determine who is speaking based on the Panel color
        private string GetSpeaker(Panel bubble)
        {
            Color bubbleColor = bubble.BackColor;

            if (bubbleColor == Color.LightGreen)
            {
                return "Server";
            }
            else if (bubbleColor == Color.LightBlue)
            {
                return "Client";
            }
            else
            {
                return "Unknown"; // Handle unexpected colors if needed
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // No implementation needed, but method required to prevent error.
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}