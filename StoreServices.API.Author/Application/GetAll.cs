using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.API.Author.Persistency;

namespace StoreServices.API.Author.Application
{
    public class GetAll
    {
        public class GetAllAuthorsRequest : IRequest<List<AuthorDto>> { }

        public class Handler : IRequestHandler<GetAllAuthorsRequest, List<AuthorDto>>
        {
            private readonly AuthorContext _context;
            private readonly IMapper _mapper;

            public Handler(AuthorContext context, IMapper mapper)
            {
                if (context is null) throw new ArgumentNullException(nameof(context));
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<AuthorDto>> Handle(GetAllAuthorsRequest request, CancellationToken cancellationToken)
            {
                List<Models.Author>? authors = await _context.Authors.ToListAsync(cancellationToken);
                if (authors is null) throw new Exception("Error getting authors");
                return _mapper.Map<List<Models.Author>, List<AuthorDto>>(authors);
            }
        }
    }
}
