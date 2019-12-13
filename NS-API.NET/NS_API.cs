using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NS_API.NET
{
    class NS_API
    {
        public string API_KEY { get; set; }
        public JsonSerializerSettings JsonSettings { get; set; }

        public static readonly HttpClient client = new HttpClient();

        /// <summary>
        ///     Constructor for NS_API.
        /// </summary>
        /// <param name="API_KEY">NS API Key for api access (https://apiportal.ns.nl/).</param>
        public NS_API(string API_KEY)
        {
            this.API_KEY = API_KEY;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", API_KEY);
            JsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        }

        /// <summary>
        ///     GET request to NS API
        /// </summary>
        /// <param name="url">URL</param>
        /// <returns>Returns JSON Task.</returns>
        public async Task<string> HTTPGet(string url)
        {
            // Console.WriteLine(url);
            string json = await client.GetStringAsync(url);
            return json;
        }

        /// <summary>
        ///     GET request to NS API and add parameters
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="queryString">Parameters</param>
        /// <returns>Returns JSON Task.</returns>
        public async Task<string> HTTPGet(string url, System.Collections.Specialized.NameValueCollection queryString)
        {
            // Console.WriteLine(url + queryString);
            string json = await client.GetStringAsync(url + queryString);
            return json;
        }
    }
}
