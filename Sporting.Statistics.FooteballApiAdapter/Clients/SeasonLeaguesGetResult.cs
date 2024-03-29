﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sporting.Statistics.FooteballApiAdapter.Clients
{
    public class SeasonLeaguesGetResult : GetResultBaseParameters
    {
        [JsonProperty(PropertyName = "response")]
        public IEnumerable<LeagueDto> Response { get; set; }
    }
}
