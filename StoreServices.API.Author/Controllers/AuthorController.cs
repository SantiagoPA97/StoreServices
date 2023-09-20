using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreServices.API.Author.Application;
using static StoreServices.API.Author.Application.New;

namespace StoreServices.API.Author.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthorController(IMediator mediator)
        {
            if (mediator is null) throw new ArgumentNullException(nameof(mediator));
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateAuthor(CreateAuthorRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorDto>>> GetAuthors()
        {
            return await _mediator.Send(new GetAll.GetAllAuthorsRequest());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthorById(Guid id)
        {
            return await _mediator.Send(new GetAuthorById.GetAuthorByIdRequest { Id = id });
        }
    }
}
