using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPower.Phone.Models.JsonModels
{
    public class Timeline
    {
        public bool hide_counter { get; set; }
        public string artistTitle { get; set; }
        public string songTitle { get; set; }
        public string songID { get; set; }
        public string songType { get; set; }
        public string songLyrics { get; set; }
        public string songStatus { get; set; }
        public int elapsedTime { get; set; }
        public int remainingSeconds { get; set; }
        public int duration { get; set; }
        public string durationText { get; set; }
        public string albumCoverIMG { get; set; }
    }
}
