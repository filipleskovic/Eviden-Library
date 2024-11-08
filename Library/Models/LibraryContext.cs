using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
    public class LibraryContext:DbContext
    {
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book>Books { get; set; }

        public LibraryContext(DbContextOptions options):base(options) { }    
    }
}
