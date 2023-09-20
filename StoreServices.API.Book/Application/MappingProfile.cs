using AutoMapper;

namespace StoreServices.API.Book.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Book, BookDto>();
        }
    }
}
