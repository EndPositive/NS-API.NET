using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using NS_API.NET.Arrivals;
using NS_API.NET.Calamities;
using NS_API.NET.Stations;
using NS_API.NET.Departures;
using NS_API.NET.Disruption;
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
        public async Task<List<StationsApi.Payload>> GetStations(string query = null)
        {
            if (query != null)
            {
                List<StationsApi.Payload> stations = new System.Collections.Generic.List<StationsApi.Payload>();
                foreach (StationsApi.Payload station in this.GetStations().Result)
                {
                    if (station.Code.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                        station.Namen.Lang.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                        station.Namen.Middel.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                        station.Namen.Kort.Contains(query, StringComparison.OrdinalIgnoreCase))
                    {
                        stations.Add(station);
                    }
                }
                return stations;
            }
            else
            {
                var json = await this.HttpGet("https://gateway.apiportal.ns.nl/reisinformatie-api/api/v2/stations");
                return JsonConvert.DeserializeObject<StationsApi>(json, this.JsonSettings).Payloads;
            }
        }
        public StationsApi.Payload GetStation(string uicCode = null, string stationCode = null, string query = null)
        {
            if (uicCode != null && stationCode != null ||
                uicCode != null && query != null ||
                stationCode != null && query != null)
            {
                throw new System.ArgumentException();
            }
            if (uicCode != null)
            {
                return this.GetStations().Result.Find(station => station.UicCode == uicCode);
            }

            if (stationCode != null)
            {
                return this.GetStations().Result.Find(stations => stations.Code == stationCode);
            }

            throw new System.ArgumentException();
        }
        public async Task<List<DeparturesApi.Departure>> GetDepartures(string uicCode = null, string stationCode = null, DateTime? time = null, int maxJourneys = 10)
        {
            if (uicCode != null && stationCode != null ||
                uicCode == null && stationCode == null)
            {
                throw new System.ArgumentException();
            }
            
            time = time ?? DateTime.Now;
            string nowString = time.Value.ToString("s");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["dateTime"] = nowString;
            queryString["maxJourneys"] = maxJourneys.ToString();

            if (uicCode != null)
            {
                queryString["uicCode"] = uicCode;
            }

            if (stationCode != null)
            {
                queryString["station"] = stationCode;
            }
            
            var json = await this.HttpGet("https://gateway.apiportal.ns.nl/reisinformatie-api/api/v2/departures?", queryString);
            List<DeparturesApi.Departure> departures = JsonConvert.DeserializeObject<DeparturesApi>(json, this.JsonSettings).Payloads.Departures;
            return departures;
        }
        public async Task<List<ArrivalsApi.Arrival>> GetArrivals(string uicCode = null, string stationCode = null, DateTime? time = null, int maxJourneys = 10)
        {
            if (uicCode != null && stationCode != null ||
                uicCode == null && stationCode == null)
            {
                throw new System.ArgumentException();
            }
            
            time = time ?? DateTime.Now;
            string nowString = time.Value.ToString("s");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["dateTime"] = nowString;
            queryString["maxJourneys"] = maxJourneys.ToString();

            if (uicCode != null)
            {
                queryString["uicCode"] = uicCode;
            }

            if (stationCode != null)
            {
                queryString["station"] = stationCode;
            }
            
            var json = await this.HttpGet("https://gateway.apiportal.ns.nl/reisinformatie-api/api/v2/arrivals?", queryString);
            List<ArrivalsApi.Arrival> arrivals = JsonConvert.DeserializeObject<ArrivalsApi>(json, this.JsonSettings).Payloads.Arrivals;
            return arrivals;
        }
        public async Task<List<DisruptionsApi.Payload>> GetDisruptions(bool actual=false)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["actual"] = actual.ToString();
            var json = await this.HttpGet("https://gateway.apiportal.ns.nl/reisinformatie-api/api/v2/disruptions?", queryString);

            return JsonConvert.DeserializeObject<DisruptionsApi>(json, this.JsonSettings).Payloads;
        }
        public async Task<DisruptionApi.Payload> GetDisruption(string id)
        {
            var json = await this.HttpGet("https://gateway.apiportal.ns.nl/reisinformatie-api/api/v2/disruptions/"+id);
            return JsonConvert.DeserializeObject<DisruptionApi>(json, this.JsonSettings).Payloads;
        }
        public async Task<List<DisruptionsApi.Payload>> GetStationDisruptions(string code)
        {
            var json = await this.HttpGet("https://gateway.apiportal.ns.nl/reisinformatie-api/api/v2/disruptions/station/"+code);
            return JsonConvert.DeserializeObject<DisruptionsApi>(json, this.JsonSettings).Payloads;
        }

        public async Task<List<CalamitiesApi.Melding>> GetCalamities()
        {
            var json = await this.HttpGet("https://gateway.apiportal.ns.nl/reisinformatie-api/api/v1/calamities");
            List<CalamitiesApi.Melding> meldingen = JsonConvert.DeserializeObject<CalamitiesApi>(json, this.JsonSettings).Meldingen;
            return meldingen;
        }
    }
}
