using AutoMapper;
using BookStore.Application.BookStore.Commands.UpdateBook;
using BookStore.Application.Common.Mappings;

namespace BookStoreWebApi.Models
{
	public class UpdateBookDto : IMapWith<UpdateBookCommand>
	{
		public int Id { get; set; }
		public string? Title { get; set; }
		public string? Genre { get; set; }
		public string? Author { get; set; }
		public decimal Price { get; set; }
		public int Amount { get; set; }
		public string? CreationYear { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<UpdateBookDto, UpdateBookCommand>();
		}
	}
}
