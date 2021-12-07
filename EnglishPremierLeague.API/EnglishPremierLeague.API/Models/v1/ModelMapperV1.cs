using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishPremierLeague.API.Models.v1
{
    public class ModelMapperV1 : Profile
    {
        public ModelMapperV1()
        {
            CreateMap<Domain.Entities.Team, Response.TeamsResponse>();
            CreateMap<Domain.Entities.Team, Response.TeamResponse>();
            CreateMap<Domain.Entities.Player, Response.PlayerResponse>()
                .ForMember(dest => dest.CountryOfOrigin, src => src.MapFrom(x => x.Origin.CountryName));
            CreateMap<Domain.Entities.Country, Response.CountriesResponse>();

            CreateMap<Request.TeamRequest, Domain.Entities.Team>();
            CreateMap<Request.PlayerRequest, Domain.Entities.Player>()
                .ForPath(dest => dest.Origin.CountryName, src => src.MapFrom(x => x.CountryName))
                .ForPath(dest => dest.Team.TeamName, src => src.MapFrom(x => x.Team));

        }
    }
}
