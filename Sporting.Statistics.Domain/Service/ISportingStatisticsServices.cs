using Sporting.Statistics.Domain.Models;
using System.Threading.Tasks;

namespace Sporting.Statistics.Domain.Service
{
    public interface ISportingStatisticsServices
    {
        ///<sumary>
        /// Buscar todas as seasons.
        ///</sumary>
        Task<Seasons> GetAllSeason();

        ///<sumary>
        /// Buscar todas as seasons.
        ///</sumary>
        Task GetAllLeaguesBySeason();

        ///<sumary>
        /// Buscar todas as seasons.
        ///</sumary>
        Task GetAllTeamsByLeagueSeason();
    }
}
