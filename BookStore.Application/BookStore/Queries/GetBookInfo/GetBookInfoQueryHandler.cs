using AutoMapper;
using BookStore.Application.Common.Exceptions;
using BookStore.Application.Interfaces;
using BookStore.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.BookStore.Queries.GetBookInfo
{
    public class GetBookInfoQueryHandler
        : IRequestHandler<GetBookInfoQuery, BookInfoVm>
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBookInfoQueryHandler(IBookStoreDbContext dbcontext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbcontext, mapper);
        public async Task<BookInfoVm> Handle(GetBookInfoQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Books
                 .FirstOrDefaultAsync(book =>
                    book.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            return _mapper.Map<BookInfoVm>(entity);
        }
    }
}
