namespace Sporting.Statistics.Domain.Models
{
    public class Coverage
    {
        public Fixtures Fixtures { get; set; }
        public bool Classificacao { get; set; }
        public bool Jogadores { get; set; }
        public bool TopPontuacao { get; set; }
        public bool TopAssistencias { get; set; }
        public bool TopCartoes { get; set; }
        public bool Machucados { get; set; }
        public bool Previsoes { get; set; }
        public bool Odds { get; set; }
    }
}
