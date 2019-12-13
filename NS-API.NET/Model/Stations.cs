using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NS_API.NET.Stations
{
    public partial class StationsApi
    {
        [JsonProperty("payload")]
        public List<Payload> Payloads { get; set; }

        public partial class Payload
        {
            [JsonProperty("sporen")]
            public List<Sporen> Sporen { get; set; }

            [JsonProperty("synoniemen")]
            public List<string> Synoniemen { get; set; }

            [JsonProperty("heeftFaciliteiten")]
            public bool HeeftFaciliteiten { get; set; }

            [JsonProperty("heeftVertrektijden")]
            public bool HeeftVertrektijden { get; set; }

            [JsonProperty("heeftReisassistentie")]
            public bool HeeftReisassistentie { get; set; }

            [JsonProperty("code")]
            public string Code { get; set; }

            [JsonProperty("namen")]
            public Namen Namen { get; set; }

            [JsonProperty("stationType")]
            public string StationType { get; set; }

            [JsonProperty("land")]
            public string Land { get; set; }

            [JsonProperty("UICCode")]
            public string UicCode { get; set; }

            [JsonProperty("lat")]
            public double Lat { get; set; }

            [JsonProperty("lng")]
            public double Lng { get; set; }

            [JsonProperty("radius")]
            public long Radius { get; set; }

            [JsonProperty("naderenRadius")]
            public long NaderenRadius { get; set; }

            [JsonProperty("EVACode")]
            public string EvaCode { get; set; }
        }

        public partial class Namen
        {
            [JsonProperty("lang")]
            public string Lang { get; set; }

            [JsonProperty("kort")]
            public string Kort { get; set; }

            [JsonProperty("middel")]
            public string Middel { get; set; }
        }

        public partial class Sporen
        {
            [JsonProperty("spoorNummer")]
            public string SpoorNummer { get; set; }
        }
    }
}
