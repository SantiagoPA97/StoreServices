using Microsoft.EntityFrameworkCore;

namespace StoreServices.API.Book.Persistency
{
    public class BookContext :  DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
            
        }
        public DbSet<Models.Book> Books { get; set; }
    }
}
