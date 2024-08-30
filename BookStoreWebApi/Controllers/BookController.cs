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
	[ApiController]
	[Authorize]
	[Route("api/[controller]")]
	public class BookController : BaseController
	{
		private readonly IMapper _mapper;
		public BookController(IMapper mapper) =>
			_mapper = mapper;


		[HttpGet]
		public async Task<ActionResult<BookListVm>> GetAll()
		{
			var query = new GetBookListQuery();
			var vm = await Mediator.Send(query);
			_logger.LogInformation($"GetAll book");
			_logger.LogInformation($"GetAll book");
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

