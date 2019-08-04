using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebServer_main
{
    class Response
    {
        private byte[] Data = null;
        private string Status;
        private string Mime;
        private Response(string status,string mime ,byte[] data)
        {
            this.Data = data;
            this.Status = status;
            this.Mime = mime;
        }
        public static Response From(Request request)
        {
            if (request == null)
                return MakeNullRequest(request);
            return null;
        }

        private static Response MakeNullRequest(Request request)
        {
            string file = Environment.CurrentDirectory +HttpServer.MSG_dir+"400.html";
            FileInfo file_name = new FileInfo(file);
            FileStream fs = file_name.OpenRead();

            BinaryReader reader = new BinaryReader(fs);
            byte[] data = new byte[fs.Length];
            reader.Read(data, 0, data.Length);
            return new Response("400 Bad Request","html/text",data);
        }

        public void Post(NetworkStream stream)
        {
            StreamWriter sw = new StreamWriter(stream);
            sw.WriteLine(string.Format("{0} {1}\r\nServer: {2}\r\nContentType {3}\r\nAccept-Rangers:bytes\r\nContentLength:{4}\r\n"),HttpServer.VERSION,Status,HttpServer.name,Mime,Data.Length); 
           
            stream.Write(Data,0,Data.Length);
        }
    }
}
