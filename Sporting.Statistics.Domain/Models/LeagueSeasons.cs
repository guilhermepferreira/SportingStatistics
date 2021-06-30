using System;
using System.Collections.Generic;
using System.Text;

namespace Sporting.Statistics.Domain.Models
{
    public class LeagueSeasons
    {
        public int Ano { get; set; }

        public DateTimeOffset? Inicio { get; set; }
        
        public DateTimeOffset? Fim { get; set; }

        public bool Atual { get; set; }

    }
}
