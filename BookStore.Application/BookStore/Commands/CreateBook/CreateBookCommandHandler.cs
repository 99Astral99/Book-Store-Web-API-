using BookStore.Application.Interfaces;
using BookStore.Domain;
using MediatR;

namespace BookStore.Application.BookStore.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IBookStoreDbContext _dbContext;
        public CreateBookCommandHandler(IBookStoreDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateBookCommand request,
            CancellationToken cancellationToken)
        {
            var book = new Book()
            {
                Title = request.Title,
                Genre = request.Genre,
                Author = request.Author,
                Price = request.Price,
                Amount = request.Amount,
                CreationYear = request.CreationYear,
            };

            await _dbContext.Books.AddAsync(book, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return book.Id;
        }
    }
}
