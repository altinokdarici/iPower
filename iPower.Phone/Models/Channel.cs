using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPower.Phone.Models
{
    public class Channel
    {
        public string Name { get; set; }
        public string ChannelName { get; set; }
        public string StreamUrl { get; set; }
        public string ImageUrl
        {
            get
            {
                return string.Format("http://asset.ipower.com.tr/channels/medium/{0}.png", ChannelName);
            }
        }
    }
}
