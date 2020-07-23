using HackerNews.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Collections.Generic;

namespace HackerNews.Tests
{
    [TestClass()]
    public class HackerNewsClientTests
    {
        [TestMethod()]
        public void GetTopHackerNewsTest()
        {
            string url = "https://hacker-news.firebaseio.com/";

            string pathTop = "v0/beststories.json";

            string pathDetails = "v0/item/{0}.json";

            int order = 20;

            var result = new HackerNewsClient(url, pathTop, pathDetails, order).GetTopHackerNews();

            Assert.IsInstanceOfType(result, typeof(IList<HackerNewsModel>));
            Assert.IsTrue(result.Count == order);
        }

        [TestMethod()]
        public void GetTopHackerNewsWithErrorUrlTest()
        {
            try
            {
                string url = string.Empty;

                string pathTop = "v0/beststories.json";

                string pathDetails = "v0/item/{0}.json";

                int order = 20;

                var result = new HackerNewsClient(url, pathTop, pathDetails, order).GetTopHackerNews();

                Assert.IsTrue(false);
            }
            catch (System.Exception ec)
            {
                Assert.IsInstanceOfType(ec, typeof(System.Exception));
            }
        }

        [TestMethod()]
        public void GetTopHackerNewsWithErrorPathTopTest()
        {
            try
            {
                string url = "https://hacker-news.firebaseio.com/";

                string pathTop = string.Empty;

                string pathDetails = "v0/item/{0}.json";

                int order = 20;

                var result = new HackerNewsClient(url, pathTop, pathDetails, order).GetTopHackerNews();

                Assert.IsTrue(false);
            }
            catch (System.Exception ec)
            {
                Assert.IsInstanceOfType(ec, typeof(System.Exception));
            }
        }

        [TestMethod()]
        public void GetTopHackerNewsWithErrorPathDetailsTest()
        {
            try
            {
                string url = "https://hacker-news.firebaseio.com/";

                string pathTop = "v0/beststories.json";

                string pathDetails = string.Empty;

                int order = 20;

                var result = new HackerNewsClient(url, pathTop, pathDetails, order).GetTopHackerNews();

                Assert.IsTrue(false);
            }
            catch (System.Exception ec)
            {
                Assert.IsInstanceOfType(ec, typeof(System.Exception));
            }
        }
    }
}