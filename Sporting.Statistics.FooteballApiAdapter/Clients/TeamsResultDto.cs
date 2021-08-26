using Newtonsoft.Json;

namespace Sporting.Statistics.FooteballApiAdapter.Clients
{
    public class TeamsResultDto
    {
        [JsonProperty(PropertyName = "team")]
        public TeamDto Team { get; set; }
        [JsonProperty(PropertyName = "venue")]
        public VenueDto Venue { get; set; }
    }
}
