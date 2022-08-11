using AutoMapper;
using TestAspWebApi.DTOs.Actors;
using TestAspWebApi.DTOs.Genres;
using TestAspWebApi.Entities;

namespace TestAspWebApi.Helpers
{
    public class AutomapperProfilesHelper : Profile
    {
        public AutomapperProfilesHelper()
        {
            CreateMap<GenreEntity, GenreDTO>().ReverseMap();
            CreateMap<GenreCreateNewDTO, GenreEntity>();
            CreateMap<ActorEntity, ActorDTO>().ReverseMap();
            CreateMap<ActorCreateNewDTO, ActorEntity>();
        }
    }
}
