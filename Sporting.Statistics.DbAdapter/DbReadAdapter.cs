using Dapper;
using Sporting.Statistics.Domain.Adapters;
using Sporting.Statistics.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Sporting.Statistics.DbAdapter
{
    public class DbReadAdapter : IDbReadAdapter
    {
        private readonly IDbConnection dbConnection;

        static DbReadAdapter() =>
            SqlMapper.AddTypeMap(typeof(string), DbType.AnsiString);

        public DbReadAdapter(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection ??
                throw new ArgumentNullException(nameof(dbConnection));
        }
        
        public async Task<Seasons> BuscarSeasons()
        {
            var result = await dbConnection.QueryAsync<Season>(
                @"SELECT 
                    Identificador, 
                    Ano 
                FROM seasons");

            var seasons = new Seasons()
            {
                ListaSeasons = result
            };

            return seasons;
        }

        public async Task<Season> BuscarSeason(int season)
        {
            var result = await dbConnection.QueryFirstOrDefaultAsync<Season>(
               @"SELECT 
                    Identificador, 
                    Ano 
                FROM seasons WHERE Ano = @season", param: new { season });
            return result;
        }

        public async Task<Guid> BuscarLeague(int identificadorLiga)
        {
            var result = await dbConnection.QueryFirstOrDefaultAsync<Guid>(
               @"SELECT 
                    Identificador
                FROM Leagues WHERE IdLigaFornecedor = @identificadorLiga", param: new { identificadorLiga });
            return result;
        }

        public async Task<Guid> BuscarLeagueType(string leagueType)
        {
            var result = await dbConnection.QueryFirstOrDefaultAsync<Guid>(
               @"SELECT 
                    Identificador
                FROM Tipo WHERE Type = @leagueType", param: new { leagueType });
            return result;
        }

        public async Task<Guid> BuscarIdentificadorPaisAsync(string nomePais)
        {
            var result = await dbConnection.QueryFirstOrDefaultAsync<Guid>(
               @"SELECT 
                    Identificador
                FROM Country WHERE Nome = @nomePais", param: new { nomePais });
            return result;
        }

        public async Task<IEnumerable<Country>> BuscarPaises()
        {
            var result = await dbConnection.QueryAsync<Country>(
               @"SELECT 
                    Identificador, 
                    Nome,
                    Codigo,
                    Bandeira
                FROM Country");

            return result;
        }

        public async Task<IEnumerable<League>> BuscarLeaguesSeason(int season)
        {
            return await dbConnection.QueryAsync<League>(
               @"
                SELECT 
                    L.Identificador,
                    L.IdentificadorPais,
                    L.IdentificadorType as IdentificadorTipo,
                    L.IdentificadorCoverage as IdentificadorCobertura,
                    L.IdLigaFornecedor as IdentificadorLiga,
                    L.Nome,
                    L.Logo,
                    T.Type as Tipo,
                    L.Season as Ano,
                    L.Inicio,
                    L.Fim,
                    L.Atual,
                    C.Events as Eventos,
                    C.Lineups as Formacao,
                    C.StatisticsFixtures as EstastisticasPartidas,
                    C.StatisticsPlayers as EstastisticasJogadores,
                    C.Standings as Classificacao,
                    C.Players as Jogadores,
                    C.TopScorers as TopPontuacao,
                    C.TopAssists as TopAssistencias,
                    C.TopCards as TopCartoes,
                    C.Injuries as Machucados,
                    C.Predictions as Previsoes,
                    C.Odds,
                    CT.Nome,
                    CT.Codigo,
                    CT.Bandeira
                FROM Leagues L
                INNER JOIN Tipo (NOLOCK) T ON L.IdentificadorType = T.Identificador
                INNER JOIN Coverage (NOLOCK) C ON L.IdentificadorCoverage = C.Identificador
                INNER JOIN Country (NOLOCK) CT ON L.IdentificadorPais = CT.Identificador
                Where L.Season = @Season 
                ORDER BY L.IdLigaFornecedor 
				",
               new[]
                {
                    typeof(League),
                    typeof(LeagueInfo),
                    typeof(LeagueType),
                    typeof(LeagueSeasons),
                    typeof(Fixtures),
                    typeof(Coverage),
                    typeof(Country)
               },
               objeto =>
               {
                   var league = objeto[0] as League;
                   var leagueInfo = objeto[1] as LeagueInfo;
                   var leagueType = objeto[2] as LeagueType;
                   var leagueSeasons = objeto[3] as LeagueSeasons;
                   var fixtures = objeto[4] as Fixtures;
                   var coverage = objeto[5] as Coverage;
                   var country = objeto[6] as Country;

                   league.Liga = leagueInfo;
                   league.Liga.TipoLiga = leagueType;
                   league.Pais = country;
                   coverage.Fixtures = fixtures;
                   leagueSeasons.Coverage = coverage;
                   league.Seasons = new List<LeagueSeasons>()
                    {
                        leagueSeasons
                    };

                   return league;
               },
               param: new
               {
                   season
               },
               splitOn: "IdentificadorLiga,Tipo,Ano,Eventos,Classificacao,Nome");
        }

        public async Task<IEnumerable<Team>> BuscarTimes()
        {
            return await dbConnection.QueryAsync<Team>(
               @"SELECT 
                    Identificador, 
                    IdFornecedor, 
                    IdentificadorPais, 
                    IdentificadorVenue as IdentificadorEstadio, 
                    Nome,
                    Fundado,
                    Nacional,
                    Logo
                FROM Teams");
        }

        public async Task<Venue> BuscarEstadio(int idFornecedor)
        {
            return await dbConnection.QueryFirstOrDefaultAsync<Venue>(
               @"SELECT 
                    Identificador, 
                    IdFornecedor,
                    Nome,
                    Endereco,
                    Cidade,
                    Capacidade,
                    Surface,
                    Imagem
                FROM Venue WHERE IdFornecedor = @idFornecedor", param: new { idFornecedor });
        }
    }
}
