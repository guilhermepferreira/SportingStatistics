using Dapper;
using Sporting.Statistics.Domain.Adapters;
using Sporting.Statistics.Domain.Models;
using System;
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
    }
}
