using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace server
{
    

    public partial class Form1 : Form
    {
        private List<string> usernames = new List<string>();
        public List<string> SPS101_Subs = new List<string>();//holds sps101 subscriptions
        public List<string> IF100_Subs = new List<string>();//holds if100 subscriptions
        private Dictionary<Socket, string> clientUsernames = new Dictionary<Socket, string>();//holds the active users
        private Dictionary<Socket, string> client_database = new Dictionary<Socket, string>();//holds all the users that are connected
        //If previously a connection has established and user has subscribed a channel or both we need to hold the data of this client database hold these information 


        private bool check_for_usernames(String username, Dictionary<Socket, string> client_database) //Check that ensures the username does not exist in the database 
        {
            bool checkForDuplicate = false;
            foreach (string kvp in client_database.Values)
            {
                if(kvp==username)
                {
                    return true;
                }

            }
            return checkForDuplicate;
        }
        //creating a new socket and initializing clientsocket list, terminating and listening variables
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> clientSockets = new List<Socket>();

        bool terminating = false;
        bool listening = false;

        public Form1()//initializes the form
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void button_listen_Click(object sender, EventArgs e)//listens on specified port
        {
            int serverPort;

            if(Int32.TryParse(textBox_port.Text, out serverPort))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(3);

                listening = true;
                button_listen.Enabled = false;

                Thread acceptThread = new Thread(Accept);
                acceptThread.Start();

                logs.AppendText("Started listening on port: " + serverPort + "\n");

            }
            else
            {
                logs.AppendText("Please check port number \n");
            }
        }

        private void Accept()//accepting the received connection
        {
            while(listening)
            {
                try
                {
                    Socket newClient = serverSocket.Accept();
                    clientSockets.Add(newClient);

                    Thread receiveThread = new Thread(() => Receive(newClient)); // updated
                    receiveThread.Start();
                }
                catch
                {
                    if (terminating)
                    {
                        listening = false;
                    }
                    else
                    {
                        logs.AppendText("The socket stopped working.\n");

                    }

                }
            }
        }

        private void Receive(Socket thisClient) // receiving messages from client, all the operations held here, usernames are set, messages are evaluated here, connections to
            //the channels are established here
        {
            string username=""; 
            bool connected = true;
            string selected_channel = "";

            while(connected && !terminating)
            {
                try
                {
                    Byte[] buffer = new Byte[64];
                    thisClient.Receive(buffer);

                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));

                    if (username=="")//if username is empty
                    {
                    
                        if(!check_for_usernames(incomingMessage, client_database))//if this username exists in our database
                        {
                            username = incomingMessage;
                            logs.AppendText("A client is connected.\n");
                            if (SPS101_Subs.Contains(username))
                            {
                                logs.AppendText(username + " connected to the channel SPS101" + "\n");
                                logs_currentlyConnected.AppendText(username + ": SPS101" + "\n");
                                string message = "Connection to SPS101 channel has established\n";
                                Byte[] buffer7 = Encoding.Default.GetBytes(message);

                                try
                                {
                                    thisClient.Send(buffer7);
                                }
                                catch
                                {
                                    logs.AppendText("There is a problem!\n");
                                    terminating = true;
                                    textBox_port.Enabled = true;
                                    button_listen.Enabled = true;
                                    serverSocket.Close();
                                }
                            }
                            if (IF100_Subs.Contains(username))
                            {
                                logs.AppendText(username + " connected to the channel IF100" + "\n");
                                logs_currentlyConnected.AppendText(username + ": IF100" + "\n");
                                string message = "Connection to IF100 channel has established\n";
                                Byte[] buffer8 = Encoding.Default.GetBytes(message);

                                try
                                {
                                    thisClient.Send(buffer8);
                                }
                                catch
                                {
                                    logs.AppendText("There is a problem!\n");
                                    terminating = true;
                                    textBox_port.Enabled = true;
                                    button_listen.Enabled = true;
                                    serverSocket.Close();
                                }
                            }
                            clientUsernames.Add(thisClient,username);
                            client_database.Add(thisClient, username);
                            logs.AppendText(incomingMessage + "\n");
                            
                        }
                        else//if username exists in our database related errors
                        {

                            string message = "Username exists in the database you can not use this username\n";
                            Byte[] buffer1 = Encoding.Default.GetBytes(message);

                            try
                            {
                                thisClient.Send(buffer1);
                            }
                            catch
                            {
                                logs.AppendText("There is a problem! Unable send the username error to client\n");
                                terminating = true;
                                textBox_port.Enabled = true;
                                button_listen.Enabled = true;
                                serverSocket.Close();
                            }
        

                                

                         
                            thisClient.Close();
                            clientSockets.Remove(thisClient);
                            connected = false;

                        }
                        

                    }
                    else if(incomingMessage=="Disconnect\n")//disconnection part
                    {
                        thisClient.Close();
                        logs_currentlyConnected.Clear();
                        if(clientSockets.Contains(thisClient))
                        {
                            clientSockets.Remove(thisClient);
                        }

                        if (usernames.Contains(username))
                        {
                            usernames.Remove(username);
                        }

                        if (clientUsernames.ContainsKey(thisClient))
                        {
                            clientUsernames.Remove(thisClient);
                        }
                        
                        foreach (string kvp in clientUsernames.Values)//after this connection we are updating the currently connected textbox
                        {
                            if((SPS101_Subs.Contains(kvp))&& (IF100_Subs.Contains(kvp)))
                            {
                                logs_currentlyConnected.AppendText(kvp + ": SPS101" + Environment.NewLine);
                                logs_currentlyConnected.AppendText(kvp + ": IF100" + Environment.NewLine);

                            }
                            else if((SPS101_Subs.Contains(kvp))&&!(IF100_Subs.Contains(kvp)))
                            {
                                logs_currentlyConnected.AppendText(kvp+": SPS101" + Environment.NewLine);
                            }
                            else if(!(SPS101_Subs.Contains(kvp)) && (IF100_Subs.Contains(kvp)))
                            {
                                logs_currentlyConnected.AppendText(kvp+": IF100" + Environment.NewLine);
                            }
                            
                        }

                    }
                    else if (incomingMessage.Substring(0, 11) == "Unsubscribe")//handling unsubscribe operation
                    {//dividing into channels to evaluate
                        if(SPS101_Subs.Contains(username) && IF100_Subs.Contains(username))
                        {
                            if (incomingMessage.Substring(13, 6) == "SPS101")
                            {
                                SPS101_Subs.Remove(username);
                                logs_currentlyConnected.Clear();
                                foreach (string user in SPS101_Subs)
                                {
                                    logs_currentlyConnected.AppendText(user+": SPS101" + Environment.NewLine);
                                }
                                foreach (string user in IF100_Subs)
                                {
                                    logs_currentlyConnected.AppendText(user+": IF100" + Environment.NewLine);
                                }
                                logs.AppendText(username + " removed from channel SPS101 " + "\n");
                                string message = "Unsubscribed from channel SPS101\n";
                                Byte[] buffer2 = Encoding.Default.GetBytes(message);

                                try
                                {
                                    thisClient.Send(buffer2);
                                }
                                catch
                                {
                                    logs.AppendText("There is a problem! Unable send the username error to client\n");
                                    terminating = true;
                                    textBox_port.Enabled = true;
                                    button_listen.Enabled = true;
                                    serverSocket.Close();
                                }

                            }
                            else
                            {
                                IF100_Subs.Remove(username);
                                logs_currentlyConnected.Clear();
                                foreach (string user in SPS101_Subs)
                                {
                                    logs_currentlyConnected.AppendText(user + ": SPS101" + Environment.NewLine);
                                }
                                foreach (string user in IF100_Subs)
                                {
                                    logs_currentlyConnected.AppendText(user + ": IF100" + Environment.NewLine);
                                }
                                logs.AppendText(username + " removed from channel IF100 " + "\n");
                                string message = "Unsubscribed from channel IF100\n";
                                Byte[] buffer3 = Encoding.Default.GetBytes(message);
                                
                                try
                                {
                                    thisClient.Send(buffer3);
                                }
                                catch
                                {
                                    logs.AppendText("There is a problem!\n");
                                    terminating = true;
                                    textBox_port.Enabled = true;
                                    button_listen.Enabled = true;
                                    serverSocket.Close();
                                }

                                

                            }

                        }
                        else if(!SPS101_Subs.Contains(username) && IF100_Subs.Contains(username))
                        {
                            IF100_Subs.Remove(username);
                            usernames.Remove(username);

                            logs_currentlyConnected.Clear();
                            foreach (string user in SPS101_Subs)
                            {
                                logs_currentlyConnected.AppendText(user + ": SPS101" + Environment.NewLine);
                            }
                            foreach (string user in IF100_Subs)
                            {
                                logs_currentlyConnected.AppendText( user + ": IF100" + Environment.NewLine);
                            }
                            logs.AppendText(username + " removed from channel IF100 " + "\n");
                            string message = "Unsubscribed from channel IF100\n";
                            Byte[] buffer4 = Encoding.Default.GetBytes(message);
                            
                            try
                            {
                                thisClient.Send(buffer4);
                            }
                            catch
                            {
                                logs.AppendText("There is a problem!\n");
                                terminating = true;
                                textBox_port.Enabled = true;
                                button_listen.Enabled = true;
                                serverSocket.Close();
                            }

                            


                        }
                        else if(SPS101_Subs.Contains(username) && !IF100_Subs.Contains(username))
                        {
                            SPS101_Subs.Remove(username);
                            usernames.Remove(username);
                            logs_currentlyConnected.Clear();
                            foreach (string user in SPS101_Subs)
                            {
                                logs_currentlyConnected.AppendText(user+": SPS101" + Environment.NewLine);
                            }
                            foreach (string user in IF100_Subs)
                            {
                                logs_currentlyConnected.AppendText(user+": IF100" + Environment.NewLine);
                            }
                            logs.AppendText(username + " removed from channel SPS101 " + "\n");
                            string message = "Unsubscribed from channel SPS101\n";
                            Byte[] buffer5 = Encoding.Default.GetBytes(message);
                            //remove from logs
                            
                            try
                            {
                                thisClient.Send(buffer5);
                            }
                            catch
                            {
                                logs.AppendText("There is a problem!\n");
                                terminating = true;
                                textBox_port.Enabled = true;
                                button_listen.Enabled = true;
                                serverSocket.Close();
                            }

                           

                        }
                       
                    }
                    else if(incomingMessage.Substring(0,9) == "Subscribe")
                    {
                        //connection to server specification select SPS101 or IF100 or both 
                        //logs.AppendText(incomingMessage);
                        if (incomingMessage.Substring(11, 6) == "SPS101" && !SPS101_Subs.Contains(username))
                        {
                            SPS101_Subs.Add(username);
                            logs.AppendText(username + " connected to the channel SPS101" + "\n");
                            logs_currentlyConnected.AppendText(username + ": SPS101" + "\n");



                            string message = "Connection to SPS101 channel has established\n";
                            Byte[] buffer7 = Encoding.Default.GetBytes(message);

                            try
                            {
                                thisClient.Send(buffer7);
                            }
                            catch
                            {
                                logs.AppendText("There is a problem!\n");
                                terminating = true;
                                textBox_port.Enabled = true;
                                button_listen.Enabled = true;
                                serverSocket.Close();
                            }




                        }
                        else if (incomingMessage.Substring(11, 5) == "IF100"&& !IF100_Subs.Contains(username))
                        {
                            IF100_Subs.Add(username);
                            logs.AppendText(username + " connected to the channel IF100" + "\n");
                            logs_currentlyConnected.AppendText(username + ": IF100" + "\n");


                            string message = "Connection to IF100 channel has established\n";
                            Byte[] buffer8 = Encoding.Default.GetBytes(message);

                            try
                            {
                                thisClient.Send(buffer8);
                            }
                            catch
                            {
                                logs.AppendText("There is a problem!\n");
                                terminating = true;
                                textBox_port.Enabled = true;
                                button_listen.Enabled = true;
                                serverSocket.Close();
                            }



                        }
                    }
                    else//user sends a specified message to the specified channel with indicating the channel
                    {
                        if(SPS101_Subs.Contains(username)&& IF100_Subs.Contains(username))
                        {
                            if (incomingMessage.EndsWith("1"))
                            { 
                                
                                logs_IF100.AppendText(incomingMessage.Substring(0, incomingMessage.Length - 1) + "\n");
                                logs.AppendText( username+ "send message to " + selected_channel+ "which is: " + incomingMessage.Substring(0,incomingMessage.Length-1) + "\n");
                                Byte[] buff = Encoding.Default.GetBytes(incomingMessage.Substring(0, incomingMessage.Length - 1)+"1");
                                foreach (var kvp in clientUsernames)
                                {
                                    if (IF100_Subs.Contains(kvp.Value))
                                    {
                                        try
                                        {

                                            kvp.Key.Send(buff);
                                        }
                                        catch
                                        {
                                            logs.AppendText("1There is a problem! Check the connection...\n");
                                            terminating = true;
                                            textBox_port.Enabled = true;
                                            button_listen.Enabled = true;
                                            serverSocket.Close();
                                        }
                                    }

                                }

                            }
                            else
                            {
                                logs_SPS101.AppendText(incomingMessage.Substring(0, incomingMessage.Length - 1) + "\n");
                                logs.AppendText(username + "send message to " + selected_channel + "which is: " + incomingMessage.Substring(0, incomingMessage.Length-1) + "\n");
                                Byte[] buff = Encoding.Default.GetBytes(incomingMessage.Substring(0, incomingMessage.Length - 1)+"2");
                                foreach (var kvp in clientUsernames)
                                {
                                    if (SPS101_Subs.Contains(kvp.Value))
                                    {
                                        try
                                        {

                                            kvp.Key.Send(buff);
                                        }
                                        catch
                                        {
                                            logs.AppendText("2There is a problem! Check the connection...\n");
                                            terminating = true;
                                            textBox_port.Enabled = true;
                                            button_listen.Enabled = true;
                                            serverSocket.Close();
                                        }
                                    }

                                }

                            }

                        }
                        else if (!SPS101_Subs.Contains(username) && IF100_Subs.Contains(username))
                        {
                            logs_IF100.AppendText(incomingMessage.Substring(0, incomingMessage.Length - 1) + "\n");
                            logs.AppendText(username + "send message to IF100 "  + "which is: " + incomingMessage.Substring(0, incomingMessage.Length-1) + "\n");
                            Byte[] buff = Encoding.Default.GetBytes(incomingMessage.Substring(0, incomingMessage.Length - 1)+"1");
                            foreach (var kvp in clientUsernames)
                            {
                                if (IF100_Subs.Contains(kvp.Value))
                                {
                                    try
                                    {

                                        kvp.Key.Send(buff);
                                    }
                                    catch
                                    {
                                        logs.AppendText("3There is a problem! Check the connection...\n");
                                        terminating = true;
                                        textBox_port.Enabled = true;
                                        button_listen.Enabled = true;
                                        serverSocket.Close();
                                    }
                                }

                            }


                        }
                        else if (SPS101_Subs.Contains(username) && !IF100_Subs.Contains(username))
                        {
                            logs_SPS101.AppendText(incomingMessage.Substring(0, incomingMessage.Length - 1) + "\n");          
                            logs.AppendText(username + "send message to SPS101 " + "which is: " + incomingMessage.Substring(0, incomingMessage.Length-1) + "\n");
                            Byte[] buff = Encoding.Default.GetBytes(incomingMessage.Substring(0, incomingMessage.Length - 1)+"2");
                            foreach (var kvp in clientUsernames)
                            {
                                if (SPS101_Subs.Contains(kvp.Value))
                                {
                                    try
                                    {

                                        kvp.Key.Send(buff);
                                    }
                                    catch
                                    {
                                        logs.AppendText("4There is a problem! Check the connection...\n");
                                        terminating = true;
                                        textBox_port.Enabled = true;
                                        button_listen.Enabled = true;
                                        serverSocket.Close();
                                    }
                                }

                            }


                        }

                    }

                    
                   

                }
                catch
                {
                    if(!terminating)//related error to the try block
                    {
                        logs.AppendText("A client has disconnected\n");
                        
                    }
                    thisClient.Close();
                    clientSockets.Remove(thisClient);
                    connected = false;
                }
            }
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)//form closing
        {
            listening = false;
            terminating = true;
            Environment.Exit(0);
        }


        private void logs_TextChanged(object sender, EventArgs e)
        {

        }

        private void logs_currentlyConnected_TextChanged(object sender, EventArgs e)
        {

        }

        private void logs_IF100_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
