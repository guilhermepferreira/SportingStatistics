using System;
using System.Collections.Generic;
using System.Text;

namespace Sporting.Statistics.Domain.Models
{
    public class Venue
    {
        public int IdentificadorFornecedor { get; set; }
        
        public string Name { get; set; }
        
        public string Address { get; set; }
        
        public string City { get; set; }
        
        public int? Capacity { get; set; }
        
        public string Surface { get; set; }
        
        public string Image { get; set; }
    }
}
