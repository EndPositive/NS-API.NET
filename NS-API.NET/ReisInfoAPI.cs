using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using NS_API.NET.Stations;
using NS_API.NET.Departures;
using NS_API.NET.Disruptions;
using Newtonsoft.Json;

namespace NS_API.NET
{
    class ReisInfoAPI
    {
        public NS_API NS_API { get; set; }
        
        public ReisInfoAPI(NS_API NS_API)
        {
            this.NS_API = NS_API;
        }
        public async Task<List<StationsAPI.Payload>> GetStations()
        {
            var json = await NS_API.HTTPGet("https://gateway.apiportal.ns.nl/reisinformatie-api/api/v2/stations");
            return JsonConvert.DeserializeObject<StationsAPI>(json, NS_API.JsonSettings).Payloads;
        }
        
        public StationsAPI.Payload GetStationByUicCode(string uicCode)
        {
            return this.GetStations().Result.Find(station => station.UicCode == uicCode);
        }
        
        public StationsAPI.Payload GetStationByStationCode(string stationCode)
        {
            return this.GetStations().Result.Find(stations => stations.Code == stationCode);
        }
        
        public List<StationsAPI.Payload> GetStationsByQuery(string query)
        {
            List<StationsAPI.Payload> stationsbyquery = new System.Collections.Generic.List<StationsAPI.Payload>();
            foreach (StationsAPI.Payload station in this.GetStations().Result)
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
        
        public async Task<List<DeparturesAPI.Departure>> GetDeparturesByUicCode(string uicCode, DateTime? time = null, int maxJourneys = 10)
        {
            time = time ?? DateTime.Now;
            string nowString = time.Value.ToString("s");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["uicCode"] = uicCode;
            queryString["dateTime"] = nowString;
            queryString["maxJourneys"] = maxJourneys.ToString();

            var json = await NS_API.HTTPGet("https://gateway.apiportal.ns.nl/reisinformatie-api/api/v2/departures?", queryString);
            List<DeparturesAPI.Departure> Stations = JsonConvert.DeserializeObject<DeparturesAPI>(json, NS_API.JsonSettings).Payloads.Departures;
            return Stations;
        }

        public async Task<List<DeparturesAPI.Departure>> GetDeparturesByStationCode(string stationCode, DateTime? time = null, int maxJourneys = 10)
        {
            time = time ?? DateTime.Now;
            string nowString = time.Value.ToString("s");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["code"] = stationCode;
            queryString["dateTime"] = nowString;
            queryString["maxJourneys"] = maxJourneys.ToString();

            var json = await NS_API.HTTPGet("https://gateway.apiportal.ns.nl/reisinformatie-api/api/v2/departures?", queryString);
            List<DeparturesAPI.Departure> Stations = JsonConvert.DeserializeObject<DeparturesAPI>(json, NS_API.JsonSettings).Payloads.Departures;
            return Stations;
        }
        public async Task<List<DisruptionsAPI.Payload>> GetDisruptions(bool actual=false)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["actual"] = actual.ToString();
            var json = await NS_API.HTTPGet("https://gateway.apiportal.ns.nl/reisinformatie-api/api/v2/disruptions?", queryString);

            return JsonConvert.DeserializeObject<DisruptionsAPI>(json, NS_API.JsonSettings).Payloads;
        }
    }
}
