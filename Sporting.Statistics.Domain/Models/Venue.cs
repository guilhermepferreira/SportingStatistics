using System;

namespace Sporting.Statistics.Domain.Models
{
    public class Venue
    {
        public Guid Identificador { get; set; }
        public int? IdFornecedor { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public int? Capacidade { get; set; }
        public string Surface { get; set; }
        public string Imagem { get; set; }
    }
}
