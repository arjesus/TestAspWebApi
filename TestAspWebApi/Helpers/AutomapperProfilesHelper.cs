using AutoMapper;
using TestAspWebApi.DTOs;
using TestAspWebApi.Entities;

namespace TestAspWebApi.Helpers
{
    public class AutomapperProfilesHelper : Profile
    {
        public AutomapperProfilesHelper()
        {
            CreateMap<GenreEntity, GenreDTO>().ReverseMap();
            CreateMap<GenreCreateNewDTO, GenreEntity>();
        }
    }
}
