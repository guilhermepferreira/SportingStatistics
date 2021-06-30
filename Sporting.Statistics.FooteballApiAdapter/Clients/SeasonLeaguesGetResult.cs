using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sporting.Statistics.FooteballApiAdapter.Clients
{
    public class SeasonLeaguesGetResult
    {
        [JsonProperty(PropertyName = "get")]
        public string Get { get; set; }

        [JsonProperty(PropertyName = "response")]
        public IEnumerable<LeagueDto> Response { get; set; }

        [JsonProperty(PropertyName = "parameters")]
        public ParametersDto Parameters { get; set; }
        
        [JsonProperty(PropertyName = "results")]
        public int Results { get; set; }
        
        [JsonProperty(PropertyName = "paging")]
        public PagingDto Paging { get; set; }
    }
}
