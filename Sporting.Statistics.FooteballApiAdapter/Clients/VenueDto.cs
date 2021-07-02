using Newtonsoft.Json;

namespace Sporting.Statistics.FooteballApiAdapter.Clients
{
    public class VenueDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }
        [JsonProperty(PropertyName = "capacity")]
        public int? Capacity { get; set; }
        [JsonProperty(PropertyName = "surface")]
        public string  Surface { get; set; }
        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }
    }
}
