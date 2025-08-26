using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ltmcuoiky
{
    internal static class Program
    {
        public static string SelectedComputerName { get; set; }
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Hiển thị form đăng nhập
            using (var loginForm = new Formlogin())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Kiểm tra vai trò người dùng đã chọn
                    if (loginForm.SelectedRole == "Server")
                    {
                        Application.Run(new server());
                    }
                    else if (loginForm.SelectedRole == "Client")
                    {
                        Program.SelectedComputerName = loginForm.SelectedComputer;
                        var clientForm = new client();
                        clientForm.Text = $"Client - {loginForm.SelectedComputer}";
                        Application.Run(clientForm);
                    }
                }
            }
        }
    }
}
