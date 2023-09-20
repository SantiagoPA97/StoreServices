using AutoMapper;

namespace StoreServices.API.ShoppingCart.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.ShoppingCart, ShoppingCartDto>();
        }
    }
}
