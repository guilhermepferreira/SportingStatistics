using Sporting.Statistics.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
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
        ///<param name="season">
        /// Season para buscar as ligas.
        /// </param>
        Task GetAllLeaguesBySeason(int season);
    }
}
