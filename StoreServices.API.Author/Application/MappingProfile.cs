using AutoMapper;

namespace StoreServices.API.Author.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Author, AuthorDto>();
        }
    }
}
