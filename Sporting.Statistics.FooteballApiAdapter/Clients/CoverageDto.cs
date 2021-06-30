using Newtonsoft.Json;

namespace Sporting.Statistics.FooteballApiAdapter.Clients
{
    public class CoverageDto
    {
        [JsonProperty(PropertyName = "fixtures")]
        public FixturesDto Fixtures { get; set; }

        [JsonProperty(PropertyName = "standings")]
        public bool Classificacao { get; set; }

        [JsonProperty(PropertyName = "players")]
        public bool Jogadores { get; set; }

        [JsonProperty(PropertyName = "top_scorers")]
        public bool TopPontuacao { get; set; }

        [JsonProperty(PropertyName = "top_assists")]
        public bool TopAssistencias { get; set; }

        [JsonProperty(PropertyName = "top_cards")]
        public bool TopCartoes { get; set; }

        [JsonProperty(PropertyName = "injuries")]
        public bool Machucados { get; set; }

        [JsonProperty(PropertyName = "predictions")]
        public bool Previsoes { get; set; }

        [JsonProperty(PropertyName = "odds")]
        public bool Odds { get; set; }
    }
}
