using MediatR;

namespace BookStore.Application.BookStore.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest
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
