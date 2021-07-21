using System.Collections.Generic;

namespace Sporting.Statistics.WebApi.Clients
{
    public class SeasonsGetResult
    {
        public IEnumerable<SeasonDto> ListaSeasons { get; set; }
    }
}