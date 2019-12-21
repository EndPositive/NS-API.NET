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
using NS_API.NET.Disruptions;
using NS_API.NET.Trips;

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
        public StationsApi.Payload GetStation(int uicCode)
        {
            return this.GetStations().Result.Find(station => station.UicCode == uicCode.ToString());
        }
        public StationsApi.Payload GetStation(string stationCode)
        {
            return this.GetStations().Result.Find(stations => stations.Code == stationCode);
        }
        public async Task<List<DeparturesApi.Departure>> GetDepartures(int uicCode, DateTime? time = null,
            int maxJourneys = 10)
        {
            time = time ?? DateTime.Now;
            string nowString = time.Value.ToString("s");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["dateTime"] = nowString;
            queryString["maxJourneys"] = maxJourneys.ToString();
            queryString["uicCode"] = uicCode.ToString();

            var json = await this.HttpGet("https://gateway.apiportal.ns.nl/reisinformatie-api/api/v2/departures?", queryString);
            List<DeparturesApi.Departure> departures = JsonConvert.DeserializeObject<DeparturesApi>(json, this.JsonSettings).Payloads.Departures;
            return departures;
        }
        public async Task<List<DeparturesApi.Departure>> GetDepartures(string stationCode, DateTime? time = null,
            int maxJourneys = 10)
        {
            time = time ?? DateTime.Now;
            string nowString = time.Value.ToString("s");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["dateTime"] = nowString;
            queryString["maxJourneys"] = maxJourneys.ToString();
            queryString["station"] = stationCode;
            
            var json = await this.HttpGet("https://gateway.apiportal.ns.nl/reisinformatie-api/api/v2/departures?", queryString);
            List<DeparturesApi.Departure> departures = JsonConvert.DeserializeObject<DeparturesApi>(json, this.JsonSettings).Payloads.Departures;
            return departures;
        }
        public async Task<List<ArrivalsApi.Arrival>> GetArrivals(int uicCode, DateTime? time = null,
            int maxJourneys = 10)
        {
            time = time ?? DateTime.Now;
            string nowString = time.Value.ToString("s");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["dateTime"] = nowString;
            queryString["maxJourneys"] = maxJourneys.ToString();
            queryString["uicCode"] = uicCode.ToString();
            
            var json = await this.HttpGet("https://gateway.apiportal.ns.nl/reisinformatie-api/api/v2/arrivals?", queryString);
            List<ArrivalsApi.Arrival> arrivals = JsonConvert.DeserializeObject<ArrivalsApi>(json, this.JsonSettings).Payloads.Arrivals;
            return arrivals;
        }
        public async Task<List<ArrivalsApi.Arrival>> GetArrivals(string stationCode, DateTime? time = null,
            int maxJourneys = 10)
        {
            time = time ?? DateTime.Now;
            string nowString = time.Value.ToString("s");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["dateTime"] = nowString;
            queryString["maxJourneys"] = maxJourneys.ToString();
            queryString["station"] = stationCode;
            
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
        public async Task<DisruptionsApi.Payload> GetDisruption(string stationCode)
        {
            var json = await this.HttpGet("https://gateway.apiportal.ns.nl/reisinformatie-api/api/v2/disruptions/"+stationCode);
            return JsonConvert.DeserializeObject<DisruptionsApi.Payload>(json, this.JsonSettings);
        }
        public async Task<DisruptionsApi.Payload> GetDisruption(int uicCode)
        {
            var json = await this.HttpGet("https://gateway.apiportal.ns.nl/reisinformatie-api/api/v2/disruptions/"+uicCode);
            return JsonConvert.DeserializeObject<DisruptionsApi.Payload>(json, this.JsonSettings);
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
        public async Task<List<TripsApi.Trip>> GetTrips(string fromStation, string toStation, string viaStation = null,
            string travelClass = "SECOND_CLASS", bool originTransit = false, bool originWalk = false,
            bool originBike = false, bool originCar = false, bool destinationTransit = false,
            bool destinationWalk = false, bool destinationBike = false, bool destinationCar = false,
            int travelAssistanceTransferTime = 0, bool searchForAccessibleTrip = false,
            bool excludeHighSpeedTrains = false, bool excludeReservationRequired = false)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["fromStation"] = fromStation;
            queryString["toStation"] = toStation;
            if (viaStation != null)
            {
                queryString["viaStation"] = viaStation;
            }
            queryString["travelClass"] = travelClass;
            queryString["originTransit"] = originTransit.ToString();
            queryString["originBike"] = originBike.ToString();
            queryString["originCar"] = originCar.ToString();
            queryString["originWalk"] = originWalk.ToString();
            queryString["destinationTransit"] = destinationTransit.ToString();
            queryString["destinationWalk"] = destinationWalk.ToString();
            queryString["destinationBike"] = destinationBike.ToString();
            queryString["destinationCar"] = destinationCar.ToString();
            queryString["travelAssistanceTransferTime"] = travelAssistanceTransferTime.ToString();
            queryString["searchForAccessibleTrip"] = searchForAccessibleTrip.ToString();
            queryString["excludeHighSpeedTrains"] = excludeHighSpeedTrains.ToString();
            queryString["excludeReservationRequired"] = excludeReservationRequired.ToString();

            var json = await this.HttpGet("https://gateway.apiportal.ns.nl/reisinformatie-api/api/v3/trips?", queryString);

            return JsonConvert.DeserializeObject<TripsApi>(json, this.JsonSettings).Trips;
        }
        
        public async Task<List<TripsApi.Trip>> GetTrips(int originUicCode, int destinationUicCode, int viaUicCode = default,
            string travelClass = "SECOND_CLASS", bool originTransit = false, bool originWalk = false,
            bool originBike = false, bool originCar = false, bool destinationTransit = false,
            bool destinationWalk = false, bool destinationBike = false, bool destinationCar = false,
            int travelAssistanceTransferTime = 0, bool searchForAccessibleTrip = false,
            bool excludeHighSpeedTrains = false, bool excludeReservationRequired = false)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["originUicCode"] = originUicCode.ToString();
            queryString["destinationUicCode"] = destinationUicCode.ToString();
            if (viaUicCode != default)
            {
                queryString["viaUicCode"] = viaUicCode.ToString();
            }
            queryString["travelClass"] = travelClass;
            queryString["originTransit"] = originTransit.ToString();
            queryString["originBike"] = originBike.ToString();
            queryString["originCar"] = originCar.ToString();
            queryString["originWalk"] = originWalk.ToString();
            queryString["destinationTransit"] = destinationTransit.ToString();
            queryString["destinationWalk"] = destinationWalk.ToString();
            queryString["destinationBike"] = destinationBike.ToString();
            queryString["destinationCar"] = destinationCar.ToString();
            queryString["travelAssistanceTransferTime"] = travelAssistanceTransferTime.ToString();
            queryString["searchForAccessibleTrip"] = searchForAccessibleTrip.ToString();
            queryString["excludeHighSpeedTrains"] = excludeHighSpeedTrains.ToString();
            queryString["excludeReservationRequired"] = excludeReservationRequired.ToString();

            var json = await this.HttpGet("https://gateway.apiportal.ns.nl/reisinformatie-api/api/v3/trips?", queryString);

            return JsonConvert.DeserializeObject<TripsApi>(json, this.JsonSettings).Trips;
        }

        public async Task<TripsApi.Trip> GetTrip(string reconCtx)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["ctxRecon"] = reconCtx;
            var json = await this.HttpGet("https://gateway.apiportal.ns.nl/reisinformatie-api/api/v3/trips/trip?", queryString);
            return JsonConvert.DeserializeObject<TripsApi.Trip>(json, this.JsonSettings);
        }
    }    
}
