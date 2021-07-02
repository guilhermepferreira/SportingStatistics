using Newtonsoft.Json;

namespace Sporting.Statistics.FooteballApiAdapter.Clients
{
    public class TeamDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
        [JsonProperty(PropertyName = "founded")]
        public int? Founded { get; set; }
        [JsonProperty(PropertyName = "national")]
        public bool National { get; set; }
        [JsonProperty(PropertyName = "logo")]
        public string Logo { get; set; }
    }
}
