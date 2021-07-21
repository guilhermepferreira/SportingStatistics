using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sporting.Statistics.FooteballApiAdapter.Clients
{
    public class SeasonLeaguesGetResult : GetResponseBase
    {
        [JsonProperty(PropertyName = "response")]
        public IEnumerable<LeagueDto> Response { get; set; }

        [JsonProperty(PropertyName = "parameters")]
        public ParametersDto Parameters { get; set; }
    }
}
