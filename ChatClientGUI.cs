using Communications;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace ChatClient
{
    /// <summary>
    /// GUI that allows a user to connect to a remote server over TCP. Networking handled by a networking object. 
    /// </summary>
    public partial class ChatClientForm : Form
    {
        private Networking networking_channel;
        private readonly ILogger<ChatClientForm> _logger;
        

        /// <summary>
        /// Constructor to initialize chat client GUI.
        /// </summary>
        /// <param name="logger"></param>
        public ChatClientForm(ILogger<ChatClientForm> logger)
        {
            InitializeComponent();

            _logger = logger;

            networking_channel = new Networking(_logger, onConnect, onDisconnect, onMessage, '\n');
            
        }

        /// <summary>
        /// Perform some additional actions when messaging the server.
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="message"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void onMessage(Networking channel, string message)
        {
            Invoke(() => { this.MessageBox.Items.Add(message); });
        }

        /// <summary>
        /// Perform some actions when disconnecting from the remote server.
        /// </summary>
        /// <param name="channel"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void onDisconnect(Networking channel)
        {
            _logger.Log(LogLevel.Information, "Client disconnected");
        }

        /// <summary>
        /// When connecting to the server, perform some additional actions like logging, updating the GUI, and sending information out.
        /// </summary>
        /// <param name="channel"></param>
        private void onConnect(Networking channel)
        {
            _logger.Log(LogLevel.Information, "Client connected");
            Invoke(() => { this.MessageBox.Items.Add($"Connection is successful! Connected to {networking_channel.tcpClient.Client.RemoteEndPoint}"); });
            channel.Send($"Command Name {UserNameTextBox.Text}"); //Update server with clients name
        }

        /// <summary>
        /// Connect to the server using relevant info input into the GUI from a user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectServerButton_Click(object sender, EventArgs e)
        {
            MessageBox.Text = "Trying to connect";
            string host = ServerNameTextBox.Text;

            if (UserNameTextBox.Text.Length > 0) //User sets username, if nothing entered, then use default from networking obj constructor
            {
                networking_channel.ID = UserNameTextBox.Text;
            }

            try
            {
                networking_channel.Connect(host, 11000);
            }
            catch (Exception ex)
            {
                MessageBox.Text = "Connection is unsuccessful !";
                MessageBox.Text = ex.Message;

            }
        }

            
            
        
        /// <summary>
        /// Ping the server and have it send over the information of the other connected clients.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RetrieveParticipantsButton_Click(object sender, EventArgs e)
        {
            networking_channel.Send("Command Participants");
            bool infinite = true;
            networking_channel.ClientAwaitMessagesAsync(infinite);
            if (networking_channel.messageToRead.Contains("Command Participants"))
            {
                string participantNames = networking_channel.messageToRead.Substring(20, networking_channel.messageToRead.Length); //Get participants names
                string[] namesList = Regex.Split(participantNames, @"(?:,\s+)|(['""].+['""])(?:,\s+)");
                foreach (string name in namesList) //Add the names to the participants list box
                {
                    ClientsListBox.Items.Add(name);

                }
            }

        }

        /// <summary>
        /// Event handler for any keys getting pressed. Needed to make ProcessCmdKey work for keyboard shortcuts of ChatServer GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChatServerGUI_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        /// <summary>
        /// processes key presses using keydata. Currently allows pressing enter to send a message.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Enter)
            {
                networking_channel.Send(MessageBoxTextBox.Text);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}