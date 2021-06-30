using Newtonsoft.Json;

namespace Sporting.Statistics.FooteballApiAdapter.Clients
{
    public class CountryDto
    {
        [JsonProperty(PropertyName = "name")]
        public string Nome { get; set; }
        [JsonProperty(PropertyName = "code")]
        public string Codigo { get; set; }
        [JsonProperty(PropertyName = "flag")]
        public string Bandeira { get; set; }
    }
}
