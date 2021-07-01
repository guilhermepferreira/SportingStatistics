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
        private readonly IDbReadAdapter dbReadAdapter;
        private readonly IDbWriteAdapter dbWriteAdapter;
        public SportingStatisticsServices(ISportingStatisticsFooteballApiAdapter
            countriesFooteballApiAdapter,
            IDbReadAdapter dbReadAdapter,
            IDbWriteAdapter dbWriteAdapter)
        {
            this.countriesFooteballApiAdapter = countriesFooteballApiAdapter ??
                throw new ArgumentNullException(nameof(countriesFooteballApiAdapter));
            
            this.dbReadAdapter = dbReadAdapter ??
                throw new ArgumentNullException(nameof(dbReadAdapter));
            
            this.dbWriteAdapter = dbWriteAdapter ??
                throw new ArgumentNullException(nameof(dbWriteAdapter));
        }

        public async Task GetAllLeaguesBySeason()
        {
            var seasonRetorno = await dbReadAdapter
                .BuscarSeason(DateTime.Now.Year);

            var leaguesResult = await countriesFooteballApiAdapter
                .BuscarLeagueBySeason(seasonRetorno);

            foreach (League league in leaguesResult.Response) 
            {
                var identificadorLeague = await dbReadAdapter
                    .BuscarLeague(league.Liga.IdentificadorLiga);

                if (identificadorLeague != Guid.Empty)
                {
                    continue;
                }

                league.IdentificadorTipo = 
                    await BuscarLeagueType(league.Liga.TipoLiga.Tipo);

                league.IdentificadorPais = 
                    await BuscarPais(league.Pais);

                league.IdentificadorCobertura = await InserirCoberturaAsync(
                    league.Seasons.FirstOrDefault().Coverage);

                await dbWriteAdapter
                    .InserirLeague(league);

            }
        }

        private async Task<Guid> InserirCoberturaAsync(Coverage cobertura)
        {
            var identificadorPais = await dbWriteAdapter
                .InserirCoverage(cobertura);
            
            return identificadorPais;
        }

        private async Task<Guid> BuscarPais(Country pais)
        {
            var identificadorPais = await dbReadAdapter
                    .BuscarIdentificadorPaisAsync(pais.Nome);

            if (identificadorPais == Guid.Empty)
            {
                identificadorPais = await dbWriteAdapter
                    .InserirPais(pais);
            }

            return identificadorPais;
        }

        private async Task<Guid> BuscarLeagueType(string tipo)
        {
            var identificadorType = await dbReadAdapter
                    .BuscarLeagueType(tipo);

            if (identificadorType == Guid.Empty)
            {
                identificadorType = await dbWriteAdapter
                    .InserirLeagueType(tipo);
            }

            return identificadorType;
        }
        public async Task<Seasons> GetAllSeason()
        {
            var seasons = await dbReadAdapter.BuscarSeasons();

            var seasonsApi = await countriesFooteballApiAdapter.BuscarSeasons();

            foreach (int ano in seasonsApi.Seasons) 
            {
                var inserted = seasons.ListaSeasons.FirstOrDefault(m => m.Ano == ano);
                if (inserted?.Ano == ano) 
                {
                    continue;
                }
                await dbWriteAdapter.InserirSeason(ano);
            }
            seasons = await dbReadAdapter.BuscarSeasons();

            return seasons;
        }
    }
}
