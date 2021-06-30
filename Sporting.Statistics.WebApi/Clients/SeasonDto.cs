using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sporting.Statistics.WebApi.Clients
{
    public class SeasonDto
    {
        public Guid Identificador { get; set; }
        public int? Ano { get; set; }
    }
}
