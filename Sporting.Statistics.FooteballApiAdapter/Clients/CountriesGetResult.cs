using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sporting.Statistics.FooteballApiAdapter.Clients
{
    public class CountriesGetResult : GetResponseBase
    {
        [JsonProperty(PropertyName = "response")]
        public IEnumerable<CountryDto> Response { get; set; }
    }
}
