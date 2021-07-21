using Refit;
using System.Threading.Tasks;

namespace Sporting.Statistics.FooteballApiAdapter.Clients
{
    internal interface IFooteballApi
    {
        /// <summary>
        /// Busca todas as seasons.
        /// </summary>
        [Get("/v3/leagues/seasons")]
        Task<SeasonsGetResult> GetAllSeasons();

        /// <summary>
        /// Busca todas as seasons.
        /// </summary>
        [Get("/v3/countries")]
        Task<CountriesGetResult> GetAllCountries();

        /// <summary>
        /// Busca todas as seasons.
        /// </summary>
        [Get("/v3/leagues")]
        Task<SeasonLeaguesGetResult> GetAllLeaguesBySeason(
            [Query] SeasonLeaguesGet seasonLeaguesGet);
    }
}
