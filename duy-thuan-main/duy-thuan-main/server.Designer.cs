namespace ltmcuoiky
{
    partial class server
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
            this.SuspendLayout();
            // 
            // tabControlChats
            // 
            this.tabControlChats = new System.Windows.Forms.TabControl();
            this.tabControlChats.Location = new System.Drawing.Point(20, 60);
            this.tabControlChats.Size = new System.Drawing.Size(350, 250);
            this.tabControlChats.Name = "tabControlChats";
            // 
            // listBoxClients
            // 
            this.listBoxClients = new System.Windows.Forms.ListBox();
            this.listBoxClients.Location = new System.Drawing.Point(400, 60);
            this.listBoxClients.Size = new System.Drawing.Size(160, 250);
            this.listBoxClients.SelectedIndexChanged += new System.EventHandler(this.listBoxClients_SelectedIndexChanged);
            // 
            // labelChatWith
            // 
            this.labelChatWith = new System.Windows.Forms.Label();
            this.labelChatWith.Location = new System.Drawing.Point(20, 20);
            this.labelChatWith.Size = new System.Drawing.Size(350, 25);
            this.labelChatWith.Text = "Đang chat với: (Chưa chọn)";
            // 
            // textBoxMessage
            // 
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.textBoxMessage.Location = new System.Drawing.Point(20, 330);
            this.textBoxMessage.Size = new System.Drawing.Size(350, 25);
            this.textBoxMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMessage_KeyPress);
            // 
            // buttonSend
            // 
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonSend.Location = new System.Drawing.Point(400, 330);
            this.buttonSend.Size = new System.Drawing.Size(160, 30);
            this.buttonSend.Text = "Gửi";
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.tabControlChats);
            this.Controls.Add(this.listBoxClients);
            this.Controls.Add(this.labelChatWith);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.buttonSend);
            this.Name = "server";
            this.Text = "Server Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    private System.Windows.Forms.TabControl tabControlChats;
    private System.Windows.Forms.ListBox listBoxClients;
    private System.Windows.Forms.Label labelChatWith;
    private System.Windows.Forms.TextBox textBoxMessage;
    private System.Windows.Forms.Button buttonSend;
    }
}