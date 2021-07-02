using Newtonsoft.Json;

namespace Sporting.Statistics.FooteballApiAdapter.Clients
{
    public class TeamsResult
    {
        [JsonProperty(PropertyName = "team")]
        public TeamDto Team { get; set; }
        [JsonProperty(PropertyName = "venue")]
        public VenueDto Venue { get; set; }
    }
}
