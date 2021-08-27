using Sporting.Statistics.Domain.Adapters;
using Sporting.Statistics.Domain.Models;
using Sporting.Statistics.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sporting.Statistics.Application
{
    public class TeamService : ITeamService
    {
        private readonly ISportingStatisticsFooteballApiAdapter statisticsFooteballApiAdapter;
        private readonly IDbReadAdapter dbReadAdapter;
        private readonly IDbWriteAdapter dbWriteAdapter;

        public TeamService(ISportingStatisticsFooteballApiAdapter
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

        public async Task<IEnumerable<Team>> GetAllTeamsByLeagueSeason()
        {
            try
            {
                var leagues = await dbReadAdapter
                    .BuscarLeaguesSeason(DateTime.Now.Year);

                var season = await dbReadAdapter.BuscarSeason(DateTime.Now.Year);

                foreach (League league in leagues)
                {
                    var times = await dbReadAdapter.BuscarTimes();

                    var timesApi = await statisticsFooteballApiAdapter
                        .BuscarTeamsByLeagueSeason(league);

                    foreach (TeamResult timeResult in timesApi)
                    {
                        var inserted = times is null ? null : times
                            .FirstOrDefault(a => a.IdFornecedor == timeResult.Time.IdFornecedor);

                        if (inserted != null)
                        {
                            var teamLeagueSeason = await dbReadAdapter
                                .BuscarTeamLeagueSeasonByTeam(
                                inserted.Identificador, league.Identificador, season.Identificador);

                            if (teamLeagueSeason == null)
                            {
                                await dbWriteAdapter
                                .InserirTeamLeagueSeason(inserted, league, season);
                            }

                            continue;
                        }

                        var identificadorPais = await dbReadAdapter
                            .BuscarIdentificadorPaisAsync(timeResult.Time.Pais);

                        if (identificadorPais != Guid.Empty)
                        {
                            timeResult.Time.IdentificadorPais = identificadorPais;
                        }

                        if (timeResult.Estadio?.IdFornecedor != null)
                        {
                            timeResult.Time.IdentificadorEstadio =
                            await BuscarOuCriarEstadio(timeResult.Estadio);
                        }

                        timeResult.Time.Identificador =
                            await dbWriteAdapter.InserirTeam(timeResult.Time);



                        await dbWriteAdapter
                            .InserirTeamLeagueSeason(timeResult.Time, league, season);
                    }
                }

                return await dbReadAdapter.BuscarTimes();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private async Task<Guid> BuscarOuCriarEstadio(Venue venue)
        {
            var estadio = await dbReadAdapter
                .BuscarEstadio(venue?.IdFornecedor);

            if (estadio != null)
            {
                return estadio.Identificador;
            }

            return await dbWriteAdapter.InserirEstadio(venue);
        }
    }
}
