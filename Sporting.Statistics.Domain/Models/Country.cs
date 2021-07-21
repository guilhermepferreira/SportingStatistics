using System;

namespace Sporting.Statistics.Domain.Models
{
    public class Country
    {
        public Guid Identificador { get; set; }

        public string Nome { get; set; }

        public string Codigo { get; set; }

        public string Bandeira { get; set; }
    }
}
