using BookStore_v2.Models;

namespace BookStore_v2.Repositories
{
	public class BookStoreRepository:IBookStoreRepository
	{
		private readonly BookStoreDBContext _dbContext;
		public BookStoreRepository(BookStoreDBContext dBContext)
		{
			_dbContext = dBContext;
		}
		public bool CreateBook(Book book)
		{
			var _book = _dbContext.Books.FirstOrDefault(x => x.Title == book.Title);
			if (_book != null)
			{
				return false;
			}
			_dbContext.Books.Add(book);
			_dbContext.SaveChanges();
			return true;
		}

		public bool DeleteBook(int id)
		{
			var book = GetById(id);
			if (book is null)
				return false;
			_dbContext.Books.Remove(book);
			_dbContext.SaveChanges();
			return true;
		}

		public List<Book> GetAllBook()
		{
			return _dbContext.Books.ToList();
		}

		public Book GetById(int id)
		{
			return _dbContext.Books.FirstOrDefault(x => x.Id == id);
		}

		public bool UpdateBook(int id, Book book)
		{
			var _book = GetById(id);
			if (_book is null)
				return false;
			_book.Title = book.Title != default ? book.Title : _book.Title;
			_book.Author = book.Author != default ? book.Author : _book.Author;
			_book.Description = book.Description != default ? book.Description : _book.Description;
			_dbContext.SaveChanges();
			_book.PublishDate = book.PublishDate != default ? book.PublishDate : _book.PublishDate;
			return true;
		}
	}
}
