using MediatR;
using StoreServices.API.ShoppingCart.Persistency;

namespace StoreServices.API.ShoppingCart.Application
{
    public class New
    {
        public class CreateShoppingCartRequest  : IRequest
        {
            public List<Guid> Items { get; set; } = new List<Guid>();
        }

        public class Handler : IRequestHandler<CreateShoppingCartRequest>
        {
            private readonly ShoppingCartContext _context;
            public Handler(ShoppingCartContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CreateShoppingCartRequest request, CancellationToken cancellationToken)
            {
                var shoppingCart = new Models.ShoppingCart
                {
                    CreatedDate = DateTime.Now,  
                };

                await _context.ShoppingCart.AddAsync(shoppingCart);
                var result = await _context.SaveChangesAsync();

                if (result == 0) throw new Exception("Error creating the shopping cart");

                foreach (var item in request.Items)
                {
                    var shoppingCartItem = new Models.ShoppingCartDetails
                    {
                        Product = item,
                        CreatedDate = DateTime.Now,
                        ShoppingCartID = shoppingCart.ID
                    };

                    await _context.ShoppingCartDetails.AddAsync(shoppingCartItem);
                }

                result = await _context.SaveChangesAsync();
                if(result > 0) return Unit.Value;

                throw new Exception("Error creating the shopping cart detail");
            }
        }
    }
}
