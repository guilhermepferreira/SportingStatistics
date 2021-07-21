using Sporting.Statistics.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sporting.Statistics.Domain.Adapters
{
    public interface ISportingStatisticsFooteballApiAdapter
    {
        ///<sumary>
        /// Buscar Seasons
        ///</sumary>
        Task<SeasonsResult> BuscarSeasons();


        ///<sumary>
        /// Buscar Seasons
        ///</sumary>
        ///<param name="season">
        /// Season para buscar todas as ligas.
        /// </param>
        Task<LeaguesResult> BuscarLeagueBySeason(Season season);

        ///<sumary>
        /// Buscar Países
        ///</sumary>
        Task<CountryResult> BuscarPaises();
    }
}
