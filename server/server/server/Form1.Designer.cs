namespace server
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
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_listen = new System.Windows.Forms.Button();
            this.logs_SPS101 = new System.Windows.Forms.RichTextBox();
            this.logs_IF100 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.logs = new System.Windows.Forms.RichTextBox();
            this.logs_currentlyConnected = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(43, 20);
            this.textBox_port.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(183, 22);
            this.textBox_port.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port:";
            // 
            // button_listen
            // 
            this.button_listen.Location = new System.Drawing.Point(228, 17);
            this.button_listen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_listen.Name = "button_listen";
            this.button_listen.Size = new System.Drawing.Size(74, 28);
            this.button_listen.TabIndex = 2;
            this.button_listen.Text = "Listen";
            this.button_listen.UseVisualStyleBackColor = true;
            this.button_listen.Click += new System.EventHandler(this.button_listen_Click);
            // 
            // logs_SPS101
            // 
            this.logs_SPS101.Location = new System.Drawing.Point(56, 134);
            this.logs_SPS101.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.logs_SPS101.Name = "logs_SPS101";
            this.logs_SPS101.Size = new System.Drawing.Size(235, 129);
            this.logs_SPS101.TabIndex = 3;
            this.logs_SPS101.Text = "";
            this.logs_SPS101.TextChanged += new System.EventHandler(this.logs_TextChanged);
            // 
            // logs_IF100
            // 
            this.logs_IF100.Location = new System.Drawing.Point(312, 134);
            this.logs_IF100.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.logs_IF100.Name = "logs_IF100";
            this.logs_IF100.Size = new System.Drawing.Size(231, 129);
            this.logs_IF100.TabIndex = 7;
            this.logs_IF100.Text = "";
            this.logs_IF100.TextChanged += new System.EventHandler(this.logs_IF100_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(125, 113);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "SPS101";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 113);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "IF100";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(297, 52);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "DiSUcord";
            // 
            // logs
            // 
            this.logs.Location = new System.Drawing.Point(370, 8);
            this.logs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.logs.Name = "logs";
            this.logs.Size = new System.Drawing.Size(227, 106);
            this.logs.TabIndex = 11;
            this.logs.Text = "";
            // 
            // logs_currentlyConnected
            // 
            this.logs_currentlyConnected.Location = new System.Drawing.Point(183, 266);
            this.logs_currentlyConnected.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.logs_currentlyConnected.Name = "logs_currentlyConnected";
            this.logs_currentlyConnected.Size = new System.Drawing.Size(231, 129);
            this.logs_currentlyConnected.TabIndex = 12;
            this.logs_currentlyConnected.Text = "";
            this.logs_currentlyConnected.TextChanged += new System.EventHandler(this.logs_currentlyConnected_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 325);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Currently Connected";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 470);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.logs_currentlyConnected);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.logs_IF100);
            this.Controls.Add(this.logs_SPS101);
            this.Controls.Add(this.button_listen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_port);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_listen;
        private System.Windows.Forms.RichTextBox logs_SPS101;
        private System.Windows.Forms.RichTextBox logs_IF100;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox logs;
        private System.Windows.Forms.RichTextBox logs_currentlyConnected;
        private System.Windows.Forms.Label label6;
    }
}

