using AutoMapper;
using Sporting.Statistics.FooteballApiAdapter.Clients;
using Sporting.Statistics.Domain.Models;

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

        }
    }
}
