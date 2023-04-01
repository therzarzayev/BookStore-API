using BookStore_v2.Models;
using BookStore_v2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_v2.Controllers
{
	[ApiController]
	[Route("[controller]s")]
	public class BookController : Controller
	{
		private readonly IBookStoreRepository _repository;
		public BookController(IBookStoreRepository repository)
		{
			_repository = repository;
		}


		[HttpGet]
		public List<Book> GetBooks()
		{
			var books = _repository.GetAllBook();
			return books;
		}

		[HttpGet("{id}")]
		public IActionResult GetBookById(int id)
		{
			var book = _repository.GetById(id);
			if (book == null)
				return NotFound();
			return Ok(book);
		}

		[HttpPost]
		public IActionResult AddBook([FromBody] Book newBook)
		{
			var book = _repository.CreateBook(newBook);
			if (!book)
				return BadRequest();
			return Ok();
		}

		[HttpPut("{id}")]
		public IActionResult UpdateBook(int id, [FromBody] Book updateBook)
		{
			var book = _repository.UpdateBook(id, updateBook);

			if (!book)
				return BadRequest();
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteBook(int id)
		{
			var book = _repository.DeleteBook(id);
			if (!book)
				return NotFound();
			return Ok();
		}
	}
}
