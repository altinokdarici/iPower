using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPower.Phone.ViewModel
{
    public class SongViewModel : ViewModel
    {
        private Models.Item _Song;

        public Models.Item Song
        {
            get
            {
                if (string.IsNullOrEmpty(this._Song.SongLyrics))
                    this._Song.SongLyrics = "Bu şarkının sözlerine erişemiyorum :(";
                return _Song;
            }
            set
            {
                base.Set<Models.Item>(ref this._Song, value);
            }
        }

        public SongViewModel()
        {
            if (!base.IsInDesignMode)
                this.Song = StaticData.Selected.SelectedSong;
        }
    }
}
