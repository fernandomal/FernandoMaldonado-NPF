using HackerNews.Interface;
using Microsoft.Extensions.Configuration;
using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace HackerNews
{
    public class HackerNewsClient : HttpClientSample.HttpClientSample, IHackerNewsClient
    {
        private int Order { get; set; }
        private string PathTop { get; set; }
        private string PathDetails { get; set; }

        public HackerNewsClient(string url, string pathTop, string pathDetails, int order) : base(url)
        {
            PathTop = pathTop;
            PathDetails = pathDetails;
            Order = order;
        }

        public IList<HackerNewsModel> GetTopHackerNews()
        {
            IList<HackerNewsModel> lstHackerNews = new List<HackerNewsModel>();

            int[] lstTop = GetTopIds();
            foreach (int item in lstTop ?? Enumerable.Empty<int>())
            {
                lstHackerNews.Add(GetDescription(item));
            }

            return lstHackerNews.OrderByDescending(m => m.Score).ToList();
        }

        /// <summary>
        /// Method to List ID´s of the "best stories" from the Hacker News API.  
        /// </summary>
        /// <param name="order">Quantity of stories to sort</param>
        /// <returns>List of Stories</returns>
        private int[] GetTopIds()
        {
            var data = Get(PathTop);

            return JsonConvert.DeserializeObject<int[]>(data.ToString()).Take(Order).ToArray();
        }

        /// <summary>
        /// Method get complete information of "story" from the Hacker News API.  
        /// </summary>
        /// <param name="hackerNewsId">Story New Id to fill.</param>
        /// <returns>Complete Story model to fill.</returns>
        private HackerNewsModel GetDescription(int hackerNewsId)
        {
            var data = Get(string.Format(PathDetails, hackerNewsId));

            return JsonConvert.DeserializeObject<HackerNewsModel>(data.ToString());
        }
    }
}
