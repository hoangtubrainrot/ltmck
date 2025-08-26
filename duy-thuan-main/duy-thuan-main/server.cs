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
    public partial class server : Form
    {
        private TcpListener tcpListener;
        private List<TcpClient> clients = new List<TcpClient>();
        private Dictionary<TcpClient, string> clientNames = new Dictionary<TcpClient, string>();
        private Dictionary<string, StringBuilder> chatHistories = new Dictionary<string, StringBuilder>();
        private const int PORT = 8888;

        public server()
        {
            InitializeComponent();

            // Tạo tab hệ thống
            TabPage systemTab = new TabPage("Hệ thống");
            RichTextBox systemChat = new RichTextBox();
            systemChat.Dock = DockStyle.Fill;
            systemChat.ReadOnly = true;
            systemTab.Controls.Add(systemChat);
            tabControlChats.TabPages.Add(systemTab);

            // Vô hiệu hóa textbox và nút gửi cho đến khi chọn client
            textBoxMessage.Enabled = false;
            buttonSend.Enabled = false;
            labelChatWith.Text = "Đang chat với: (Chưa chọn)";
            StartServer();
        }

        private void StartServer()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, PORT);
                tcpListener.Start();

                // Hiển thị IP của server
                string hostName = Dns.GetHostName();
                string serverIP = Dns.GetHostEntry(hostName)
                    .AddressList
                    .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork)
                    ?.ToString();

                UpdateChat($"Server đã khởi động...");
                UpdateChat($"IP Server: {serverIP}");
                UpdateChat($"Port: {PORT}");

                // Bắt đầu chấp nhận client
                Thread acceptThread = new Thread(AcceptClients);
                acceptThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi động server: {ex.Message}");
            }
        }

        private void AcceptClients()
        {
            while (true)
            {
                try
                {
                    TcpClient client = tcpListener.AcceptTcpClient();
                    clients.Add(client);

                    // Tạo thread mới để xử lý client
                    Thread clientThread = new Thread(() => HandleClient(client));
                    clientThread.Start();
                }
                catch (Exception)
                {
                    break;
                }
            }
        }

        private void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;

            while (true)
            {
                try
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    
                    // Xử lý tin nhắn từ client
                    if (message.StartsWith("NAME:"))
                    {
                        // Đăng ký tên client
                        string clientName = message.Substring(5);
                        clientNames[client] = clientName;
                        UpdateClientList();
                        
                        // Tạo tab chat mới cho client
                        UpdateChat($"{clientName} đã kết nối", clientName);
                        UpdateChat($"Bắt đầu chat với {clientName}", clientName);
                    }
                    else
                    {
                        // Xử lý tin nhắn thông thường
                        string senderName = clientNames[client];
                        // Hiển thị tin nhắn trong tab của client tương ứng
                        UpdateChat($"{senderName}: {message}", senderName);
                    }
                }
                catch (Exception)
                {
                    break;
                }
            }

            // Client ngắt kết nối
            string disconnectedClient = clientNames.ContainsKey(client) ? clientNames[client] : "Unknown";
            clients.Remove(client);
            clientNames.Remove(client);
            UpdateClientList();
            UpdateChat($"{disconnectedClient} đã ngắt kết nối");
            client.Close();
        }

        private void BroadcastMessage(string message, TcpClient sender = null)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            
            foreach (TcpClient client in clients)
            {
                if (client != sender) // Không gửi lại cho người gửi
                {
                    try
                    {
                        NetworkStream stream = client.GetStream();
                        stream.Write(buffer, 0, buffer.Length);
                    }
                    catch { }
                }
            }
        }

        private void UpdateChat(string message, string clientName = null)
        {
            if (tabControlChats.InvokeRequired)
            {
                tabControlChats.Invoke(new Action<string, string>(UpdateChat), message, clientName);
                return;
            }

            if (clientName == null)
            {
                // Thông báo hệ thống - hiển thị trong tab hệ thống
                var systemTab = tabControlChats.TabPages[0];
                var systemChat = systemTab.Controls[0] as RichTextBox;
                systemChat.AppendText(message + Environment.NewLine);
                systemChat.ScrollToCaret();
            }
            else
            {
                // Tạo tab mới nếu chưa tồn tại
                if (!tabControlChats.TabPages.ContainsKey(clientName))
                {
                    TabPage newTab = new TabPage(clientName);
                    newTab.Name = clientName;
                    RichTextBox newChatBox = new RichTextBox();
                    newChatBox.Dock = DockStyle.Fill;
                    newChatBox.ReadOnly = true;
                    newTab.Controls.Add(newChatBox);
                    tabControlChats.TabPages.Add(newTab);
                }

                // Cập nhật tin nhắn trong tab tương ứng
                var clientTab = tabControlChats.TabPages[clientName];
                var existingChatBox = clientTab.Controls[0] as RichTextBox;
                existingChatBox.AppendText(message + Environment.NewLine);
                existingChatBox.ScrollToCaret();
            }
        }

        private void UpdateClientList()
        {
            if (listBoxClients.InvokeRequired)
            {
                listBoxClients.Invoke(new Action(UpdateClientList));
            }
            else
            {
                listBoxClients.Items.Clear();
                foreach (string clientName in clientNames.Values)
                {
                    listBoxClients.Items.Add(clientName);
                }
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxMessage.Text)) return;

            if (listBoxClients.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một client để gửi tin nhắn!");
                return;
            }

            try
            {
                string selectedClient = listBoxClients.SelectedItem.ToString();
                string message = textBoxMessage.Text;

                // Gửi tin nhắn tới client đã chọn
                var client = clients.FirstOrDefault(c => clientNames[c] == selectedClient);
                if (client != null && client.Connected)
                {
                    // Gửi tin nhắn với tiền tố SERVER để client có thể nhận biết
                    NetworkStream stream = client.GetStream();
                    string formattedMessage = $"SERVER:{message}";
                    byte[] buffer = Encoding.UTF8.GetBytes(formattedMessage);
                    stream.Write(buffer, 0, buffer.Length);
                    stream.Flush();

                    // Cập nhật chat trong tab của client
                    UpdateChat($"Server: {message}", selectedClient);
                }
                else
                {
                    MessageBox.Show("Client không tồn tại hoặc đã ngắt kết nối!");
                }
                
                // Xóa nội dung tin nhắn
                textBoxMessage.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi gửi tin nhắn: {ex.Message}");
            }
        }

        private void SendMessageToClient(string clientName, string message)
        {
            try
            {
                var client = clients.FirstOrDefault(c => clientNames[c] == clientName);
                if (client != null && client.Connected)
                {
                    byte[] buffer = Encoding.UTF8.GetBytes($"SERVER: {message}");
                    NetworkStream stream = client.GetStream();
                    stream.Write(buffer, 0, buffer.Length);
                    stream.Flush();

                    // Hiển thị tin nhắn trong tab chat của client tương ứng
                    UpdateChat($"Server: {message}", clientName);

                    // Lưu vào lịch sử chat
                    if (!chatHistories.ContainsKey(clientName))
                    {
                        chatHistories[clientName] = new StringBuilder();
                    }
                    chatHistories[clientName].AppendLine($"Server: {message}");
                }
                else
                {
                    throw new Exception("Client không tồn tại hoặc đã ngắt kết nối");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi gửi tin nhắn đến {clientName}: {ex.Message}");
            }
        }

        private void listBoxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxClients.SelectedItem != null)
            {
                string selectedClient = listBoxClients.SelectedItem.ToString();
                labelChatWith.Text = $"Đang chat với: {selectedClient}";
                textBoxMessage.Enabled = true;
                buttonSend.Enabled = true;

                // Chuyển đến tab chat của client được chọn
                foreach (TabPage tab in tabControlChats.TabPages)
                {
                    if (tab.Text == selectedClient)
                    {
                        tabControlChats.SelectedTab = tab;
                        break;
                    }
                }
            }
            else
            {
                labelChatWith.Text = "Đang chat với: (Chưa chọn)";
                textBoxMessage.Enabled = false;
                buttonSend.Enabled = false;
                // Chuyển về tab hệ thống
                tabControlChats.SelectedTab = tabControlChats.TabPages[0];
            }
        }

        private void textBoxMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Gửi tin nhắn khi nhấn Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Ngăn không cho phát ra tiếng beep
                buttonSend.PerformClick(); // Kích hoạt sự kiện click của nút gửi
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            
            // Đóng tất cả kết nối khi tắt server
            foreach (TcpClient client in clients)
            {
                client.Close();
            }
            tcpListener?.Stop();
        }
    }
}
