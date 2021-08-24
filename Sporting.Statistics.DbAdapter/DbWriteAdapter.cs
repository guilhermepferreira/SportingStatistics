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

        public async Task InserirTeam(TeamInfo team)
        {
            await dbConnection.ExecuteAsync(
                @"INSERT INTO Teams
                        (IdentificadorPais,
                            IdentificadorVenue,
                            IdentificadorFornecedor,
                            Nome,
                            Ano,
                            Nacional,
                            Logo)
	            VALUES (@IdentificadorPais,
                        @IdentificadorVenue,
                        @IdentificadorFornecedor,
                        @Nome,
                        @Ano,
                        @Nacional,
                        @Logo)",
                  new
                  {
                      IdentificadorPais = team.IdentificadorCountry,
                      IdentificadorVenue = team.IdentificadorVenue,
                      IdentificadorFornecedor = team.IdentificadorFornecedor,
                      Nome = team.Name,
                      Ano = team.Founded,
                      Nacional = team.National,
                      Logo = team.Logo
                  });
        }

        public async Task<Guid> InserirVenue(Venue venue)
        {
            var identificador = await dbConnection.ExecuteScalarAsync<Guid>(
               @"INSERT INTO Venue
                        (IdentificadorFornecedor,
                         Nome,
                         Endereco,
                         Cidade,
                         Capacidade,
                         Surface,
                         Imagem)
                output Inserted.Identificador
	            VALUES (@IdentificadorFornecedor,
                        @Nome,
                        @Endereco,
                        @Cidade,
                        @Capacidade,
                        @Surface,
                        @Imagem)",
                 new
                 {
                     IdentificadorFornecedor = venue.IdentificadorFornecedor,
                     Nome = venue.Name,
                     Endereco = venue.Address,
                     Cidade = venue.City,
                     Capacidade = venue.Capacity,
                     Surface = venue.Surface,
                     Imagem = venue.Image,
                 });

            return identificador;
        }
    }
}
