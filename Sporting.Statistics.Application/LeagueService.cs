using Sporting.Statistics.Domain.Adapters;
using Sporting.Statistics.Domain.Models;
using Sporting.Statistics.Domain.Service;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sporting.Statistics.Application
{
    public class LeagueService : ILeagueService
    {
        private readonly ISportingStatisticsFooteballApiAdapter statisticsFooteballApiAdapter;
        private readonly IDbReadAdapter dbReadAdapter;
        private readonly IDbWriteAdapter dbWriteAdapter;
        public LeagueService(ISportingStatisticsFooteballApiAdapter
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
        public async Task GetAllLeaguesBySeason()
        {
            var seasonRetorno = await dbReadAdapter
                .BuscarSeason(DateTime.Now.Year);

            var leaguesResult = await statisticsFooteballApiAdapter
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
    }
}
