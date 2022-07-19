using Communications;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Sockets;

namespace ChatServer
{
    /// <summary>
    /// Chat server GUI to make connecting to server easy to monitor.
    /// </summary>
    public partial class ChatServerForm : Form
    {
        private readonly ILogger<ChatServerForm> _logger;
        string host; 
        string serverIPAddress; 

        /// <summary>
        /// A list of all clients currently connected
        /// </summary>
        private List<Networking> clients = new();

        /// <summary>
        /// Constructor to initialize the chat server. For example, take the server name from the computer currently running the server GUI program.
        /// </summary>
        /// <param name="logger"></param>
        public ChatServerForm(ILogger<ChatServerForm> logger)
        {
            InitializeComponent();
            
            _logger = logger;

            host = Dns.GetHostName();
            ServerNameTextBox.Text = host;

            serverIPAddress = "localhost"; //Default if for some reason cannot get machine's IP address
            foreach (var ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    serverIPAddress = ip.ToString();
                }
            }
            ServerIPAddressTextBox.Text = serverIPAddress;
        }

        /// <summary>
        /// Additional actions to take when a client messages the server.
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="message"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void onMessage(Networking channel, string message)
        {

            _logger.Log(LogLevel.Information, "Server messaged client(s)");

            bool infinite = true;
            foreach (Networking networking_channel in clients)
            {
                networking_channel.WaitForClients(11000, infinite);
                networking_channel.Send(channel.ID + message);
            }
        }

        /// <summary>
        /// Additional actions to take when a client disconnects from the server.
        /// </summary>
        /// <param name="channel"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void onDisconnect(Networking channel)
        {
            _logger.Log(LogLevel.Information, "Client disconnected from server");
        }

        /// <summary>
        /// Updates various GUI items and variables when a client connects to the server. Add any newly connected clients to list of clients
        /// </summary>
        /// <param name="channel"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void onConnect(Networking channel)
        {
            _logger.Log(LogLevel.Information, "Client connected to server");
            Invoke(() => { this.ParticipantsListBox.Items.Add(channel.ID); });
        }

        private void ShutdownServerButton_Click(object sender, EventArgs e)
        {
            foreach (Networking networking_channel in clients)
            {
                networking_channel.Disconnect();
                onDisconnect(networking_channel);
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
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}