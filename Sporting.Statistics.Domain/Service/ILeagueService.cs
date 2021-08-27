using System.Threading.Tasks;

namespace Sporting.Statistics.Domain.Service
{
    public interface ILeagueService
    {
        ///<sumary>
        /// Buscar todas as ligas pela season.
        ///</sumary>
        Task GetAllLeaguesBySeason();
    }
}
