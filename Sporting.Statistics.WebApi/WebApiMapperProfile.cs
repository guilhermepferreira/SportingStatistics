using AutoMapper;
using Sporting.Statistics.Domain.Models;
using Sporting.Statistics.WebApi.Clients;

namespace Sporting.Statistics.WebApi
{
    public class WebApiMapperProfile : Profile
    {
        public WebApiMapperProfile()
        {
            CreateMap<SeasonsGetResult, Seasons>().ReverseMap();
            CreateMap<SeasonDto,Season>().ReverseMap();
        }
    }
}
