using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPower.Models.JsonModels
{
    public class History
    {
        public string artistTitle { get; set; }
        public string songTitle { get; set; }
        public string songID { get; set; }
        public string songType { get; set; }
        public string songLyrics { get; set; }
        public int songPlayedAt { get; set; }
        public string songPlayedAtVisible { get; set; }
        public string albumCoverIMG { get; set; }
    }
}
