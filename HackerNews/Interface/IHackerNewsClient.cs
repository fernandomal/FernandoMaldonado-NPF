using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HackerNews.Interface
{
    public interface IHackerNewsClient
    {
        /// <summary>
        /// Method to List the "best stories" from the Hacker News API. 
        /// </summary>
        /// <param name="order">Quantity of stories to sort</param>
        /// <returns>List of Stories</returns>
        IList<HackerNewsModel> GetTopHackerNews();
    }
}
