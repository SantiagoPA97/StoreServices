using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.API.Author.Persistency;

namespace StoreServices.API.Author.Application
{
    public class GetAuthorById
    {
        public class GetAuthorByIdRequest : IRequest<AuthorDto>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<GetAuthorByIdRequest, AuthorDto>
        {
            private readonly AuthorContext _context;
            private readonly IMapper _mapper;

            public Handler(AuthorContext context, IMapper mapper)
            {
                if (context is null) throw new ArgumentNullException(nameof(context));
                _context = context;
                _mapper = mapper;
            }

            public async Task<AuthorDto> Handle(GetAuthorByIdRequest request, CancellationToken cancellationToken)
            {
                Models.Author? author = await _context.Authors.FirstOrDefaultAsync(a => a.ID == request.Id, cancellationToken);
                if (author is null) throw new Exception("Author not found");
                return _mapper.Map<Models.Author, AuthorDto>(author);
            }
        }
    }
}
