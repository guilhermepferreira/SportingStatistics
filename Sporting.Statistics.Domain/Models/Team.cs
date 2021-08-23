using System;
using System.Collections.Generic;
using System.Text;

namespace Sporting.Statistics.Domain.Models
{
    public class Team
    {
        public Guid Identificador { get; set; }

        public Guid IdentificadorPais { get; set; }

        public Guid IdentificadorEstadio { get; set; }

        public int IdFornecedor { get; set; }
       
        public string Nome { get; set; }
        
        public string Pais { get; set; }
        
        public int? Fundado { get; set; }
        
        public bool Nacional { get; set; }
       
        public string Logo { get; set; }
    }
}
