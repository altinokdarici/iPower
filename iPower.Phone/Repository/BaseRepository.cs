using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace iPower.Phone.Repository
{

    public class BaseRepository
    {
        int TryCount = 0;

        protected async Task<T> Download<T>(string Uri, bool ShowMessage)
        {
            string Json = string.Empty;
            bool Retry = false;
            try
            {
                HttpClient Client = new HttpClient();
                HttpResponseMessage Response = await Client.GetAsync(Uri);
                Json = await Response.Content.ReadAsStringAsync();
                Json = Json.Replace(",\"history\":{", ",\"history\":[");
                Json = Json.Replace("}}}}", "}]}}");

                for (int i = 0; i < 10; i++)
                    Json = Json.Replace("\"" + i.ToString() + "\":", "");

                T Result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(Json);

                return Result;
            }
            catch (Exception)
            {

                if (TryCount < 2)
                {
                    TryCount++;
                    Retry = true;
                }
                else
                {
                    Retry = false;
                    if (ShowMessage)
                        System.Windows.MessageBox.Show("iPower servisleriyle bağlantı kurulamıyor, lütfen daha sonra tekrar deneyiniz.");
                }

            }

            if (Retry)
                return await Download<T>(Uri, ShowMessage);
            else
                return default(T);
        }

    }


}
