using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoAn_Socket
{
    class Client
    {
        private Socket client;
        Thread handler;
        private List<string> lBlacklist;
        private string filename;
        private IOBlacklist io;

        public Client(Socket client)
        {
            this.client = client;
            this.handler = null;
            this.io = new IOBlacklist("blacklist.conf");
            this.lBlacklist = this.io.ReadBlackList();
        }
        //
        // Summary:
        //     Start handling request from browser.
        //     Because there are many request from server at the same time
        //     We use Thread to handle request
        public void StartHandling()
        {
            handler = new Thread(Handler);
            handler.IsBackground = true;
            handler.Start();
        }

        private void Handler()
        {
            bool receiveRequest = true;
            string EOL = "\r\n";

            string requestPayload = "";
            string requestTempLine = "";
            List<string> requestLines = new List<string>();
            byte[] requestBuffer = new byte[1];
            byte[] responseBuffer = new byte[1];

            requestLines.Clear();

            try
            {
                // When a browser send request to Proxy Server
                // Proxy Server receive it...
                while (receiveRequest)
                {
                    this.client.Receive(requestBuffer);
                    string fromByte = ASCIIEncoding.ASCII.GetString(requestBuffer);
                    requestPayload += fromByte;
                    requestTempLine += fromByte;

                    if (requestTempLine.EndsWith(EOL))
                    {
                        requestLines.Add(requestTempLine.Trim());
                        requestTempLine = "";
                    }

                    if (requestPayload.EndsWith(EOL + EOL))
                    {
                        receiveRequest = false;
                    }
                }

                // Parse string to get URL, host and path
                string strUrl = requestLines[0].Split(' ')[1];
                Uri uri = new Uri(strUrl);
                string remoteHost = uri.Host;
                string requestFile = uri.PathAndQuery;

                // We have a blacklist, which blocked websites to access
                // This will check if URL has prefix www. or not
                // For example: hcmus.edu.vn => www.hcmus.edu.vn (handle this)
                string aliasHost = null;
                string www = "www.";
                if (remoteHost.IndexOf("www.") != -1) aliasHost = remoteHost.Substring(remoteHost.IndexOf(www) + www.Length);
                else aliasHost = www + remoteHost;

                var pos1 = lBlacklist.FindIndex(s => s.Equals(remoteHost));
                var pos2 = lBlacklist.FindIndex(s => s.Equals(aliasHost));
                
                // Check if request is blocked
                if (pos1 != -1 || pos2 != -1)
                {
                    // Send 403 Forbidden header to client
                    String response = "HTTP/1.1 403 Forbidden\r\n\r\n";
                    response += "<h1>403 Forbidden</h1><p>You don't have permission to access " + requestFile + " on this server.</p><hr/><i>Proxy Server Project - University of Science</i>";
                    var byteArr = System.Text.Encoding.Default.GetBytes(response);
                    this.client.Send(byteArr);
                }
                else
                {
                    requestPayload = "";
                    foreach (string line in requestLines)
                    {
                        requestPayload += line;
                        requestPayload += EOL;
                    }

                    Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    server.Connect(remoteHost, 80);

                    server.Send(ASCIIEncoding.ASCII.GetBytes(requestPayload));

                    while (server.Receive(responseBuffer) != 0)
                    {
                        this.client.Send(responseBuffer);
                    }
                    server.Disconnect(false);
                    server.Dispose();
                }

                this.client.Disconnect(false);
                this.client.Dispose();
            }
            catch (Exception e)
            {}
        }
    }
}
