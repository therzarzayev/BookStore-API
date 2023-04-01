using BookStore_v2.Models;

namespace BookStore_v2.Repositories
{
	public interface IBookStoreRepository
	{
		Book GetById(int id);
		List<Book> GetAllBook();
		bool CreateBook(Book book);
		bool UpdateBook(int id, Book book);
		bool DeleteBook(int id);

	}
}
