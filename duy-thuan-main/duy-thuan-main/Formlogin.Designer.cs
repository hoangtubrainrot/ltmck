namespace ltmcuoiky
{
    partial class Formlogin
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
            this.lblRole = new System.Windows.Forms.Label();
            this.comboRole = new System.Windows.Forms.ComboBox();
            this.lblComputer = new System.Windows.Forms.Label();
            this.comboComputer = new System.Windows.Forms.ComboBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(30, 30);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(80, 20);
            this.lblRole.Text = "Chọn vai trò:";
            // 
            // comboRole
            // 
            this.comboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRole.FormattingEnabled = true;
            this.comboRole.Items.AddRange(new object[] {
            "Server",
            "Client"});
            this.comboRole.Location = new System.Drawing.Point(120, 27);
            this.comboRole.Name = "comboRole";
            this.comboRole.Size = new System.Drawing.Size(150, 28);
            this.comboRole.SelectedIndexChanged += new System.EventHandler(this.comboRole_SelectedIndexChanged);
            // 
            // lblComputer
            // 
            this.lblComputer.AutoSize = true;
            this.lblComputer.Location = new System.Drawing.Point(30, 80);
            this.lblComputer.Name = "lblComputer";
            this.lblComputer.Size = new System.Drawing.Size(80, 20);
            this.lblComputer.Text = "Chọn máy:";
            // 
            // comboComputer
            // 
            this.comboComputer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboComputer.FormattingEnabled = true;
            this.comboComputer.Items.AddRange(new object[] {
            "Máy 1",
            "Máy 2",
            "Máy 3",
            "Máy 4",
            "Máy 5",
            "Máy 6"});
            this.comboComputer.Location = new System.Drawing.Point(120, 77);
            this.comboComputer.Name = "comboComputer";
            this.comboComputer.Size = new System.Drawing.Size(150, 28);
            this.comboComputer.Enabled = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(120, 130);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 35);
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // Formlogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.comboComputer);
            this.Controls.Add(this.lblComputer);
            this.Controls.Add(this.comboRole);
            this.Controls.Add(this.lblRole);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Formlogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox comboRole;
        private System.Windows.Forms.Label lblComputer;
        private System.Windows.Forms.ComboBox comboComputer;
        private System.Windows.Forms.Button btnLogin;
    }
}