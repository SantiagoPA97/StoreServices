using FluentValidation;
using MediatR;
using StoreServices.API.Book.Persistency;

namespace StoreServices.API.Book.Application
{
    public class New
    {
        public class CreateBookRequest : IRequest
        {
            public required string Title { get; set; }
            public DateTime? PublicationDate { get; set; }
            public Guid AuthorID { get; set; }
        }
          
        public class CreateBookRequestValidation : AbstractValidator<CreateBookRequest>
        {
            public CreateBookRequestValidation()
            {
                RuleFor(a => a.Title).NotEmpty();
                RuleFor(a => a.PublicationDate).NotEmpty();
                RuleFor(a => a.AuthorID).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<CreateBookRequest>
        {
            private readonly BookContext _context;
            public Handler(BookContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CreateBookRequest request, CancellationToken cancellationToken)
            {
                var book = new Models.Book
                {
                    Title = request.Title,
                    PublicationDate = request.PublicationDate,
                    AuthorID = request.AuthorID
                };

                await _context.Books.AddAsync(book);
                var result = await _context.SaveChangesAsync();

                if(result > 0) return Unit.Value;

                throw new Exception("Error creating the book");
            }
        }
    }
}
