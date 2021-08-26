using Dapper;
using Sporting.Statistics.Domain.Adapters;
using Sporting.Statistics.Domain.Models;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Sporting.Statistics.DbAdapter
{
    public class DbWriteAdapter : IDbWriteAdapter
    {
        private readonly IDbConnection dbConnection;

        static DbWriteAdapter() =>
            SqlMapper.AddTypeMap(typeof(string), DbType.AnsiString);

        public DbWriteAdapter(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection ??
                throw new ArgumentNullException(nameof(dbConnection));
        }

        public async Task<Guid> InserirCoverage(Coverage cobertura)
        {
            var identificador = await dbConnection.ExecuteScalarAsync<Guid>(
                @"INSERT INTO Coverage
                (Events, 
                    Lineups,
                    StatisticsFixtures,
                    StatisticsPlayers,
                    Standings,
                    Players,
                    TopScorers,
                    TopAssists, 
                    TopCards, 
                    Injuries, 
                    Predictions,
                    Odds)
                output Inserted.Identificador
                VALUES(@Eventos, 
                        @Formacao,
                        @EstastisticasPartidas,
                        @EstastisticasJogadores,
                        @Classificacao,
                        @Jogadores,
                        @TopPontuacao,
                        @TopAssistencias,
                        @TopCartoes,
                        @Machucados,
                        @Previsoes,
                        @Odds)",
                  new
                  {
                      cobertura.Fixtures.Eventos,
                      cobertura.Fixtures.Formacao,
                      cobertura.Fixtures.EstastisticasPartidas,
                      cobertura.Fixtures.EstastisticasJogadores,
                      cobertura.Classificacao,
                      cobertura.Jogadores,
                      cobertura.TopPontuacao,
                      cobertura.TopAssistencias,
                      cobertura.TopCartoes,
                      cobertura.Machucados,
                      cobertura.Previsoes,
                      cobertura.Odds
                  });

            return identificador;
        }

        public async Task InserirLeague(League league)
        {
            await dbConnection.ExecuteAsync(
                @"INSERT INTO Leagues
                (   IdLigaFornecedor, 
                    Nome, 
                    Logo, 
                    Season,
                    Inicio, 
                    Fim,
                    Atual,
                    IdentificadorCoverage,
                    IdentificadorPais,
                    IdentificadorType)
                VALUES
                (@IdentificadorLiga,
                    @Nome, 
                    @Logo,
                    @Ano,
                    @Inicio,
                    @Fim,
                    @Atual,
                    @IdentificadorCobertura,
                    @IdentificadorPais,
                    @IdentificadorTipo)",
                  new
                  {
                      league.Liga.IdentificadorLiga,
                      league.Liga.Nome,
                      league.Liga.Logo,
                      league.Seasons.FirstOrDefault().Ano,
                      league.Seasons.FirstOrDefault().Inicio,
                      league.Seasons.FirstOrDefault().Fim,
                      league.Seasons.FirstOrDefault().Atual,
                      league.IdentificadorCobertura,
                      league.IdentificadorPais,
                      league.IdentificadorTipo,
                  });
        }

        public async Task<Guid> InserirLeagueType(string type)
        {
           var identificador = await dbConnection.ExecuteScalarAsync<Guid>(
                @"INSERT INTO Tipo
                        (Type)
                output Inserted.Identificador
	            VALUES (@type)",
                  new
                  {
                      type
                  });

            return identificador;
        }

        public async Task<Guid> InserirPais(Country pais)
        {
            var identificador = await dbConnection.ExecuteScalarAsync<Guid>(
                @"INSERT INTO Country
                        (Nome, Codigo, Bandeira)
                output Inserted.Identificador
	            VALUES (@Nome, @Codigo, @Bandeira)",
                  new
                  {
                      pais.Nome,
                      pais.Codigo,
                      pais.Bandeira
                  });

            return identificador;
        }

        public async Task InserirSeason(int seasonsResult)
        {
            await dbConnection.ExecuteAsync(
                @"INSERT INTO seasons
                        (Ano)
	            VALUES (@Ano)",
                  new
                  {
                      Ano = seasonsResult
                  });
        }

        public async Task<Guid> InserirTeam(Team team)
        {
            try
            {
                return await dbConnection.ExecuteScalarAsync<Guid>(
                    @"INSERT INTO Teams
                        (IdFornecedor, IdentificadorPais, IdentificadorVenue, Nome, Fundado, Nacional, Logo)
                output Inserted.Identificador
	            VALUES (@IdFornecedor, @IdentificadorPais, @IdentificadorEstadio, @Nome, @Fundado, @Nacional, @Logo)",
                      new
                      {
                          team.IdFornecedor,
                          team.IdentificadorPais,
                          team.IdentificadorEstadio,
                          team.Nome,
                          team.Fundado,
                          team.Nacional,
                          team.Logo,
                      });
            }catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<Guid> InserirEstadio(Venue venue)
        {
            return await dbConnection.ExecuteScalarAsync<Guid>(
                @"INSERT INTO Venue
                        (IdFornecedor, Nome, Endereco, Cidade, Capacidade, Surface, Imagem)
                output Inserted.Identificador
	            VALUES (@IdFornecedor, @Nome, @Endereco, @Cidade, @Capacidade, @Surface, @Imagem)",
                  new
                  {
                      venue.IdFornecedor,
                      venue.Nome,
                      venue.Endereco,
                      venue.Cidade,
                      venue.Capacidade,
                      venue.Surface,
                      venue.Imagem,
                  });
        }

        public async Task InserirTeamLeagueSeason(
            Team time, League league, Season season)
        {
            try
            {
                await dbConnection.ExecuteAsync(
                    @"INSERT INTO TeamLeagueSeason
                        (IdentificadorTime, IdentificadorLiga, IdentificadorSeason, DataInsert)
	            VALUES (@IdentificadorTime, @IdentificadorLiga, @IdentificadorSeason, GETDATE())",
                      new
                      {
                          IdentificadorTime = time.Identificador,
                          IdentificadorLiga = league.Identificador,
                          IdentificadorSeason = season.Identificador,
                      });
            }catch(Exception e)
            {
                throw e;
            }
        }
    }
}
