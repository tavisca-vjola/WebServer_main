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
        private  Request(string Type,string Url,string Host)
        {

        }
        public static Request GetRequest(string request)
        {
            if (String.IsNullOrEmpty(request))
                return null;
            string[] tokens = request.Split(' ');
            return new Request("","","");
        }
    }
}
