namespace ltmcuoiky
{
    partial class client
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
            this.lbltitle = new System.Windows.Forms.Label();
            this.lblServerIP = new System.Windows.Forms.Label();
            this.txtServerIP = new System.Windows.Forms.TextBox();

            // 
            // lblServerIP
            // 
            this.lblServerIP.AutoSize = true;
            this.lblServerIP.Location = new System.Drawing.Point(40, 60);
            this.lblServerIP.Name = "lblServerIP";
            this.lblServerIP.Size = new System.Drawing.Size(100, 23);
            this.lblServerIP.Text = "IP Server:";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(150, 60);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(200, 25);
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtchat = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.labelClientName = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.Location = new System.Drawing.Point(179, 21);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(124, 23);
            this.lbltitle.TabIndex = 0;
            this.lbltitle.Text = "Client Lan chat";
            this.lbltitle.Click += new System.EventHandler(this.lbltitle_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(41, 156);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(36, 23);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Tên";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(146, 156);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(190, 30);
            this.txtName.TabIndex = 4;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(351, 150);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(84, 40);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Kết Nối ";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // txtchat
            // 
            this.txtchat.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtchat.Location = new System.Drawing.Point(40, 120);
            this.txtchat.Multiline = true;
            this.txtchat.Name = "txtchat";
            this.txtchat.ReadOnly = true;
            this.txtchat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtchat.Size = new System.Drawing.Size(400, 220);
            this.txtchat.TabIndex = 6;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(40, 360);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(300, 30);
            this.txtMessage.TabIndex = 7;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(360, 360);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(80, 30);
            this.btnSend.TabIndex = 8;
            this.btnSend.Text = "Gửi";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // labelClientName
            // 
            this.labelClientName.Location = new System.Drawing.Point(40, 80);
            this.labelClientName.Name = "labelClientName";
            this.labelClientName.Size = new System.Drawing.Size(200, 25);
            this.labelClientName.TabIndex = 0;
            this.labelClientName.Text = "Máy 1";
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(40, 400);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(400, 25);
            this.labelStatus.TabIndex = 1;
            // 
            // client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 450);
            this.Controls.Add(this.labelClientName);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtchat);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lbltitle);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    #endregion

    private System.Windows.Forms.Label lbltitle;
    private System.Windows.Forms.Label lblServerIP;
    private System.Windows.Forms.TextBox txtServerIP;
    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Button btnConnect;
    private System.Windows.Forms.TextBox txtchat;
    private System.Windows.Forms.TextBox txtMessage;
    private System.Windows.Forms.Button btnSend;
    private System.Windows.Forms.Label labelClientName;
    private System.Windows.Forms.Label labelStatus;
    }
}

