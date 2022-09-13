using AutoMapper;
using BookStore.Application.Common.Mappings;
using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.BookStore.Queries.GetBookInfo
{
    public class BookInfoVm: IMapWith<Book>
    {
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }
        public string? CreationYear { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookInfoVm>();
        }
    }
}
