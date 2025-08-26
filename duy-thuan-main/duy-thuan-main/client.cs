using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ltmcuoiky
{
    public partial class client : Form
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        private string clientName;
        private const int PORT = 8888;
        private bool isTyping = false;
        private System.Threading.Timer typingTimer;

        public client()
        {
            InitializeComponent();
            typingTimer = new System.Threading.Timer(OnTypingTimeout, null, Timeout.Infinite, Timeout.Infinite);
            
            // Cập nhật tên client từ form login
            if (Program.SelectedComputerName != null)
            {
                labelClientName.Text = Program.SelectedComputerName;
                
                // Tự động kết nối đến server
                txtServerIP.Text = "127.0.0.1"; // Localhost hoặc IP mặc định
                ConnectToServer();
            }
        }

        private void ConnectToServer()
        {
            try
            {
                if (string.IsNullOrEmpty(txtServerIP.Text))
                {
                    MessageBox.Show("Vui lòng nhập IP của server!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                tcpClient = new TcpClient();
                tcpClient.Connect(txtServerIP.Text, PORT);
                stream = tcpClient.GetStream();

                // Gửi tên client lên server
                clientName = Program.SelectedComputerName;
                byte[] nameMessage = Encoding.UTF8.GetBytes($"NAME:{clientName}");
                stream.Write(nameMessage, 0, nameMessage.Length);

                // Bắt đầu nhận tin nhắn
                Thread receiveThread = new Thread(ReceiveMessages);
                receiveThread.Start();

                // Cập nhật UI
                btnConnect.Enabled = false;
                txtServerIP.Enabled = false;
                btnSend.Enabled = true;
                txtMessage.Enabled = true;

                UpdateChat("Đã kết nối đến server!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbltitle_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện click cho label title (có thể để trống nếu không cần xử lý)
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtServerIP.Text))
                {
                    MessageBox.Show("Vui lòng nhập IP của server!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                tcpClient = new TcpClient();
                tcpClient.Connect(txtServerIP.Text, PORT);
                stream = tcpClient.GetStream();

                // Gửi tên client lên server
                clientName = Program.SelectedComputerName;
                byte[] nameMessage = Encoding.UTF8.GetBytes($"NAME:{clientName}");
                stream.Write(nameMessage, 0, nameMessage.Length);

                // Bắt đầu nhận tin nhắn
                Thread receiveThread = new Thread(ReceiveMessages);
                receiveThread.Start();

                // Cập nhật UI
                btnConnect.Enabled = false;
                txtServerIP.Enabled = false;
                txtName.Enabled = false;
                btnSend.Enabled = true;
                txtMessage.Enabled = true;

                UpdateChat("Đã kết nối đến server!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}");
            }
        }

        private void ReceiveMessages()
        {
            byte[] buffer = new byte[1024];
            int bytesRead;

            while (true)
            {
                try
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    
                    // Xử lý tin nhắn từ server
                    if (message.StartsWith("SERVER:"))
                    {
                        string serverMessage = message.Substring("SERVER:".Length);
                        UpdateChat($"Server: {serverMessage}");
                    }
                    // Xử lý tin nhắn thông thường
                    else if (message.StartsWith(clientName))
                    {
                        UpdateChat(message);
                    }
                }
                catch (Exception ex)
                {
                    if (!this.IsDisposed)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            MessageBox.Show($"Mất kết nối với server: {ex.Message}");
                        });
                    }
                    break;
                }
            }

            // Nếu thoát khỏi vòng lặp, nghĩa là mất kết nối
            if (!this.IsDisposed)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    UpdateChat("Mất kết nối với server!");
                    btnConnect.Enabled = true;
                    txtServerIP.Enabled = true;
                    btnSend.Enabled = false;
                    txtMessage.Enabled = false;
                });
            }

            // Mất kết nối với server
            if (this.IsDisposed) return;
            
            this.Invoke((MethodInvoker)delegate
            {
                btnConnect.Enabled = true;
                txtServerIP.Enabled = true;
                txtName.Enabled = true;
                btnSend.Enabled = false;
                txtMessage.Enabled = false;
                UpdateChat("Mất kết nối với server!");
            });
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMessage.Text)) return;

            try
            {
                string message = txtMessage.Text;
                // Gửi tin nhắn với định dạng "tên_client:nội_dung"
                string formattedMessage = $"{Program.SelectedComputerName}:{message}";
                byte[] buffer = Encoding.UTF8.GetBytes(formattedMessage);
                stream.Write(buffer, 0, buffer.Length);
                
                // Hiển thị tin nhắn trên khung chat của client
                UpdateChat($"{Program.SelectedComputerName}: {message}");
                
                txtMessage.Clear();

                // Reset trạng thái đang nhập
                isTyping = false;
                labelStatus.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi gửi tin nhắn: {ex.Message}");
            }
        }

        private void UpdateChat(string message)
        {
            if (txtchat.InvokeRequired)
            {
                txtchat.Invoke(new Action(() => UpdateChat(message)));
            }
            else
            {
                txtchat.AppendText(message + Environment.NewLine);
            }
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMessage.Text))
            {
                if (!isTyping)
                {
                    isTyping = true;
                    labelStatus.Text = "Đang nhập...";
                }
                // Reset timer
                typingTimer.Change(1000, Timeout.Infinite);
            }
        }

        private void OnTypingTimeout(object state)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnTypingTimeout(state)));
                return;
            }

            isTyping = false;
            labelStatus.Text = "";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            
            tcpClient?.Close();
            stream?.Dispose();
            typingTimer?.Dispose();
        }
    }
}
