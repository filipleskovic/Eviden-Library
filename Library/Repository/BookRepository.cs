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
            if (_dbContext == null)
            {
                return null;
            }
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            book =  _dbContext.Books.OrderByDescending(book => book.Id).FirstOrDefault();
            book.BookAuthor = await _dbContext.BookAuthors.FindAsync(book.BookAuthorId);
            book.Genre=await _dbContext.Genres.FindAsync(book.GenreId);
            return book;
        }

        public async Task<int> DeleteBookAsync(int id)
        {
            if (_dbContext == null)
            {
                return 0;
            }
            Book book = await _dbContext.Books.FindAsync(id);
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
            if (_dbContext == null)
            {
                return null;
            }
            Book book = await _dbContext.Books.FindAsync(id);
            book.BookAuthor = await _dbContext.BookAuthors.FindAsync(book.BookAuthorId);
            book.Genre = await _dbContext.Genres.FindAsync(book.GenreId);
            return book;
        }

        public async Task<IList<Book>> GetBooksAsync()
        {
            if (_dbContext == null)
            {
                return null;
            }

            IList<Book> books= await _dbContext.Books.ToListAsync();
            foreach(Book book in books)
            {
                book.BookAuthor=await _dbContext.BookAuthors.FindAsync(book.BookAuthorId);
                book.Genre= await _dbContext.Genres.FindAsync(book.GenreId);
            }
            return books;

        }

        public async Task<Book> UpdateBookAsync(int id, Book editedBook)
        {
            if (_dbContext == null)
            {
                return null;
            }
            Book book = await GetBookAsync(id);
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
            book.Genre = await _dbContext.Genres.FindAsync(book.GenreId);
            book.BookAuthor = await _dbContext.BookAuthors.FindAsync(book.BookAuthorId);
            return book;

        }
       
    }
}
