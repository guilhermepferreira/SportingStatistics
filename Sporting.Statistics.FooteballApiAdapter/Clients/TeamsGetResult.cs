using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sporting.Statistics.FooteballApiAdapter.Clients
{
    public class TeamsGetResult : GetResultBaseParameters
    {
        [JsonProperty(PropertyName = "response")]
        public IEnumerable<TeamsResultDto> Response { get; set; }
    }
}
