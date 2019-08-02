using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer_main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Connection Started");
            HttpServer server = new HttpServer(2808);
            server.start();
        }
    }
}
