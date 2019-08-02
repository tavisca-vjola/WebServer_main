using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebServer_main
{
    class httpServer
    {
        private TcpListener listener;
        bool running = false;
        httpServer(int port)
        {
            listener = new TcpListener(IPAddress.Any, port);
        }
        public void start()
        {
            Thread server = new Thread(new ThreadStart(Run));
            server.Start();
        }

       public void Run()
        {
            running = true;
            listener.Start();
            while(running)
            {
                TcpClient client = listener.AcceptTcpClient();
                HandleClient(client);
                client.Close();



            }
            running = false;
            listener.Stop();

        }

        private void HandleClient(TcpClient client)
        {
            throw new NotImplementedException();
        }
    }
}
