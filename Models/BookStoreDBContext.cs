using Microsoft.EntityFrameworkCore;

namespace BookStore_v2.Models
{
	public class BookStoreDBContext: DbContext
	{
		public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options) : base(options) { }

		public DbSet<Book> Books { get; set; }
	}
}
