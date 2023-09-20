using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.API.ShoppingCart.Persistency;

namespace StoreServices.API.ShoppingCart.Application
{
    public class GetAllShoppingCarts
    {
        public class GetAllShoppingCartsRequest : IRequest<List<ShoppingCartDto>>
        {
        }

        public class Handler : IRequestHandler<GetAllShoppingCartsRequest, List<ShoppingCartDto>>
        {
            private readonly ShoppingCartContext _shoppingCartContext;
            private readonly IMapper _mapper;

            public Handler(ShoppingCartContext shoppingCartContext, IMapper mapper)
            {
                _shoppingCartContext = shoppingCartContext;
                _mapper = mapper;
            }

            public async Task<List<ShoppingCartDto>> Handle(GetAllShoppingCartsRequest request, CancellationToken cancellationToken)
            {
                var shoppingCartList = await _shoppingCartContext.ShoppingCart.ToListAsync();
                var shoppingCartDtoList = _mapper.Map<List<ShoppingCartDto>>(shoppingCartList);
                return shoppingCartDtoList;
            }
        }
    }
}
