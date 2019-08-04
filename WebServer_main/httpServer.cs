using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public const string MSG_dir = "/root/msg";
        public const string WEB_dir = "/root/web";
      
        public const string VERSION = "HTTP/1.1";
        public const string name = "Matthiware Http Server v0.1";
        public TcpListener listener;
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
            Debug.WriteLine("Request "+msg);

            Request req = Request.GetRequest(msg);
            Response response = Response.From(req);
            response.Post(client.GetStream());

        }
    }
}
