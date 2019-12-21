using System.Collections.Generic;
using Newtonsoft.Json;

namespace NS_API.NET.Departures
{
    public partial class DeparturesApi
    {
        [JsonProperty("payload")]
        public Payload Payloads { get; set; }

        public partial class Payload
        {
            [JsonProperty("source")]
            public string Source { get; set; }

            [JsonProperty("departures")]
            public List<Departure> Departures { get; set; }
        }

        public partial class Departure
        {
            [JsonProperty("direction")]
            public string Direction { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("plannedDateTime")]
            public string PlannedDateTime { get; set; }

            [JsonProperty("plannedTimeZoneOffset")]
            public long PlannedTimeZoneOffset { get; set; }

            [JsonProperty("actualDateTime")]
            public string ActualDateTime { get; set; }

            [JsonProperty("actualTimeZoneOffset")]
            public long ActualTimeZoneOffset { get; set; }

            [JsonProperty("plannedTrack")]
            public string PlannedTrack { get; set; }

            [JsonProperty("product")]
            public Product Product { get; set; }

            [JsonProperty("trainCategory")]
            public string TrainCategory { get; set; }

            [JsonProperty("cancelled")]
            public bool Cancelled { get; set; }

            [JsonProperty("routeStations")]
            public List<RouteStation> RouteStations { get; set; }

            [JsonProperty("departureStatus")]
            public string DepartureStatus { get; set; }
        }

        public partial class Product
        {
            [JsonProperty("number")]
            public string Number { get; set; }

            [JsonProperty("categoryCode")]
            public string CategoryCode { get; set; }

            [JsonProperty("shortCategoryName")]
            public string ShortCategoryName { get; set; }

            [JsonProperty("longCategoryName")]
            public string LongCategoryName { get; set; }

            [JsonProperty("operatorCode")]
            public string OperatorCode { get; set; }

            [JsonProperty("operatorName")]
            public string OperatorName { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }
        }

        public partial class RouteStation
        {
            [JsonProperty("uicCode")]
            public string UicCode { get; set; }

            [JsonProperty("mediumName")]
            public string MediumName { get; set; }
        }
    }
}
