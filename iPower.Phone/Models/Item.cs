using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPower.Phone.Models
{
    public class Item
    {
        public string ArtistTitle { get; set; }
        public string SongTitle { get; set; }
        public int SongId { get; set; }

        public string SongLyrics { get; set; }
        public string SongStatus { get; set; }
        public int ElapsedTime { get; set; }
        public int RemainingSeconds { get; set; }
        public int Duration { get; set; }
        public string CoverImageUrl { get; set; }
        public string SongPlayedAtVisible { get; set; }

        public bool HasLyrics
        {
            get
            {
                return !string.IsNullOrEmpty(SongLyrics);
            }
        }

    }
}
