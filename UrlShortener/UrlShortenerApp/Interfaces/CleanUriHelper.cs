using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace UrlShortenerApp
{
    public class CleanUriHelper : IUriHelper
    {
       
        Uri apiURI = new Uri("https://cleanuri.com/api/v1/shorten");

        public string GetShortURI(string url)
        {
            
            var requestContent = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("url", url), });

            var t = Task.Run(() => callAPI(apiURI, requestContent));
            t.Wait();
            dynamic ret = JsonConvert.DeserializeObject(t.Result);

            return ret.result_url;

        }

        async Task<string> callAPI(Uri uri, HttpContent content)
        {
            string returnMessage = "";
            try
            {
                using (var client = new HttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        RequestUri = uri,
                        Content = content
                    };

                    HttpResponseMessage result = await client.SendAsync(request);
                    if (result.IsSuccessStatusCode)
                    {
                        returnMessage = await result.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (HttpRequestException e)
            {
                returnMessage = e.Message;
            }
            return returnMessage;
        }


    }
}
