using Sporting.Statistics.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sporting.Statistics.Domain.Adapters
{
    public interface IDbReadAdapter
    {       
        ///<summary>
        /// Buscar Todas as Seasons
        ///</summary>
        Task<Seasons> BuscarSeasons();

        ///<summary>
        /// Buscar Todas as Seasons
        ///</summary>
        Task<Season> BuscarSeason(int season);

        ///<summary>
        /// Buscar Todas as Seasons
        ///</summary>
        Task<Guid> BuscarLeague(int identificadorLiga);

        ///<summary>
        /// Buscar Todas as Seasons
        ///</summary>
        Task<IEnumerable<League>> BuscarLeaguesSeason(int season);

        ///<summary>
        /// Buscar Todas as Seasons
        ///</summary>
        Task<Guid> BuscarLeagueType(string leagueType);
        
        ///<summary>
        /// Buscar Todas as Seasons
        ///</summary>
        Task<Guid> BuscarIdentificadorPaisAsync(string nomePais);

        ///<summary>
        /// Buscar Todos os países
        ///</summary>
        Task<IEnumerable<Country>> BuscarPaises();
    }
}
