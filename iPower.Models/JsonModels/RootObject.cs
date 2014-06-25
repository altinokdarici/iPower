using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPower.Models.JsonModels
{

   

   


    public class RootObject
    {
        public string version { get; set; }
        public string version_code { get; set; }
        public string client { get; set; }
        public string request_date { get; set; }
        public string request_ip { get; set; }
        public int errorCode { get; set; }
        public string errorMessage { get; set; }
        public string outputMode { get; set; }
        public Response response { get; set; }
    }
}
