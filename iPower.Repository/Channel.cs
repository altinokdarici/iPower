using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace iPower.Repository
{

    public class Channel
    {
        public async Task<Models.Response> GetItems(string ChannelName)
        {

            //TODO: refactoring !!!!!!!!!
            HttpClient Client = new HttpClient();
            var Response = await Client.GetAsync("http://api.powergroup.com.tr/Channels/" + ChannelName + "?appRef=iPowerWeb&i=" + DateTime.Now.Ticks.ToString());
            var Json = await Response.Content.ReadAsStringAsync();
            dynamic obj = Newtonsoft.Json.JsonConvert.DeserializeObject(Json);

            Models.Response ResponseObject = new Models.Response();
            ResponseObject.Description = obj.response.channel_description;
            var okk = obj.response.history.ToString();
            try
            {
                IList<Models.JsonModels.History> ok = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<Models.JsonModels.History>>(obj.response.history.ToString());
                ResponseObject.History = new System.Collections.ObjectModel.ObservableCollection<Models.Item>(ok.Select(x => new Models.Item()
                    {
                        ArtistTitle = x.artistTitle,
                        CoverImageUrl = x.albumCoverIMG,
                        SongId = int.Parse(x.songID),
                        SongLyrics = x.songLyrics,
                        SongPlayedAtVisible = x.songPlayedAtVisible,
                        SongTitle = x.songTitle
                    }));
            }
            catch (Exception) { }
            var tl = obj.response.timeline;
            IList<Models.JsonModels.Timeline> TimeLine = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<Models.JsonModels.Timeline>>(tl.ToString());
            ResponseObject.TimeLine = new System.Collections.ObjectModel.ObservableCollection<Models.Item>(TimeLine.Select(x => new Models.Item()
                {
                    ArtistTitle = x.artistTitle,
                    CoverImageUrl = x.albumCoverIMG,
                    Duration = x.duration,
                    ElapsedTime = x.elapsedTime,
                    RemainingSeconds = x.remainingSeconds,
                    SongId = int.Parse(x.songID),
                    SongLyrics = x.songLyrics,
                    SongStatus = x.songStatus,
                    SongTitle = x.songTitle
                }));
            return ResponseObject;
        }

    }
}
