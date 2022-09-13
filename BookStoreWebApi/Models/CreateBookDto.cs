using AutoMapper;
using BookStore.Application.BookStore.Commands.CreateBook;
using BookStore.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWebApi.Models
{
    public class CreateBookDto:IMapWith<CreateBookCommand>
    {
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string? CreationYear { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBookDto, CreateBookCommand>();
        }
    }
}
