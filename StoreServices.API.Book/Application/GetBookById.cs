using AutoMapper;
using MediatR;
using StoreServices.API.Book.Persistency;

namespace StoreServices.API.Book.Application
{
    public class GetBookById
    {
        public class GetBookByIdRequest : IRequest<BookDto>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<GetBookByIdRequest, BookDto>
        {
            private readonly BookContext _context;
            private readonly IMapper _mapper;

            public Handler(BookContext context, IMapper mapper)
            {
                if (context is null) throw new ArgumentNullException(nameof(context));
                _context = context;
                _mapper = mapper;
            }

            public async Task<BookDto> Handle(GetBookByIdRequest request, CancellationToken cancellationToken)
            {
                Models.Book? book = await _context.Books.FindAsync(request.Id);
                if (book is null) throw new Exception("Error getting book");
                return _mapper.Map<Models.Book, BookDto>(book);
            }
        }
    }
}
