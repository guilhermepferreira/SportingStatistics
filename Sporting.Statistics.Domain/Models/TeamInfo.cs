using System;

namespace Sporting.Statistics.Domain.Models
{
    public class TeamInfo
    {
        public Guid Identificador { get; set; }

        public Guid IdentificadorVenue { get; set; }

        public Guid IdentificadorCountry { get; set; }

        public int IdentificadorFornecedor { get; set; }
        
        public string Name { get; set; }
       
        public string Country { get; set; }
        
        public int? Founded { get; set; }
       
        public bool National { get; set; }
      
        public string Logo { get; set; }
    }
}
