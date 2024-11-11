using Library.Models;
using Library.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _dbContext;
        public BookRepository(LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Book> CreateBookAsync(Book book)
        {
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            book =  _dbContext.Books.OrderByDescending(book => book.Id).FirstOrDefault();
            return book;
        }

        public async Task<int> DeleteBookAsync(int id)
        {

            Book book = await GetBookAsync(id);
            if (book == null)
            {
                return -1;
            }
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
            return 1;
        }

        public async Task<Book> GetBookAsync(int id)
        {
            
            Book book = await _dbContext.Books.FindAsync(id);
            if (book == null)
            {
                return null;
            }    
            return book;
        }

        public async Task<IList<Book>> GetBooksAsync()
        {
            IList<Book> books= await _dbContext.Books.ToListAsync();
            return books;

        }

        public async Task<Book> UpdateBookAsync(int id, Book editedBook)
        {
            
            Book book = await GetBookAsync(id);
            if (book == null)
            {
                return null;
            }
            if (editedBook.BookAuthorId != 0)
            {
                book.BookAuthorId = editedBook.BookAuthorId;

            }
            if (editedBook.GenreId != 0)
            {
                book.GenreId = editedBook.GenreId;

            }

            if (!string.IsNullOrEmpty(editedBook.BookName))
            {
                book.BookName = editedBook.BookName;
            }
            await _dbContext.SaveChangesAsync();
            return book;

        }
       
    }
}
