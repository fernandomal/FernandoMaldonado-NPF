using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HttpClientSample
{
    public abstract class HttpClientSample
    {
        static HttpClient client = new HttpClient();

        /// <summary>
        /// Constructor HttpClientSample Class.
        /// </summary>
        /// <param name="url">URl invoke on HttpClient.</param>
        public HttpClientSample(string url)
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Method async HTTP GET request using HttpClient
        /// </summary>
        /// <param name="path">Path</param>
        /// <returns>Task<string></returns>
        public static async Task<string> GetAsync(string path)
        {
            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return null;
        }

        /// <summary>
        /// Method HTTP GET request using HttpClient
        /// </summary>
        /// <param name="path">Path</param>
        /// <returns>Task<string></returns>
        public static string Get(string path)
        {
            string responseString = string.Empty;

            HttpResponseMessage response = client.GetAsync(path).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;

                responseString = responseContent.ReadAsStringAsync().Result;
            }

            return responseString;
        }
    }
}
