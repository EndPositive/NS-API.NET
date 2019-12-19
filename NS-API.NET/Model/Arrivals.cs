using System.Collections.Generic;
using Newtonsoft.Json;

namespace NS_API.NET.Arrivals
{
    public partial class ArrivalsApi
    {
        [JsonProperty("payload")]
        public Payload Payloads { get; set; }
        
        public partial class Payload
        {
            [JsonProperty("arrivals")]
            public List<Arrival> Arrivals { get; set; }
        }

        public partial class Arrival
        {
            [JsonProperty("origin")]
            public string Origin { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("plannedTrack")]
            public string PlannedTrack { get; set; }

            [JsonProperty("actualTrack")]
            public string ActualTrack { get; set; }

            [JsonProperty("product")]
            public Product Product { get; set; }

            [JsonProperty("trainCategory")]
            public string TrainCategory { get; set; }

            [JsonProperty("cancelled")]
            public bool Cancelled { get; set; }

            [JsonProperty("plannedDateTime")]
            public string PlannedDateTime { get; set; }

            [JsonProperty("plannedTimeZoneOffset")]
            public long PlannedTimeZoneOffset { get; set; }

            [JsonProperty("actualDateTime")]
            public string ActualDateTime { get; set; }

            [JsonProperty("actualTimeZoneOffset")]
            public long ActualTimeZoneOffset { get; set; }
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
    }
}
