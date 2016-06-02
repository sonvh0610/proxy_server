using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_Socket
{
    //
    // Summary:
    //     Listen for connections from browser.
    //
    class Server
    {
        private int port;
        private TcpListener listener;
        private Socket socket;

        public Server(int port)
        {
            this.port = port;
            this.listener = new TcpListener(IPAddress.Any, this.port);
            // Set timeout of listener to reduce waste time
            listener.Server.ReceiveTimeout = 1000;
            listener.Server.SendTimeout = 1000;
        }
        //
        // Summary:
        //     Start listening TcpListener server
        public void StartServer()
        {
            this.listener.Start();
        }
        //
        // Summary:
        //     Stop listening TcpListener server
        public void StopServer()
        {
            this.listener.Stop();
        }
        //
        // Summary:
        //     Listening what coming into TcpListener, return a socket object then pass into Client
        public void AcceptConnection()
        {
            socket = this.listener.AcceptSocket();
            Client client = new Client(socket);
            client.StartHandling();
        }
    }
}
