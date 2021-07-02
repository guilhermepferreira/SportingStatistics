using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sporting.Statistics.FooteballApiAdapter.Clients
{
    public class TeamsGetResult : GetResultBase
    {
        [JsonProperty(PropertyName = "response")]
        public IEnumerable<TeamsResult> Response { get; set; }
    }
}
