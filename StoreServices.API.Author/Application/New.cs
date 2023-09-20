using FluentValidation;
using MediatR;
using StoreServices.API.Author.Persistency;

namespace StoreServices.API.Author.Application
{
    public class New
    {
        public class CreateAuthorRequest : IRequest
        {
            public required string Name { get; set; }
            public required string LastName { get; set; }
            public DateTime? BirthDate { get; set; }
        }

        public class CreateAuthorRequestValidation : AbstractValidator<CreateAuthorRequest>
        {
            public CreateAuthorRequestValidation()
            {
                RuleFor(a => a.Name).NotEmpty();
                RuleFor(a => a.LastName).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<CreateAuthorRequest>
        {
            public readonly AuthorContext _context;

            public Handler(AuthorContext context)
            {
                if (context is null) throw new ArgumentNullException(nameof(context));
                _context = context;
            }

            public async Task<Unit> Handle(CreateAuthorRequest request, CancellationToken cancellationToken)
            {
                _context.Authors?.Add(new Models.Author
                {
                    ID = Guid.NewGuid(),
                    Name = request.Name,
                    LastName = request.LastName,
                    BirthDate = request.BirthDate
                });

                var commitedTransactions = await _context.SaveChangesAsync(cancellationToken);

                if (commitedTransactions > 0) return Unit.Value;

                throw new Exception("Error saving author");
            }
        }
    }
}
