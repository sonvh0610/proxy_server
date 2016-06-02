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
            // This will contain string from client send to, or server send back
            // RequestBuffer use 10000 characters because we can read all client bytes from stream
            byte[] RequestBuffer = new byte[10000];
            byte[] ResponseBuffer = new byte[1];

            try
            {
                // When a browser send request to Proxy Server
                // Proxy Server receive it, then parse from byte array to string
                // But we also cut out some '\0' characters at the end of RequestString to correct it
                this.client.Receive(RequestBuffer);
                string RequestString = System.Text.Encoding.Default.GetString(RequestBuffer);
                RequestString = RequestString.Substring(0, RequestString.IndexOf('\0'));

                // Parse string to get URL, host and path
                // HTTP packets always contain url string at the beginning of packet
                // So we want to get the first line, and split by a space to get url
                string FirstRequestLine = RequestString.Substring(0, RequestString.IndexOf("\r\n"));
                string strUrl = FirstRequestLine.Split(' ')[1];
                Uri uri = new Uri(strUrl);
                string RemoteHost = uri.Host;
                string requestFile = uri.PathAndQuery;

                // We have a blacklist, which blocked websites to access
                // This will check if URL has prefix www. or not
                // For example: hcmus.edu.vn => www.hcmus.edu.vn (handle this)
                string AliasHost = null;
                string www = "www.";
                if (RemoteHost.IndexOf("www.") != -1) AliasHost = RemoteHost.Substring(RemoteHost.IndexOf(www) + www.Length);
                else AliasHost = www + RemoteHost;

                // This is lambda expression of finding an item from array
                // Full syntax of them is
                // lBlacklist.FindIndex( (string s) => { s.Equals(host) } ); <= We've shortened this line
                int pos1 = lBlacklist.FindIndex(s => s.Equals(RemoteHost));
                int pos2 = lBlacklist.FindIndex(s => s.Equals(AliasHost));
                
                // Check if request is blocked
                if (pos1 != -1 || pos2 != -1)
                {
                    // Send 403 Forbidden header to client
                    String response = "HTTP/1.1 403 Forbidden\r\n\r\n";
                    response += "<h1>403 Forbidden</h1><p>You don't have permission to access " 
                                + requestFile 
                                + " on this server.</p><hr/><i>Proxy Server Project - University of Science</i>";
                    this.client.Send(ASCIIEncoding.ASCII.GetBytes(response));
                }
                else
                {
                    // Create a connection from this proxy to browser
                    // AddressFamily.InterNetwork: socket is using IPv4
                    // SocketType.Stream: use stream to send data to client
                    // ProtocolType.Tcp: work with TCP Protocol
                    using (Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                    {
                        server.Connect(RemoteHost, 80);
                        server.Send(ASCIIEncoding.ASCII.GetBytes(RequestString));

                        while (server.Receive(ResponseBuffer) != 0)
                        {
                            this.client.Send(ResponseBuffer);
                        }
                    }
                }

                this.client.Disconnect(false);
                this.client.Dispose();
            }
            catch (Exception e)
            {}
        }
    }
}
