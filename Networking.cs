using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Communications
{
    /// <summary>
    /// This networking object is used to create a connection between a Chat Server and a Chat client. The two connect and send data over TCP. They asyncrhonously wait
    /// for the other connection.
    /// </summary>
    public class Networking
    {
        private CancellationTokenSource _WaitForCancellation;

        private TcpClient _tcpClient;

        public TcpClient tcpClient
        {
            get { return this._tcpClient; }
            set { this._tcpClient = value; }
        }

        private string _messageToRead;

        public string messageToRead
        {
            get { return this._messageToRead; }
            set { this._messageToRead = value; }
        }

        /// <summary>
        /// Name of the client. Default is tcp client RemoteEndPoint
        /// </summary>
        private string _ID;

        /// <summary>
        /// Property for _ID member variable. 
        /// </summary>
        public string ID
        {
            get { return this._ID; }
            set { this._ID = value; }
        }

        private ILogger logger;
        private ReportConnectionEstablished onConnect;
        private char terminationChar;
        private ReportMessageArrived onMessage;
        private ReportDisconnect onDisconnect;

        public delegate void ReportMessageArrived(Networking channel, string message);
        public delegate void ReportDisconnect(Networking channel);
        public delegate void ReportConnectionEstablished(Networking channel);


        /// <summary>
        /// Constructor for networking object. Need the logger to log information about what the chat server and clients are doing. The other delegates help pass information about
        /// the networking when certain actions are performed like making a connection or sending a message.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="onConnect"></param>
        /// <param name="onDisconnect"></param>
        /// <param name="onMessage"></param>
        /// <param name="terminationCharacter"></param>
        public Networking(ILogger logger, 
                          ReportConnectionEstablished onConnect, 
                          ReportDisconnect onDisconnect, 
                          ReportMessageArrived onMessage, 
                          char terminationCharacter)
        {
            this.logger = logger;
            this.onConnect = onConnect;
            this.terminationChar = terminationCharacter;
            this.onMessage = onMessage;
            this.onDisconnect = onDisconnect;
        }

        /// <summary>
        /// Make a simple connection over TCP with a given host (name or IP address) and a given port to listen on.
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        public void Connect(string host, int port)
        {
            try
            {
                tcpClient = new TcpClient(host, port);
                onConnect(this);
            }
            catch (Exception e)
            {

            }

        }

        /// <summary>
        /// Client will wait for messages to be sent to it.
        /// If infinite is true, then the method will infinitely wait for messages to arrive; even after one message has been received, it continues listening for messages.
        /// On the other hand, if infinite is false, then the method will loop until an entire message has been received.It still loops until it receives the termination character; 
        /// the difference is that once it receives the termination character, it will not continue to wait for more messages.
        /// </summary>
        /// <param name="infinite"></param>
        public async void ClientAwaitMessagesAsync(bool infinite = true)
        {
            try
            {
                StringBuilder dataBacklog = new StringBuilder();
                byte[] buffer = new byte[4096];
                NetworkStream stream = tcpClient.GetStream();

                if (stream == null) return;

                if (infinite)
                {

                    while (infinite)
                    {
                        int NumBytesInBuff = await stream.ReadAsync(buffer, 0, buffer.Length);
                        string dataInBuff = Encoding.UTF8.GetString(buffer, 0, NumBytesInBuff);
                        dataBacklog.Append(dataInBuff);


                        CheckForMessage(dataBacklog, out string returnMessage); //THIS handles if there is one or multiple messages

                        messageToRead = returnMessage;
                    }
                    while (!infinite) //If infinite is false, loop for one message -> until reaching one newline
                    {
                        int NumBytesInBuff = await stream.ReadAsync(buffer, 0, buffer.Length);
                        string dataInBuff = Encoding.UTF8.GetString(buffer, 0, NumBytesInBuff);
                        dataBacklog.Append(dataInBuff);


                        CheckForMessage(dataBacklog, out string returnMessage);

                        messageToRead = returnMessage;
                    }
                }
            }
            catch (Exception ex) //Disconnect when networking object was waiting to read data
            {
            }
        }

        /// <summary>
        /// Helper method for ClientAwaitMessagesAsync
        /// Given a string (actually a string builder object)
        /// check to see if it contains one or more messages as defined by
        /// our protocol (newline '\n').
        /// </summary>
        /// <param name="data"> all characters encountered so far</param>
        /// <param name="infinite"> Should we listen infinitely or just for one message.</param>
        private void CheckForMessage(StringBuilder dataInBuff, out string returnMessage)
        {
            returnMessage = "";

            string allData = dataInBuff.ToString();
            int terminator_position = allData.IndexOf(terminationChar);
            bool foundOneMessage = false;

            while (terminator_position >= 0)
            {
                foundOneMessage = true;

                //Return message is how we get the information out from the method.
                returnMessage = allData.Substring(0, terminator_position + 1); //Only until first newline/termination character defined in the GUI
                dataInBuff.Remove(0, terminator_position + 1);

                allData = dataInBuff.ToString();
                terminator_position = allData.IndexOf(terminationChar);
            }

        }

        /// <summary>
        /// Server will wait for clients to connect.
        /// </summary>
        /// <param name="port"></param>
        /// <param name="infinite"></param>
        public async void WaitForClients(int port, bool infinite)
        {
            TcpListener network_listener = new TcpListener(IPAddress.Any, port);

            try
            {
                network_listener.Start(); 

                _WaitForCancellation = new();

                while (infinite)
                {
                    TcpClient connection = await network_listener.AcceptTcpClientAsync(_WaitForCancellation.Token);

                    Networking newClientNetworking = new Networking(logger, onConnect, onDisconnect, onMessage, terminationChar);
                    newClientNetworking.tcpClient = connection;
                    newClientNetworking.Send($"\n ** New Connection ** Accepted From {connection.Client.RemoteEndPoint} to {connection.Client.LocalEndPoint}\n");
                    //Thread newNetworkThread = new Thread(ClientAwaitMessagesAsync(infinite));

                }

            }
            catch (Exception ex)
            {
                network_listener.Stop();
            }
        }

        /// <summary>
        /// Cancellation token to cancel WaitForClients() method.
        /// </summary>
        public void StopWaitingForClients()
        {
            _WaitForCancellation.Cancel();
        }

        /// <summary>
        /// Closes the connection to the remote host.
        /// </summary>
        public void Disconnect()
        {
            tcpClient.Close();
        }

        /// <summary>
        /// Sends parameter text to server/client.
        /// </summary>
        /// <param name="text"></param>
        public async void Send(string text)
        {

            // Encode and Send the message:
            byte[] messageBytes = Encoding.UTF8.GetBytes(text + terminationChar);

            try
            {
                await tcpClient.GetStream().WriteAsync(messageBytes, 0, messageBytes.Length);
            }
            catch (Exception ex) //Remote client disconnected as message was being written
            {
            }
        }


    } //End of class
} //End of namespace