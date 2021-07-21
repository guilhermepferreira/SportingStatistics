﻿using AutoMapper;
using Sporting.Statistics.FooteballApiAdapter.Clients;
using Sporting.Statistics.Domain.Models;
using System.Linq;

namespace Sporting.Statistics.FooteballApiAdapter
{
    public class SportingStatisticsFooteballApiMapperProfile : Profile
    {
        public SportingStatisticsFooteballApiMapperProfile()
        {
            CreateMap<SeasonsGetResult,SeasonsResult>();
            CreateMap<Season, SeasonLeaguesGet>().ForMember(a => a.season, o => o.MapFrom(s => s.Ano));
            CreateMap<SeasonLeaguesGetResult, LeaguesResult>();
            CreateMap<CountryDto, Country>().ReverseMap();
            CreateMap<CoverageDto, Coverage>().ReverseMap();
            CreateMap<FixturesDto, Fixtures>().ReverseMap();
            CreateMap<LeagueInfoDto, LeagueInfo>()
                .ForPath(a => a.TipoLiga.Tipo, o => o.MapFrom(s => s.TipoLiga))
                .ReverseMap();
            CreateMap<LeagueDto, League>().ReverseMap();
            CreateMap<LeagueSeasonsDto, LeagueSeasons>().ReverseMap();
            CreateMap<CountriesGetResult, CountryResult>()
             .ForMember(a => a.Countries, o => o.MapFrom(s => s.Response));
            CreateMap<League, TeamLeagueSeasonGet>()
                .ForMember(a => a.league, o => o.MapFrom(s => s.Liga.IdentificadorLiga))
                .ForMember(a => a.season, o => o.MapFrom(s => s.Seasons.FirstOrDefault().Ano));

        }
    }
}
