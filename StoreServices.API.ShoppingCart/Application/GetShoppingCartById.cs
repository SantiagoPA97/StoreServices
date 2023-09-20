using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.API.ShoppingCart.Interfaces;
using StoreServices.API.ShoppingCart.Persistency;

namespace StoreServices.API.ShoppingCart.Application
{
    public class GetShoppingCartById
    {
        public class GetShoppingCartByIdRequest : IRequest<ShoppingCartDto>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<GetShoppingCartByIdRequest, ShoppingCartDto>
        {
            private readonly ShoppingCartContext _context;
            private readonly IBooksService _booksService;
            private readonly IMapper _mapper;

            public Handler(ShoppingCartContext context, IMapper mapper, IBooksService booksService)
            {
                if (context is null) throw new ArgumentNullException(nameof(context));
                _context = context;
                _mapper = mapper;
                _booksService = booksService;
            }

            public async Task<ShoppingCartDto> Handle(GetShoppingCartByIdRequest request, CancellationToken cancellationToken)
            {
                Models.ShoppingCart? shoppingCart = await _context.ShoppingCart.FindAsync(request.Id);
                if (shoppingCart is null) throw new Exception("Error getting shopping cart");

                List<Models.ShoppingCartDetails>? shoppingCartDetails = await _context.ShoppingCartDetails.Where(x => x.ShoppingCartID == request.Id).ToListAsync();
                if(shoppingCartDetails is null) throw new Exception("Error getting shopping cart details");

                List<ShoppingCartDetailsDto> shoppingCartDetailDto = new List<ShoppingCartDetailsDto>();

                foreach (var item in shoppingCartDetails)
                {
                    var book = await _booksService.GetBook(item.Product);
                    if (book.result)
                    {
                        var bookDto = book.book;
                        var bookInShoppingCartDto = new ShoppingCartDetailsDto
                        {
                            BookId = bookDto.ID,
                            Author = bookDto.AuthorID,
                            Title = bookDto.Title,
                            PublishDate = bookDto.PublicationDate
                        };

                        shoppingCartDetailDto.Add(bookInShoppingCartDto);
                    }
                }

                var shoppingCartDto = _mapper.Map<Models.ShoppingCart, ShoppingCartDto>(shoppingCart);
                shoppingCartDto.Details = shoppingCartDetailDto;

                return shoppingCartDto;
            }
        }
    }
}
