using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sporting.Statistics.FooteballApiAdapter.Clients
{
    public class LeagueSeasonsDto
    {
        [JsonProperty(PropertyName = "year")]
        public int Ano { get; set; }
        [JsonProperty(PropertyName = "start")]
        public DateTimeOffset? Inicio { get; set; }
        [JsonProperty(PropertyName = "end")]
        public DateTimeOffset? Fim { get; set; }
        [JsonProperty(PropertyName = "current")]
        public bool Atual { get; set; }
        [JsonProperty(PropertyName = "coverage")]
        public CoverageDto Coverage { get; set; }
    }
}
