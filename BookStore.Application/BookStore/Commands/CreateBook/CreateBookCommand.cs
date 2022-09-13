using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.BookStore.Commands.CreateBook
{
    public class CreateBookCommand:IRequest<int>
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string? CreationYear { get; set; }

    }
}
