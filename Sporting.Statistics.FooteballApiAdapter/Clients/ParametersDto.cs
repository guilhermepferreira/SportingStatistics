using Newtonsoft.Json;

namespace Sporting.Statistics.FooteballApiAdapter.Clients
{
    public class ParametersDto
    {
        [JsonProperty(PropertyName = "season")]
        public string Season { get; set; }
    }
}
