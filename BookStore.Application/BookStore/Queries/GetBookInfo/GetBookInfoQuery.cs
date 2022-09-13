using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.BookStore.Queries.GetBookInfo
{
    public class GetBookInfoQuery:IRequest<BookInfoVm>
    {
        public int Id { get; set; }
    }
}
