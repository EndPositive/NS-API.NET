using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using NS_API.NET.Stations;
using NS_API.NET.Departures;
using NS_API.NET.Disruptions;

namespace NS_API.NET
{
    internal class NsApi
    {
        private JsonSerializerSettings JsonSettings { get; set; }

        private static readonly HttpClient Client = new HttpClient();

        public NsApi(string apiKey)
        {
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
            JsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        }

        private async Task<string> HttpGet(string url)
        {
            string json = await Client.GetStringAsync(url);
            return json;
        }

        private async Task<string> HttpGet(string url, System.Collections.Specialized.NameValueCollection queryString)
        {
            string json = await Client.GetStringAsync(url + queryString);
            return json;
        }
        
        public async Task<List<StationsApi.Payload>> GetStations()
        {
            var json = await this.HttpGet("https://gateway.apiportal.ns.nl/reisinformatie-api/api/v2/stations");
            return JsonConvert.DeserializeObject<StationsApi>(json, this.JsonSettings).Payloads;
        }
        
        public StationsApi.Payload GetStationByUicCode(string uicCode)
        {
            return this.GetStations().Result.Find(station => station.UicCode == uicCode);
        }
        
        public StationsApi.Payload GetStationByStationCode(string stationCode)
        {
            return this.GetStations().Result.Find(stations => stations.Code == stationCode);
        }
        
        public List<StationsApi.Payload> GetStationsByQuery(string query)
        {
            List<StationsApi.Payload> stationsbyquery = new System.Collections.Generic.List<StationsApi.Payload>();
            foreach (StationsApi.Payload station in this.GetStations().Result)
            {
                if (station.Code.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    station.Namen.Lang.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    station.Namen.Middel.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    station.Namen.Kort.Contains(query, StringComparison.OrdinalIgnoreCase))
                {
                    stationsbyquery.Add(station);
                }
            }
            return stationsbyquery;
        }
        
        public async Task<List<DeparturesApi.Departure>> GetDeparturesByUicCode(string uicCode, DateTime? time = null, int maxJourneys = 10)
        {
            time = time ?? DateTime.Now;
            string nowString = time.Value.ToString("s");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["uicCode"] = uicCode;
            queryString["dateTime"] = nowString;
            queryString["maxJourneys"] = maxJourneys.ToString();

            var json = await this.HttpGet("https://gateway.apiportal.ns.nl/reisinformatie-api/api/v2/departures?", queryString);
            List<DeparturesApi.Departure> stations = JsonConvert.DeserializeObject<DeparturesApi>(json, this.JsonSettings).Payloads.Departures;
            return stations;
        }

        public async Task<List<DeparturesApi.Departure>> GetDeparturesByStationCode(string stationCode, DateTime? time = null, int maxJourneys = 10)
        {
            time = time ?? DateTime.Now;
            string nowString = time.Value.ToString("s");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["code"] = stationCode;
            queryString["dateTime"] = nowString;
            queryString["maxJourneys"] = maxJourneys.ToString();

            var json = await this.HttpGet("https://gateway.apiportal.ns.nl/reisinformatie-api/api/v2/departures?", queryString);
            List<DeparturesApi.Departure> stations = JsonConvert.DeserializeObject<DeparturesApi>(json, this.JsonSettings).Payloads.Departures;
            return stations;
        }
        public async Task<List<DisruptionsApi.Payload>> GetDisruptions(bool actual=false)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["actual"] = actual.ToString();
            var json = await this.HttpGet("https://gateway.apiportal.ns.nl/reisinformatie-api/api/v2/disruptionsl?", queryString);

            return JsonConvert.DeserializeObject<DisruptionsApi>(json, this.JsonSettings).Payloads;
        }
    }
}
