using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sporting.Statistics.FooteballApiAdapter.Clients
{
    public class LeagueDto
    {
        [JsonProperty(PropertyName = "league")]
        public LeagueInfoDto Liga { get; set; }
        
        [JsonProperty(PropertyName = "country")]
        public CountryDto Pais { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        public IEnumerable<LeagueSeasonsDto> Seasons { get; set; }
    }
}
