using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPower.Phone.Helpers
{
    public static class Extensions
    {
        public static Models.Item ToItem(this Models.JsonModels.History history)
        {
            Models.Item newItem = new Models.Item();
            newItem.ArtistTitle = history.artistTitle;
            newItem.CoverImageUrl = history.albumCoverIMG;
            newItem.SongId = int.Parse(history.songID);
            newItem.SongLyrics = history.songLyrics;
            newItem.SongPlayedAtVisible = history.songPlayedAtVisible;
            newItem.SongTitle = history.songTitle;

            return newItem;

        }
        public static Models.Item ToItem(this Models.JsonModels.Timeline timeline)
        {
            Models.Item newItem = new Models.Item();
            newItem.ArtistTitle = timeline.artistTitle;
            newItem.CoverImageUrl = timeline.albumCoverIMG;
            newItem.Duration = timeline.duration;
            newItem.ElapsedTime = timeline.elapsedTime;
            newItem.RemainingSeconds = timeline.remainingSeconds;
            newItem.SongId = int.Parse(timeline.songID);
            newItem.SongLyrics = timeline.songLyrics;
            newItem.SongTitle = timeline.songTitle;

            return newItem;

        }
        public static Models.Response ToResponse(this Models.JsonModels.RootObject root)
        {
            if (root == null)
                return null;
            Models.Response response = new Models.Response();
            
            response.Description = root.response.channel_description;
            response.History = new System.Collections.ObjectModel.ObservableCollection<Models.Item>(root.response.history.Select(x => x.ToItem()));
            response.TimeLine = new System.Collections.ObjectModel.ObservableCollection<Models.Item>(root.response.timeline.Select(x => x.ToItem()));

            StaticData.Selected.SelectedChannel.StreamUrl = root.response.channel_stream_url;
            return response;
        }
    }
}
