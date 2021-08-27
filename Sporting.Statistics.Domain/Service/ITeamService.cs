using Sporting.Statistics.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sporting.Statistics.Domain.Service
{
    public interface ITeamService
    {
        ///<sumary>
        /// Buscar todas os times pela liga e season.
        ///</sumary>
        Task<IEnumerable<Team>> GetAllTeamsByLeagueSeason();
    }
}
