using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreServices.API.Book.Application;

namespace StoreServices.API.Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Unit>> CreateBook([FromBody] New.CreateBookRequest payload)
        {
            return await _mediator.Send(payload);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<BookDto>>> GetAllBooks()
        {
            return await _mediator.Send(new GetAll.GetAllBooksRequest());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BookDto>> GetBookById(Guid id)
        {
            return await _mediator.Send(new GetBookById.GetBookByIdRequest { Id = id });
        }
    }
}
