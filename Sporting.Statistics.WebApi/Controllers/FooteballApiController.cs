using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Otc.AspNetCore.ApiBoot;
using Otc.DomainBase.Exceptions;
using Sporting.Statistics.Domain.Models;
using Sporting.Statistics.Domain.Service;
using Sporting.Statistics.WebApi.Clients;

namespace Sporting.Statistics.WebApi.Controllers
{
    [ApiVersion("1.0")]
    public class FooteballApiController : ApiController
    {
        private readonly IMapper mapper;
        private readonly ISportingStatisticsServices sportingStatisticsServices;
        public FooteballApiController(IMapper mapper,
            ISportingStatisticsServices sportingStatisticsServices)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.sportingStatisticsServices = sportingStatisticsServices ??
                throw new ArgumentNullException(nameof(sportingStatisticsServices));
        }

        /// <summary>
        ///    Busca todas as seasons.
        /// </summary>
        /// <response code="200">
        ///    Seasons retornadas.
        /// </response>
        /// <response code="400">
        ///     Parametros incorretos ou limite de utilização excedido.
        /// </response>
        /// <response code="500">
        ///     Erro interno.
        /// </response>
        [HttpGet("Seasons"), AllowAnonymous]
        [ProducesResponseType(typeof(SeasonsGetResult), 200)]
        [ProducesResponseType(typeof(CoreException<CoreError>), 400)]
        [ProducesResponseType(typeof(InternalError), 500)]
        public async Task<IActionResult> GetAllSeasons()
        {


            var seasonsResult = await sportingStatisticsServices.GetAllSeason();

            var seasons = mapper.Map<SeasonsGetResult>(seasonsResult);

            return Ok(seasons);
        }

        /// <summary>
        ///    Busca todas as seasons.
        /// </summary>
        /// <response code="200">
        ///    Seasons retornadas.
        /// </response>
        /// <response code="400">
        ///     Parametros incorretos ou limite de utilização excedido.
        /// </response>
        /// <response code="500">
        ///     Erro interno.
        /// </response>
        [HttpGet("Leagues"), AllowAnonymous]
        [ProducesResponseType(typeof(SeasonsGetResult), 200)]
        [ProducesResponseType(typeof(CoreException<CoreError>), 400)]
        [ProducesResponseType(typeof(InternalError), 500)]
        public async Task GetAllLeaguesBySeason()
        {
            await sportingStatisticsServices
            .GetAllLeaguesBySeason();
        }

        /// <summary>
        ///    Busca todas as seasons.
        /// </summary>
        /// <response code="200">
        ///    Seasons retornadas.
        /// </response>
        /// <response code="400">
        ///     Parametros incorretos ou limite de utilização excedido.
        /// </response>
        /// <response code="500">
        ///     Erro interno.
        /// </response>
        [HttpGet("Countries"), AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<Country>), 200)]
        [ProducesResponseType(typeof(CoreException<CoreError>), 400)]
        [ProducesResponseType(typeof(InternalError), 500)]
        public async Task<IActionResult> GetAllCountries()
        {
            var countries = await sportingStatisticsServices.GetAllCountry();
            return Ok(countries);
        }

        /// <summary>
        ///    Busca todas as seasons.
        /// </summary>
        /// <response code="200">
        ///    Seasons retornadas.
        /// </response>
        /// <response code="400">
        ///     Parametros incorretos ou limite de utilização excedido.
        /// </response>
        /// <response code="500">
        ///     Erro interno.
        /// </response>
        [HttpGet("Teams"), AllowAnonymous]
        [ProducesResponseType(typeof(SeasonsGetResult), 200)]
        [ProducesResponseType(typeof(CoreException<CoreError>), 400)]
        [ProducesResponseType(typeof(InternalError), 500)]
        public async Task GetAllTeamsByLeagueSeason()
        {
            await sportingStatisticsServices
            .GetAllTeamsByLeagueSeason();
        }
    }
}
