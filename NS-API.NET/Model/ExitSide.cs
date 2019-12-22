using Newtonsoft.Json;

namespace NS_API.NET.ExitSide
{
    public partial class ExitSideApi
    {
        [JsonProperty("uitstapzijde")]
        public string Uitstapzijde { get; set; }
    }
}