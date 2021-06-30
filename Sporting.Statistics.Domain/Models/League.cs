using System.Collections.Generic;

namespace Sporting.Statistics.Domain.Models
{
    public class League
    {
        public LeagueInfo Liga { get; set; }
        public Country Pais { get; set; }
        public IEnumerable<LeagueSeasons> Seasons { get; set; }
    }
}
