using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookStore.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.BookStore.Queries.GetBookList
{
    public class GetBookListQueryHandler
        : IRequestHandler<GetBookListQuery, BookListVm>
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBookListQueryHandler(IBookStoreDbContext dbContext, 
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<BookListVm> Handle(GetBookListQuery request,
            CancellationToken cancellationToken)
        {
            var notesQuery = await _dbContext.Books
                //.Where(book => book.Id == request.Id)
                .ProjectTo<BookLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new BookListVm { Books = notesQuery };
        }
    }
}
