using AutoMapper;
using Sporting.Statistics.FooteballApiAdapter.Clients;
using Sporting.Statistics.Domain.Models;
using System.Linq;
using System.Collections.Generic;

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

            CreateMap<VenueDto, Venue>()
                .ForMember(a => a.Capacidade, o => o.MapFrom(s => s.Capacity))
                .ForMember(a => a.Cidade, o => o.MapFrom(s => s.City))
                .ForMember(a => a.Endereco, o => o.MapFrom(s => s.Address))
                .ForMember(a => a.IdFornecedor, o => o.MapFrom(s => s.Id))
                .ForMember(a => a.Imagem, o => o.MapFrom(s => s.Image))
                .ForMember(a => a.Nome, o => o.MapFrom(s => s.Name));

            CreateMap<TeamDto, Team>()
                .ForMember(a => a.IdFornecedor, o => o.MapFrom(s => s.Id))
                .ForMember(a => a.Fundado, o => o.MapFrom(s => s.Founded))
                .ForMember(a => a.Pais, o => o.MapFrom(s => s.Country))
                .ForMember(a => a.Nacional, o => o.MapFrom(s => s.National))
                .ForMember(a => a.Nome, o => o.MapFrom(s => s.Name))
                .ForMember(a => a.Logo, o => o.MapFrom(s => s.Logo));

            CreateMap<TeamsResultDto, TeamResult>()
                .ForMember(a => a.Estadio, o => o.MapFrom(s => s.Venue))
                .ForMember(a => a.Time, o => o.MapFrom(s => s.Team));
                
            CreateMap<TeamsGetResult, Teams>()
                .ForMember(a => a.Times, o => o.MapFrom(s => s.Response));
                
        }
    }
}
