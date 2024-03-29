﻿using Sporting.Statistics.Domain.Models;
using System.Collections.Generic;
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
        /// Buscar todos os países.
        ///</sumary>
        Task<IEnumerable<Country>> GetAllCountry();
    }
}
