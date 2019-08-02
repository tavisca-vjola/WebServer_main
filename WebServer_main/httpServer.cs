using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebServer_main
{
    public class HttpServer
    {
        private TcpListener listener;
        bool running = false;
       public  HttpServer(int port)
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
                Console.WriteLine("");
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("");
                HandleClient(client);
                client.Close();
            }
            running = false;
            listener.Stop();

        }

        private void HandleClient(TcpClient client)
        {
            StreamReader reader = new StreamReader(client.GetStream());
            string msg = "";
            while(reader.Peek()!=-1)
            {
                msg += reader.ReadLine()+"\n";
            }
            Console.WriteLine("Request "+msg);



        }
    }
}
