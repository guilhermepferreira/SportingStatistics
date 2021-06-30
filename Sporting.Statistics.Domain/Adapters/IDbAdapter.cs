using Sporting.Statistics.Domain.Models;
using System.Threading.Tasks;

namespace Sporting.Statistics.Domain.Adapters
{
    public interface IDbAdapter
    {
        ///<summary>
        /// Inserir seasons que faltam.
        ///</summary>
        ///<param name="season">
        /// Dados a serem inseridos.
        ///</param>
        Task InserirSeason(int season);
        
        ///<summary>
        /// Buscar Todas as Seasons
        ///</summary>
        Task<Seasons> BuscarSeasons();

        ///<summary>
        /// Buscar Todas as Seasons
        ///</summary>
        Task<Season> BuscarSeason(int season);
    }
}
