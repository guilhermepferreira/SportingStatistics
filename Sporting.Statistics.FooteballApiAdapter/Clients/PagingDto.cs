using Newtonsoft.Json;

namespace Sporting.Statistics.FooteballApiAdapter.Clients
{
    public class PagingDto
    {
        [JsonProperty(PropertyName = "current")]
        public int Current { get; set; }
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }
    }
}
