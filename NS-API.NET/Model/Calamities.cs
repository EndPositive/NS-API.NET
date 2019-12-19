using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NS_API.NET.Calamities
{
    public partial class CalamitiesApi
    {
        [JsonProperty("meldingen")]
        public List<Melding> Meldingen { get; set; }
        
        public partial class Melding
        {
            [JsonProperty("id")] public string Id { get; set; }

            [JsonProperty("titel")] public string Titel { get; set; }

            [JsonProperty("beschrijving")] public string Beschrijving { get; set; }

            [JsonProperty("type")] public string Type { get; set; }

            [JsonProperty("url")] public Uri Url { get; set; }

            [JsonProperty("buttonPositie")] public string ButtonPositie { get; set; }

            [JsonProperty("laatstGewijzigd")] public long LaatstGewijzigd { get; set; }

            [JsonProperty("volgendeUpdate")] public long VolgendeUpdate { get; set; }

            [JsonProperty("bodyitems")] public List<object> Bodyitems { get; set; }

            [JsonProperty("calltoactionbuttons")] public List<Calltoactionbutton> Calltoactionbuttons { get; set; }
        }

        public partial class Calltoactionbutton
        {
            [JsonProperty("callToAction")] public string CallToAction { get; set; }

            [JsonProperty("openInNieuwVenter")] public bool OpenInNieuwVenter { get; set; }

            [JsonProperty("type")] public string Type { get; set; }

            [JsonProperty("url")] public Uri Url { get; set; }

            [JsonProperty("voorleestitel")] public string Voorleestitel { get; set; }
        }
    }
}