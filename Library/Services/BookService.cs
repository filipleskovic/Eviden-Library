using Library.IBookAuthorRepoistory.cs;
using Library.Models;
using Library.Repository.Common;
using Library.Services.Common;
using Library.Validators;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private IBookRepository _repository;
        private IGenreRepository _genreRepository;
        private IBookAuthorRepository _bookAuthorRepository;
        public BookService(IBookRepository repository, IGenreRepository genreRepository, IBookAuthorRepository bookAuthorRepository)
        {
            _repository = repository;
            _genreRepository = genreRepository;
            _bookAuthorRepository = bookAuthorRepository;
        }
        public async Task<BookValidator> CreateBookAsync(Book book)
        {
            BookValidator bookValidator = new BookValidator(true);
            if (await bookValidator.IsValidAsync(book, _genreRepository, _bookAuthorRepository))
            { 
                Book newBook = await _repository.CreateBookAsync(book);
                newBook.BookAuthor = await _bookAuthorRepository.GetBookAuthorAsync(newBook.BookAuthorId);
                newBook.Genre = await _genreRepository.GetGenreAsync(newBook.GenreId);
                bookValidator.Book = newBook;
            }
            return bookValidator;
            
        }
        public async Task<int> DeleteBookAsync(int id)
        {
            return await _repository.DeleteBookAsync(id);
        }

        public async  Task<Book> GetBookAsync(int id)
        {
            Book book= await _repository.GetBookAsync(id);
            if(book== null)
            {
                return null;
            }
            book.BookAuthor = await _bookAuthorRepository.GetBookAuthorAsync(book.BookAuthorId);
            book.Genre = await _genreRepository.GetGenreAsync(book.GenreId);
            return book;
        }

        public async Task<IList<Book>> GetBooksAsync()
        {
            IList<Book> books = await _repository.GetBooksAsync();
            foreach (Book book in books)
            {
                book.BookAuthor = await _bookAuthorRepository.GetBookAuthorAsync(book.BookAuthorId);
                book.Genre = await _genreRepository.GetGenreAsync(book.GenreId);
            }
            return books;
        }

        public async Task<BookValidator> UpdateBookAsync(int id, Book editedBook)
        {
            BookValidator bookValidator = new BookValidator(false);
            if (! await bookValidator.IsValidAsync(editedBook, _genreRepository, _bookAuthorRepository))
            {
                return bookValidator;
            }

            Book book = await _repository.UpdateBookAsync(id, editedBook);
            if (book == null)
            {
                bookValidator.Message = $"Book with Id: {id} not found";
                return bookValidator;
            }
            book.Genre = await _genreRepository.GetGenreAsync(book.GenreId);
            book.BookAuthor = await _bookAuthorRepository.GetBookAuthorAsync(book.BookAuthorId);
            bookValidator.Book = book;
            return bookValidator;
        }
    }
}
