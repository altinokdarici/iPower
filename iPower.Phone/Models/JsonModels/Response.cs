using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPower.Phone.Models.JsonModels
{
    public class Response
    {
        public string channel_id { get; set; }
        public string type { get; set; }
        public string type_name { get; set; }
        public string channel_name { get; set; }
        public string channel_description { get; set; }
        public string channel_seo_name { get; set; }
        public string channel_url { get; set; }
        public string channel_logo_small { get; set; }
        public string channel_logo_medium { get; set; }
        public string channel_logo_big { get; set; }
        public string channel_detail_service_url { get; set; }
        public bool channel_podcast_enabled { get; set; }
        public bool channel_charts_enabled { get; set; }
        public string channel_stream_url { get; set; }
        public List<Timeline> timeline { get; set; }
        public List<History> history { get; set; }
    }

}
