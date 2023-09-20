using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreServices.API.ShoppingCart.Application;

namespace StoreServices.API.ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ShoppingCartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> New(New.CreateShoppingCartRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet]
        public async Task<ActionResult<List<ShoppingCartDto>>> GetAllShoppingCarts()
        {
            return await _mediator.Send(new GetAllShoppingCarts.GetAllShoppingCartsRequest());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingCartDto>> GetShoppingCartById(Guid id)
        {
            return await _mediator.Send(new GetShoppingCartById.GetShoppingCartByIdRequest { Id = id });
        }
    }
} 
