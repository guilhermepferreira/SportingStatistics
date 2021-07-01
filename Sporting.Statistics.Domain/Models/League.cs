using System;
using System.Collections.Generic;

namespace Sporting.Statistics.Domain.Models
{
    public class League
    {
        public Guid Identificador { get; set; }
        public Guid IdentificadorPais { get; set; }
        public Guid IdentificadorTipo { get; set; }
        public Guid IdentificadorCobertura { get; set; }
        public LeagueInfo Liga { get; set; }
        public Country Pais { get; set; }
        public IEnumerable<LeagueSeasons> Seasons { get; set; }
    }
}
