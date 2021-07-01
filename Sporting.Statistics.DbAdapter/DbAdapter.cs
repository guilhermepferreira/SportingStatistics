using Dapper;
using Sporting.Statistics.Domain.Adapters;
using Sporting.Statistics.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sporting.Statistics.DbAdapter
{
    public class DbAdapter : IDbAdapter
    {
        private readonly IDbConnection dbConnection;

        static DbAdapter() =>
            SqlMapper.AddTypeMap(typeof(string), DbType.AnsiString);

        public DbAdapter(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection ?? 
                throw new ArgumentNullException(nameof(dbConnection));
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

        public async Task<League> BuscarLeague(int league)
        {
            var result = await dbConnection.QueryFirstOrDefaultAsync<League>(
               @"SELECT 
                    A.
                FROM seasons WHERE Ano = @season", param: new { league });
            return result;
        }
    }
}
