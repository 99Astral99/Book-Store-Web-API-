using AutoMapper;
using BookStore.Application.BookStore.Commands.CreateBook;
using BookStore.Application.BookStore.Commands.DeleteBook;
using BookStore.Application.BookStore.Commands.UpdateBook;
using BookStore.Application.BookStore.Queries.GetBookInfo;
using BookStore.Application.BookStore.Queries.GetBookList;
using BookStoreWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	public class BookStoreController : BaseController
	{
		private readonly IMapper _mapper;
		public BookStoreController(IMapper mapper) =>
			_mapper = mapper;

		[Authorize]
		[HttpGet]
		public async Task<ActionResult<BookListVm>> GetAll()
		{
			var query = new GetBookListQuery();
			var vm = await Mediator.Send(query);
			return Ok(vm);
		}
	
		[HttpGet("{id}")]
		public async Task<ActionResult<BookInfoVm>> Get(int id)
		{
			var query = new GetBookInfoQuery()
			{
				Id = id
			};

			var vm = await Mediator.Send(query);
			return Ok(vm);
		}

		[HttpPost]
		public async Task<ActionResult<int>> Create([FromBody] CreateBookDto createBookDto)
		{
			var command = _mapper.Map<CreateBookCommand>(createBookDto);
			var bookId = await Mediator.Send(command);

			return Ok(bookId);
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody] UpdateBookDto updateBookDto)
		{
			var command = _mapper.Map<UpdateBookCommand>(updateBookDto);
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete(int id)
		{
			var command = new DeleteBookCommand()
			{
				Id = id
			};

			await Mediator.Send(command);

			return NoContent();
		}
	}
}

