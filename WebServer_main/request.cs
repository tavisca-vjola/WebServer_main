using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer_main
{
    class Request
    {
        public string Type { get; set; }
        public string Url { get; set; }

        public string Host { get; set; }
        private  Request(string type,string url,string host)
        {
            this.Type = type;
            this.Url = url;
            this.Host = host;
        }
        public static Request GetRequest(string request)
        {
            if (String.IsNullOrEmpty(request))
                return null;
            string[] tokens = request.Split(' ');
            string type = tokens[0];
            string url = tokens[1];
            string host = tokens[4];
            return new Request(type,url,host);

        }
    }
}
