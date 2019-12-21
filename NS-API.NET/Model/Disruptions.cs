using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NS_API.NET.Disruptions
{
    public partial class DisruptionsApi
    {
        [JsonProperty("payload")]
        public List<Payload> Payloads { get; set; }

        public partial class Payload
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("titel")]
            public string Titel { get; set; }

            [JsonProperty("topic")]
            public string Topic { get; set; }

            [JsonProperty("verstoring")]
            public Verstoring Verstoring { get; set; }
        }

        public partial class Verstoring
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("geldigheidsLijst")]
            public List<GeldigheidsLijst> GeldigheidsLijst { get; set; }

            [JsonProperty("verwachting")]
            public string Verwachting { get; set; }

            [JsonProperty("fase")]
            public string Fase { get; set; }

            [JsonProperty("faseLabel")]
            public string FaseLabel { get; set; }

            [JsonProperty("alternatiefVervoer")]
            public string AlternatiefVervoer { get; set; }

            [JsonProperty("landelijk")]
            public bool Landelijk { get; set; }

            [JsonProperty("oorzaak")]
            public string Oorzaak { get; set; }

            [JsonProperty("header")]
            public string Header { get; set; }

            [JsonProperty("meldtijd")]
            public string Meldtijd { get; set; }

            [JsonProperty("baanvakken")]
            public List<Baanvakken> Baanvakken { get; set; }

            [JsonProperty("trajecten")]
            public List<Trajecten> Trajecten { get; set; }

            [JsonProperty("versie")]
            public string Versie { get; set; }

            [JsonProperty("volgnummer")]
            public string Volgnummer { get; set; }

            [JsonProperty("prioriteit")]
            public long Prioriteit { get; set; }

            [JsonProperty("extraReistijd")]
            public string ExtraReistijd { get; set; }

            [JsonProperty("reisadviezen")]
            public Reisadviezen Reisadviezen { get; set; }

            [JsonProperty("gevolg")]
            public string Gevolg { get; set; }

            [JsonProperty("impact")]
            public long? Impact { get; set; }

            [JsonProperty("maatschappij")]
            public long? Maatschappij { get; set; }

            [JsonProperty("periode")]
            public string Periode { get; set; }
        }

        public partial class Baanvakken
        {
            [JsonProperty("stations")]
            public List<string> Stations { get; set; }
        }

        public partial class GeldigheidsLijst
        {
            [JsonProperty("startDatum")]
            public string StartDatum { get; set; }

            [JsonProperty("eindDatum")]
            public string EindDatum { get; set; }
        }

        public partial class Reisadviezen
        {
            [JsonProperty("titel")]
            public string Titel { get; set; }

            [JsonProperty("reisadvies")]
            public List<Reisadvy> Reisadvies { get; set; }
        }

        public partial class Reisadvy
        {
            [JsonProperty("titel")]
            public string Titel { get; set; }

            [JsonProperty("advies")]
            public List<string> Advies { get; set; }
        }

        public partial class Trajecten
        {
            [JsonProperty("stations")]
            public List<string> Stations { get; set; }

            [JsonProperty("begintijd")]
            public string Begintijd { get; set; }

            [JsonProperty("eindtijd")]
            public string Eindtijd { get; set; }

            [JsonProperty("richting")]
            public string Richting { get; set; }
        }
    }
}
