using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sporting.Statistics.FooteballApiAdapter.Clients
{
    public class FixturesDto
    {
        [JsonProperty(PropertyName = "events")]
        public bool Eventos { get; set; }
        [JsonProperty(PropertyName = "lineups")]
        public bool Formacao { get; set; }
        [JsonProperty(PropertyName = "statistics_fixtures")]
        public bool EstastisticasPartidas { get; set; }
        [JsonProperty(PropertyName = "statistics_players")]
        public bool EstastisticasJogadores { get; set; }
    }
}
