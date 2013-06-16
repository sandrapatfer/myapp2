using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TraktClient
{
    public class Class1
    {
        public Class1()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://api.trakt.tv/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // get shows
            var getShowsTask = client.GetAsync("shows/trending.json/7693e7a7e0739298af1a56dbb88540ca");
            getShowsTask.ContinueWith(t1 =>
                {
                    var r = t1.Result;
                    if (r.IsSuccessStatusCode)
                    {
                        r.Content.ReadAsAsync<List<Show>>().ContinueWith(t2=>
                            {
                                var r2 = t2.Result;
                                
                            });
                    }
                });
        }

        private class Show
        {
            public string Title { get; set; }
        }
    }
}
