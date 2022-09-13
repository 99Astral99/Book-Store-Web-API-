using BookStore.Application.Common.Exceptions;
using BookStore.Application.Interfaces;
using BookStore.Domain;
using MediatR;

namespace BookStore.Application.BookStore.Commands.DeleteBook
{
    public class DeleteNoteCommandHandler
       : IRequestHandler<DeleteBookCommand>
    {
        private readonly IBookStoreDbContext _dbContext;

        public DeleteNoteCommandHandler(IBookStoreDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteBookCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Books
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            _dbContext.Books.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
