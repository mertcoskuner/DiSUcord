namespace client
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.logs_if = new System.Windows.Forms.RichTextBox();
            this.textBox_message_if = new System.Windows.Forms.TextBox();
            this.label_Message_if = new System.Windows.Forms.Label();
            this.button_send_if = new System.Windows.Forms.Button();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.label_username = new System.Windows.Forms.Label();
            this.button_if_subscribe = new System.Windows.Forms.Button();
            this.label_if = new System.Windows.Forms.Label();
            this.button_send_sps = new System.Windows.Forms.Button();
            this.textBox_message_sps = new System.Windows.Forms.TextBox();
            this.label_Message_sps = new System.Windows.Forms.Label();
            this.label_sps = new System.Windows.Forms.Label();
            this.button_sps_subscribe = new System.Windows.Forms.Button();
            this.logs_sps = new System.Windows.Forms.RichTextBox();
            this.button_if_unsubscribe = new System.Windows.Forms.Button();
            this.button_sps_unsubscribe = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.if_status = new System.Windows.Forms.TextBox();
            this.sps_status = new System.Windows.Forms.TextBox();
            this.logs_connection = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_disconnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port:";
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(165, 144);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(172, 31);
            this.textBox_ip.TabIndex = 2;
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(165, 212);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(172, 31);
            this.textBox_port.TabIndex = 3;
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(98, 325);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(140, 44);
            this.button_connect.TabIndex = 4;
            this.button_connect.Text = "connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // logs_if
            // 
            this.logs_if.Location = new System.Drawing.Point(484, 412);
            this.logs_if.Name = "logs_if";
            this.logs_if.Size = new System.Drawing.Size(433, 323);
            this.logs_if.TabIndex = 5;
            this.logs_if.Text = "";
            // 
            // textBox_message_if
            // 
            this.textBox_message_if.Location = new System.Drawing.Point(590, 353);
            this.textBox_message_if.Name = "textBox_message_if";
            this.textBox_message_if.Size = new System.Drawing.Size(192, 31);
            this.textBox_message_if.TabIndex = 6;
            // 
            // label_Message_if
            // 
            this.label_Message_if.AutoSize = true;
            this.label_Message_if.Location = new System.Drawing.Point(480, 361);
            this.label_Message_if.Name = "label_Message_if";
            this.label_Message_if.Size = new System.Drawing.Size(106, 25);
            this.label_Message_if.TabIndex = 7;
            this.label_Message_if.Text = "Message:";
            // 
            // button_send_if
            // 
            this.button_send_if.Location = new System.Drawing.Point(789, 338);
            this.button_send_if.Name = "button_send_if";
            this.button_send_if.Size = new System.Drawing.Size(130, 50);
            this.button_send_if.TabIndex = 8;
            this.button_send_if.Text = "send";
            this.button_send_if.UseVisualStyleBackColor = true;
            this.button_send_if.Click += new System.EventHandler(this.button_send_if_Click);
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(165, 259);
            this.textBox_username.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(172, 31);
            this.textBox_username.TabIndex = 9;
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.Location = new System.Drawing.Point(46, 258);
            this.label_username.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(110, 25);
            this.label_username.TabIndex = 10;
            this.label_username.Text = "Username";
            // 
            // button_if_subscribe
            // 
            this.button_if_subscribe.Location = new System.Drawing.Point(590, 214);
            this.button_if_subscribe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_if_subscribe.Name = "button_if_subscribe";
            this.button_if_subscribe.Size = new System.Drawing.Size(273, 34);
            this.button_if_subscribe.TabIndex = 11;
            this.button_if_subscribe.Text = "subscribe";
            this.button_if_subscribe.UseVisualStyleBackColor = true;
            this.button_if_subscribe.Click += new System.EventHandler(this.button_if_subscribe_Click);
            // 
            // label_if
            // 
            this.label_if.AutoSize = true;
            this.label_if.Location = new System.Drawing.Point(669, 78);
            this.label_if.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_if.Name = "label_if";
            this.label_if.Size = new System.Drawing.Size(66, 25);
            this.label_if.TabIndex = 13;
            this.label_if.Text = "IF100";
            // 
            // button_send_sps
            // 
            this.button_send_sps.Location = new System.Drawing.Point(1300, 330);
            this.button_send_sps.Name = "button_send_sps";
            this.button_send_sps.Size = new System.Drawing.Size(130, 50);
            this.button_send_sps.TabIndex = 14;
            this.button_send_sps.Text = "send";
            this.button_send_sps.UseVisualStyleBackColor = true;
            this.button_send_sps.Click += new System.EventHandler(this.button_send_sps_Click);
            // 
            // textBox_message_sps
            // 
            this.textBox_message_sps.Location = new System.Drawing.Point(1078, 338);
            this.textBox_message_sps.Name = "textBox_message_sps";
            this.textBox_message_sps.Size = new System.Drawing.Size(192, 31);
            this.textBox_message_sps.TabIndex = 15;
            // 
            // label_Message_sps
            // 
            this.label_Message_sps.AutoSize = true;
            this.label_Message_sps.Location = new System.Drawing.Point(969, 342);
            this.label_Message_sps.Name = "label_Message_sps";
            this.label_Message_sps.Size = new System.Drawing.Size(106, 25);
            this.label_Message_sps.TabIndex = 16;
            this.label_Message_sps.Text = "Message:";
            // 
            // label_sps
            // 
            this.label_sps.AutoSize = true;
            this.label_sps.Location = new System.Drawing.Point(1170, 78);
            this.label_sps.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_sps.Name = "label_sps";
            this.label_sps.Size = new System.Drawing.Size(96, 25);
            this.label_sps.TabIndex = 17;
            this.label_sps.Text = "SPS 101";
            // 
            // button_sps_subscribe
            // 
            this.button_sps_subscribe.Location = new System.Drawing.Point(1078, 212);
            this.button_sps_subscribe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_sps_subscribe.Name = "button_sps_subscribe";
            this.button_sps_subscribe.Size = new System.Drawing.Size(273, 36);
            this.button_sps_subscribe.TabIndex = 18;
            this.button_sps_subscribe.Text = "subscribe";
            this.button_sps_subscribe.UseVisualStyleBackColor = true;
            this.button_sps_subscribe.Click += new System.EventHandler(this.button_sps_subscribe_Click_1);
            // 
            // logs_sps
            // 
            this.logs_sps.Location = new System.Drawing.Point(988, 412);
            this.logs_sps.Name = "logs_sps";
            this.logs_sps.Size = new System.Drawing.Size(440, 323);
            this.logs_sps.TabIndex = 19;
            this.logs_sps.Text = "";
            // 
            // button_if_unsubscribe
            // 
            this.button_if_unsubscribe.Location = new System.Drawing.Point(590, 258);
            this.button_if_unsubscribe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_if_unsubscribe.Name = "button_if_unsubscribe";
            this.button_if_unsubscribe.Size = new System.Drawing.Size(273, 36);
            this.button_if_unsubscribe.TabIndex = 20;
            this.button_if_unsubscribe.Text = "unsubscribe";
            this.button_if_unsubscribe.UseVisualStyleBackColor = true;
            this.button_if_unsubscribe.Click += new System.EventHandler(this.button_if_unsubscribe_Click);
            // 
            // button_sps_unsubscribe
            // 
            this.button_sps_unsubscribe.Location = new System.Drawing.Point(1078, 258);
            this.button_sps_unsubscribe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_sps_unsubscribe.Name = "button_sps_unsubscribe";
            this.button_sps_unsubscribe.Size = new System.Drawing.Size(273, 36);
            this.button_sps_unsubscribe.TabIndex = 21;
            this.button_sps_unsubscribe.Text = "unsubscribe";
            this.button_sps_unsubscribe.UseVisualStyleBackColor = true;
            this.button_sps_unsubscribe.Click += new System.EventHandler(this.button_sps_unsubscribe_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(514, 144);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 25);
            this.label3.TabIndex = 22;
            this.label3.Text = "status";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1004, 136);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 25);
            this.label4.TabIndex = 23;
            this.label4.Text = "status";
            // 
            // if_status
            // 
            this.if_status.Location = new System.Drawing.Point(609, 139);
            this.if_status.Name = "if_status";
            this.if_status.Size = new System.Drawing.Size(172, 31);
            this.if_status.TabIndex = 24;
            // 
            // sps_status
            // 
            this.sps_status.Location = new System.Drawing.Point(1098, 136);
            this.sps_status.Name = "sps_status";
            this.sps_status.Size = new System.Drawing.Size(172, 31);
            this.sps_status.TabIndex = 25;
            // 
            // logs_connection
            // 
            this.logs_connection.Location = new System.Drawing.Point(51, 412);
            this.logs_connection.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.logs_connection.Name = "logs_connection";
            this.logs_connection.Size = new System.Drawing.Size(362, 323);
            this.logs_connection.TabIndex = 26;
            this.logs_connection.Text = "";
            this.logs_connection.TextChanged += new System.EventHandler(this.logs_connection_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 78);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 25);
            this.label5.TabIndex = 27;
            this.label5.Text = "Connection";
            // 
            // button_disconnect
            // 
            this.button_disconnect.Location = new System.Drawing.Point(261, 325);
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.Size = new System.Drawing.Size(140, 44);
            this.button_disconnect.TabIndex = 28;
            this.button_disconnect.Text = "disconnect";
            this.button_disconnect.UseVisualStyleBackColor = true;
            this.button_disconnect.Click += new System.EventHandler(this.button_disconnect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1448, 777);
            this.Controls.Add(this.button_disconnect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.logs_connection);
            this.Controls.Add(this.sps_status);
            this.Controls.Add(this.if_status);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_sps_unsubscribe);
            this.Controls.Add(this.button_if_unsubscribe);
            this.Controls.Add(this.logs_sps);
            this.Controls.Add(this.button_sps_subscribe);
            this.Controls.Add(this.label_sps);
            this.Controls.Add(this.label_Message_sps);
            this.Controls.Add(this.textBox_message_sps);
            this.Controls.Add(this.button_send_sps);
            this.Controls.Add(this.label_if);
            this.Controls.Add(this.button_if_subscribe);
            this.Controls.Add(this.label_username);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.button_send_if);
            this.Controls.Add(this.label_Message_if);
            this.Controls.Add(this.textBox_message_if);
            this.Controls.Add(this.logs_if);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.textBox_ip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.RichTextBox logs_if;
        private System.Windows.Forms.TextBox textBox_message_if;
        private System.Windows.Forms.Label label_Message_if;
        private System.Windows.Forms.Button button_send_if;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.Button button_if_subscribe;
        private System.Windows.Forms.Label label_if;
        private System.Windows.Forms.Button button_send_sps;
        private System.Windows.Forms.TextBox textBox_message_sps;
        private System.Windows.Forms.Label label_Message_sps;
        private System.Windows.Forms.Label label_sps;
        private System.Windows.Forms.Button button_sps_subscribe;
        private System.Windows.Forms.RichTextBox logs_sps;
        private System.Windows.Forms.Button button_if_unsubscribe;
        private System.Windows.Forms.Button button_sps_unsubscribe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox if_status;
        private System.Windows.Forms.TextBox sps_status;
        private System.Windows.Forms.RichTextBox logs_connection;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_disconnect;
    }
}

