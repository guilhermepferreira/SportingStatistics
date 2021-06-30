using Sporting.Statistics.Domain.Adapters;
using Sporting.Statistics.Domain.Models;
using Sporting.Statistics.Domain.Service;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sporting.Statistics.Application
{
    public class SportingStatisticsServices : ISportingStatisticsServices
    {
        private readonly ISportingStatisticsFooteballApiAdapter countriesFooteballApiAdapter;
        private readonly IDbAdapter dbAdapter;
        public SportingStatisticsServices(ISportingStatisticsFooteballApiAdapter
            countriesFooteballApiAdapter,
            IDbAdapter dbAdapter)
        {
            this.countriesFooteballApiAdapter = countriesFooteballApiAdapter ??
                throw new ArgumentNullException(nameof(countriesFooteballApiAdapter));
            
            this.dbAdapter = dbAdapter ??
                throw new ArgumentNullException(nameof(dbAdapter));
        }

        public async Task GetAllLeaguesBySeason(int season)
        {
            var seasonRetorno = await dbAdapter.BuscarSeason(season);

            var seasonsApi = await countriesFooteballApiAdapter
                .BuscarLeagueBySeason(seasonRetorno);
        }

        public async Task<Seasons> GetAllSeason()
        {
            var seasons = await dbAdapter.BuscarSeasons();

            var seasonsApi = await countriesFooteballApiAdapter.BuscarSeasons();

            foreach (int ano in seasonsApi.Seasons) 
            {
                var inserted = seasons.ListaSeasons.FirstOrDefault(m => m.Ano == ano);
                if (inserted?.Ano == ano) 
                {
                    continue;
                }
                await dbAdapter.InserirSeason(ano);
            }
            seasons = await dbAdapter.BuscarSeasons();

            return seasons;
        }
    }
}
