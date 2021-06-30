using Newtonsoft.Json;

namespace Sporting.Statistics.FooteballApiAdapter.Clients
{
    public class ErrosDto
    {
        [JsonProperty(PropertyName = "season")]
        public string Season { get; set; }
    }
}
