using Newtonsoft.Json;

namespace Sporting.Statistics.FooteballApiAdapter.Clients
{
    public class LeagueInfoDto
    {
        [JsonProperty(PropertyName = "id")]
        public int? IdentificadorLiga { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string TipoLiga { get; set; }

        [JsonProperty(PropertyName = "logo")]
        public string Logo { get; set; }
    }
}
