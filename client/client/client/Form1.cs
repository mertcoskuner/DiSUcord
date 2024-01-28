using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace client
{
    public partial class Form1 : Form
    {

        bool terminating = false;
        bool connected = false;
        Socket clientSocket;

        public Form1()//initializes the components of the form, disables the buttons untill the connection is established
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
            if_status.AppendText("unsubscribed"); 
            sps_status.AppendText("unsubscribed");
            textBox_message_if.Enabled = false;
            button_send_if.Enabled = false;
            textBox_message_sps.Enabled = false;
            button_send_sps.Enabled = false;
            button_sps_subscribe.Enabled = false;
            button_if_subscribe.Enabled = false;
            button_sps_unsubscribe.Enabled = false;
            button_if_unsubscribe.Enabled = false;

        }

        private void button_connect_Click(object sender, EventArgs e)//establishes the connection and enables the buttons and text boxes
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string IP = textBox_ip.Text;
            string username = "Client "+textBox_username.Text;

            Byte[] buffer1 = Encoding.Default.GetBytes(username);

            int portNum;
            if(Int32.TryParse(textBox_port.Text, out portNum))
            {
                try
                {
                    clientSocket.Connect(IP, portNum);
                    button_connect.Enabled = false;
                    textBox_message_if.Enabled = true;
                    button_send_if.Enabled = true;
                    textBox_message_sps.Enabled = true;
                    button_send_sps.Enabled = true;
                    button_sps_subscribe.Enabled = true;
                    button_if_subscribe.Enabled = true;
                    button_sps_unsubscribe.Enabled = true;
                    button_if_unsubscribe.Enabled = true;
                    connected = true;
                    clientSocket.Send(buffer1);
                    logs_connection.AppendText("Connected to the server!\n");
                    button_disconnect.Enabled = true;

                    Thread receiveThread = new Thread(Receive);
                    receiveThread.Start();

                }
                catch
                {
                    logs_connection.AppendText("Could not connect to the server!\n");
                }
            }
            else
            {
                logs_connection.AppendText("Check the port\n");
            }

        }

        private void Receive()//receives messages and feedback from server and prints to the corresponding text boxes
        {
            while(connected)
            {
                try
                {
                    Byte[] buffer = new Byte[64];
                    clientSocket.Receive(buffer);

                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));
                    if(incomingMessage== "Username exists in the database you can not use this username\n")
                    {
                        logs_connection.AppendText(incomingMessage);
                        ////write
                    }
                    else if(incomingMessage == "Unsubscribed from channel SPS101\n")
                    {
                        sps_status.Clear();
                        sps_status.AppendText("Unsubscribed");
                        logs_connection.AppendText(incomingMessage);
                    }
                    else if (incomingMessage == "Unsubscribed from channel IF100\n")
                    {
                        if_status.Clear();
                        if_status.AppendText("Unsubscribed");
                        logs_connection.AppendText(incomingMessage);
                    }
                    else if(incomingMessage == "Connection to both channels has established. Please specify your channel to send message\n")
                    {
                        sps_status.Clear();
                        if_status.Clear();
                        sps_status.AppendText("Subscribed");
                        if_status.AppendText("Subscribed");
                        logs_connection.AppendText(incomingMessage);
                    }
                    else if (incomingMessage == "Connection to SPS101 channel has established\n")
                    {
                        sps_status.Clear();
                        sps_status.AppendText("Subscribed");
                        logs_connection.AppendText(incomingMessage);
                    }
                    else if (incomingMessage == "Connection to IF100 channel has established\n")
                    {
                        if_status.Clear();
                        if_status.AppendText("Subscribed");
                        logs_connection.AppendText(incomingMessage);
                    }
                    else
                    {
                        if(incomingMessage.EndsWith("1"))
                        {
                            logs_if.AppendText(incomingMessage.Substring(0, incomingMessage.Length - 1)+"\n");
                        }
                        else
                        {
                            logs_sps.AppendText(incomingMessage.Substring(0, incomingMessage.Length - 1) + "\n");
                        }
                    }

                }
                catch
                {
                    if (!terminating)
                    {
                        logs_connection.AppendText("The connection with the server has ended\n");
                        button_connect.Enabled = true;
                        textBox_message_if.Enabled = false;
                        button_send_if.Enabled = false;
                        textBox_message_sps.Enabled = false;
                        button_send_sps.Enabled = false;
                    }

                    clientSocket.Close();
                    connected = false;
                }

            }
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)//closes the form starts terminating
        {
            connected = false;
            terminating = true;
            Environment.Exit(0);
        }
        /////////sending functions
        private void button_send_if_Click(object sender, EventArgs e)//sends the message from rich textboxes of sps and if it checks the subscription
        {


            if (string.Equals(if_status.Text, "Subscribed", StringComparison.OrdinalIgnoreCase))
            {
                string message = textBox_message_if.Text;

                if (message != "" && message.Length <= 64)
                {
                    string username = textBox_username.Text;
                    message = "Client: " + username + ": " + message + "1";
                    Byte[] buffer = Encoding.Default.GetBytes(message);
                    clientSocket.Send(buffer);
                    textBox_message_if.Clear();
                }
            }
 

        }

        private void button_send_sps_Click(object sender, EventArgs e)//sends the message from rich textboxes of sps and if it checks the subscription
        {
            if (string.Equals(sps_status.Text, "Subscribed", StringComparison.OrdinalIgnoreCase))
            {
                string message = textBox_message_sps.Text;

                if (message != "" && message.Length <= 64)
                {
                    string username = textBox_username.Text;
                    message = "Client: " + username + ": " + message + "2";
                    Byte[] buffer = Encoding.Default.GetBytes(message);
                    clientSocket.Send(buffer);
                    textBox_message_sps.Clear();
                }
            }




        }
        ///////subscribe unsubscribe buttons

        private void button_if_subscribe_Click(object sender, EventArgs e)//sends subscription message to server
        {
            string message = "Subscribe: IF100\n";

            Byte[] buffer = Encoding.Default.GetBytes(message);
            clientSocket.Send(buffer);

        }

        private void button_sps_unsubscribe_Click(object sender, EventArgs e)//sends unsubscription message to the server
        {
            if (string.Equals(sps_status.Text, "Subscribed", StringComparison.OrdinalIgnoreCase)) {
                string message = "Unsubscribe: SPS101\n";

                Byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
            }
        }


        private void button_if_unsubscribe_Click(object sender, EventArgs e)//sends unsubscription message to the server
        {
            if (string.Equals(if_status.Text, "Subscribed", StringComparison.OrdinalIgnoreCase))
            {
                string message = "Unsubscribe: IF100\n";

                Byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
            }
               
        }

        private void button_sps_subscribe_Click_1(object sender, EventArgs e)//sends subscription message to the server
        {
            string message = "Subscribe: SPS101\n";

            Byte[] buffer = Encoding.Default.GetBytes(message);
            clientSocket.Send(buffer);
        }

        private void button_disconnect_Click(object sender, EventArgs e)//disconnects the client from the server and disables the unused buttons and textboxes
        {
            string message = "Disconnect\n";

            Byte[] buffer = Encoding.Default.GetBytes(message);
            clientSocket.Send(buffer);
       
            button_connect.Enabled = true;
            button_disconnect.Enabled = false;
            textBox_message_if.Enabled = false;
            button_send_if.Enabled = false;
            textBox_message_sps.Enabled = false;
            button_send_sps.Enabled = false;
            button_sps_subscribe.Enabled = false;
            button_if_subscribe.Enabled = false;
            button_sps_unsubscribe.Enabled = false;
            button_if_unsubscribe.Enabled = false;
        }

        private void logs_connection_TextChanged(object sender, EventArgs e)
        {

        }


        ///////////////////////////////////
    }

}
