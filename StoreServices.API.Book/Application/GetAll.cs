using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.API.Book.Persistency;

namespace StoreServices.API.Book.Application
{
    public class GetAll
    {
        public class GetAllBooksRequest : IRequest<List<BookDto>> { }

        public class Handler : IRequestHandler<GetAllBooksRequest, List<BookDto>>
        {
            private readonly BookContext _context;
            private readonly IMapper _mapper;

            public Handler(BookContext context, IMapper mapper)
            {
                if (context is null) throw new ArgumentNullException(nameof(context));
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<BookDto>> Handle(GetAllBooksRequest request, CancellationToken cancellationToken)
            {
                List<Models.Book>? books = await _context.Books.ToListAsync(cancellationToken);
                if (books is null) throw new Exception("Error getting books");
                return _mapper.Map<List<Models.Book>, List<BookDto>>(books);
            }
        }   
    }
}
