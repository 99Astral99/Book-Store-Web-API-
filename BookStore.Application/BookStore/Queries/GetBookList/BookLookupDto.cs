using AutoMapper;
using BookStore.Application.BookStore.Queries.GetBookInfo;
using BookStore.Application.Common.Mappings;
using BookStore.Domain;

namespace BookStore.Application.BookStore.Queries.GetBookList
{
    public class BookLookupDto : IMapWith<Book>
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }
        public string? CreationYear { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookLookupDto>();
        }


    }
}
