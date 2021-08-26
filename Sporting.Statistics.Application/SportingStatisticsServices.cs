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
                                inserted.Identificador, league.Identificador,season.Identificador);

                            if(teamLeagueSeason == null)
                            {
                                await dbWriteAdapter
                                .InserirTeamLeagueSeason(inserted, league, season);
                            }
                            
                            continue;
                        }

                        var identificadorPais = await dbReadAdapter
                            .BuscarIdentificadorPaisAsync(timeResult.Time.Pais);

                        if(identificadorPais != Guid.Empty)
                        {
                            timeResult.Time.IdentificadorPais = identificadorPais;
                        }
                        
                        if(timeResult.Estadio?.IdFornecedor != null)
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

            if(estadio != null)
            {
                return estadio.Identificador;
            }

            if(venue.IdFornecedor == null)
            {
                var teste = venue;
            }

            return await dbWriteAdapter.InserirEstadio(venue);
        }
    }
}
