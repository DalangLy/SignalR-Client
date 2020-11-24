namespace SignalR_Client
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvConnectedUsers = new System.Windows.Forms.DataGridView();
            this.txtConnectionId = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSend = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRecieveMessage = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConnectedUsers)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Logged As : ";
            // 
            // txtUsername
            // 
            this.txtUsername.AutoSize = true;
            this.txtUsername.Location = new System.Drawing.Point(86, 9);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(32, 13);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Text = "Email";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(826, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Connected Users";
            // 
            // dgvConnectedUsers
            // 
            this.dgvConnectedUsers.AllowUserToAddRows = false;
            this.dgvConnectedUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvConnectedUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConnectedUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConnectedUsers.Location = new System.Drawing.Point(15, 127);
            this.dgvConnectedUsers.Name = "dgvConnectedUsers";
            this.dgvConnectedUsers.RowHeadersVisible = false;
            this.dgvConnectedUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConnectedUsers.Size = new System.Drawing.Size(431, 408);
            this.dgvConnectedUsers.TabIndex = 5;
            this.dgvConnectedUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConnectedUsers_CellContentClick);
            // 
            // txtConnectionId
            // 
            this.txtConnectionId.Location = new System.Drawing.Point(15, 25);
            this.txtConnectionId.Name = "txtConnectionId";
            this.txtConnectionId.Size = new System.Drawing.Size(330, 20);
            this.txtConnectionId.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtMessage);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtConnectionId);
            this.panel1.Location = new System.Drawing.Point(516, 127);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(359, 168);
            this.panel1.TabIndex = 7;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(293, 79);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(52, 76);
            this.btnSend.TabIndex = 10;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Message";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(15, 79);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(272, 76);
            this.txtMessage.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Input Connection ID";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtRecieveMessage);
            this.panel2.Location = new System.Drawing.Point(516, 340);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(359, 195);
            this.panel2.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Received Message";
            // 
            // txtRecieveMessage
            // 
            this.txtRecieveMessage.Location = new System.Drawing.Point(15, 28);
            this.txtRecieveMessage.Multiline = true;
            this.txtRecieveMessage.Name = "txtRecieveMessage";
            this.txtRecieveMessage.Size = new System.Drawing.Size(330, 152);
            this.txtRecieveMessage.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 564);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvConnectedUsers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConnectedUsers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtUsername;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvConnectedUsers;
        private System.Windows.Forms.TextBox txtConnectionId;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRecieveMessage;
    }
}

