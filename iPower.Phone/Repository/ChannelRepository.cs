using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iPower.Phone.Helpers;
namespace iPower.Phone.Repository
{
    public class ChannelRepository : BaseRepository
    {
        public async Task<Models.Response> Get(string ChannelName)
        {
            string Uri = string.Format("http://api.powergroup.com.tr/Channels/{0}?appRef=iPowerWeb&i={1}", ChannelName, DateTime.Now.Ticks.ToString());

            Models.JsonModels.RootObject rootObject = await base.Download<Models.JsonModels.RootObject>(Uri, true);

            return rootObject.ToResponse();
        }
    }
}
