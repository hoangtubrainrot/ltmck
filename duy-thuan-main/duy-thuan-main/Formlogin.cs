using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ltmcuoiky
{
    public partial class Formlogin : Form
    {
        public string SelectedRole { get; private set; }
        public string SelectedComputer { get; private set; }

        public Formlogin()
        {
            InitializeComponent();
        }

        private void comboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Chỉ cho phép chọn máy khi vai trò là Client
            comboComputer.Enabled = comboRole.SelectedItem?.ToString() == "Client";
            if (comboRole.SelectedItem?.ToString() == "Server")
            {
                comboComputer.SelectedIndex = -1;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (comboRole.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn vai trò!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboRole.SelectedItem.ToString() == "Client" && comboComputer.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn máy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SelectedRole = comboRole.SelectedItem.ToString();
            SelectedComputer = comboComputer.SelectedItem?.ToString();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
