using Sporting.Statistics.Domain.Adapters;
using Sporting.Statistics.Domain.Models;
using Sporting.Statistics.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sporting.Statistics.Application
{
    public class SportingStatisticsServices : ISportingStatisticsServices
    {
        private readonly ISportingStatisticsFooteballApiAdapter statisticsFooteballApiAdapter;
        private readonly IDbReadAdapter dbReadAdapter;
        private readonly IDbWriteAdapter dbWriteAdapter;
        public SportingStatisticsServices(ISportingStatisticsFooteballApiAdapter
            statisticsFooteballApiAdapter,
            IDbReadAdapter dbReadAdapter,
            IDbWriteAdapter dbWriteAdapter)
        {
            this.statisticsFooteballApiAdapter = statisticsFooteballApiAdapter ??
                throw new ArgumentNullException(nameof(statisticsFooteballApiAdapter));
            
            this.dbReadAdapter = dbReadAdapter ??
                throw new ArgumentNullException(nameof(dbReadAdapter));
            
            this.dbWriteAdapter = dbWriteAdapter ??
                throw new ArgumentNullException(nameof(dbWriteAdapter));
        }

        public async Task<Seasons> GetAllSeason()
        {
            var seasons = await dbReadAdapter.BuscarSeasons();

            var seasonsApi = await statisticsFooteballApiAdapter.BuscarSeasons();

            foreach (int ano in seasonsApi.Seasons) 
            {
                var inserted = seasons.ListaSeasons.FirstOrDefault(m => m.Ano == ano);
                if (inserted?.Ano == ano) 
                {
                    continue;
                }
                await dbWriteAdapter.InserirSeason(ano);
            }

            return await dbReadAdapter.BuscarSeasons();
        }

        public async Task<IEnumerable<Country>> GetAllCountry()
        {
            var countries = await dbReadAdapter.BuscarPaises();

            var countriesApi = await statisticsFooteballApiAdapter.BuscarPaises();

            foreach(Country pais in countriesApi.Countries)
            {
                var inserted = countries is null ? null : countries.FirstOrDefault(m => m.Nome == pais.Nome);
                if(inserted != null)
                {
                    continue;
                }

                await dbWriteAdapter.InserirPais(pais);
            }

            return await dbReadAdapter.BuscarPaises();
        }
    }
}
