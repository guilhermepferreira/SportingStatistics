using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sporting.Statistics.WebApi.Clients
{
    public class SeasonsGetResult
    {
        public IEnumerable<SeasonDto> ListaSeasons { get; set; }
    }
}
