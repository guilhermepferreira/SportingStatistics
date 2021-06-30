﻿using AutoMapper;
using Sporting.Statistics.Domain.Adapters;
using Sporting.Statistics.Domain.Models;
using Sporting.Statistics.FooteballApiAdapter.Clients;
using System;
using System.Threading.Tasks;

namespace Sporting.Statistics.FooteballApiAdapter
{
    internal class SportingStatisticsFooteballApiAdapter : ISportingStatisticsFooteballApiAdapter
    {
        private readonly IFooteballApi footeballApi;
        private readonly IMapper mapper;

        public SportingStatisticsFooteballApiAdapter(IFooteballApi footeballApi, IMapper mapper) 
        {
            this.footeballApi = footeballApi ??
                    throw new ArgumentNullException(nameof(footeballApi));
            
            this.mapper = mapper ??
                    throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<LeaguesResult> BuscarLeagueBySeason(Season season)
        {
            try
            {
                var seasonLeaguesGet = mapper.Map<SeasonLeaguesGet>(season);

                var seasonsGetResult = await footeballApi
                    .GetAllLeaguesBySeason(seasonLeaguesGet);

                var seasonsResult = mapper.Map<LeaguesResult>(seasonsGetResult);

                return seasonsResult;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<SeasonsResult> BuscarSeasons()
        {
            try
            {
                var seasonsGetResult = await footeballApi.GetAllSeasons();

                var seasonsResult = mapper.Map<SeasonsResult>(seasonsGetResult);

                return seasonsResult;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}