using BookStore.Application.Common.Exceptions;
using BookStore.Application.Interfaces;
using BookStore.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.BookStore.Commands.UpdateBook
{
    public class UpdateNoteCommandHandler
            : IRequestHandler<UpdateBookCommand>
    {
        private readonly IBookStoreDbContext _dbContext;

        public UpdateNoteCommandHandler(IBookStoreDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateBookCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Books.FirstOrDefaultAsync(book =>
                    book.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            entity.Title = request.Title;
            entity.Genre = request.Genre;
            entity.Author = request.Author;
            entity.Price = request.Price;
            entity.Amount = request.Amount;
            entity.CreationYear = request.CreationYear;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
