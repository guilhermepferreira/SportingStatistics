using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sporting.Statistics.FooteballApiAdapter.Clients
{
    public class SeasonsGetResult
    {
        [JsonProperty(PropertyName = "response")]
        public IEnumerable<int> Seasons { get; set; }
    }
}
