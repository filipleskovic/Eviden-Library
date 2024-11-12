using Library.IBookAuthorRepoistory.cs;
using Library.Models;
using Library.Services.Common;
using Library.Validators;
using Microsoft.AspNetCore.DataProtection;

namespace Library.Services
{
    public class BookAuthorService:IBookAuthorService
    {
        private IBookAuthorRepository _repository;
        public BookAuthorService(IBookAuthorRepository repository)
        {
            _repository = repository;
        }
        public async Task<IList<BookAuthor>> GetBookAuthorsAsync()
        {
            return await _repository.GetBookAuthorsAsync();
        }
        public async Task<BookAuthor>GetBookAuthorAsync(int Id)
        {
            return await _repository.GetBookAuthorAsync(Id);
        }
        public async Task<BookAuthorValidator> CreateBookAuthorAsync(BookAuthor bookAuthor)
        {
            BookAuthorValidator bookAuthorValidator = new BookAuthorValidator(true);
            if (bookAuthorValidator.IsValid(bookAuthor))
            {
                BookAuthor addedBookAuthor =await _repository.CreateBookAuthorAsync(bookAuthor);
                bookAuthorValidator.BookAuthor = bookAuthor;
            }
            return bookAuthorValidator;
        }
        public async Task<BookAuthorValidator> UpdateBookAuthorAsync(int id,BookAuthor editedBookAuthor)
        {
            BookAuthorValidator bookAuthorValidator = new BookAuthorValidator(false);
            if( await GetBookAuthorAsync(id) == null)
            {
                bookAuthorValidator.BookAuthor = null;
                bookAuthorValidator.Message = $"Author with Id : {id} not found ";
                return bookAuthorValidator;
            }
            if (bookAuthorValidator.IsValid(editedBookAuthor))
            {
                BookAuthor bookAuthor = await _repository.UpdateBookAuthorAsync(id, editedBookAuthor);
                bookAuthorValidator.BookAuthor = bookAuthor;
            }
            return bookAuthorValidator;
        }
        public async Task<int> DeleteBookAuthorAsync(int Id)
        {
            return await _repository.DeleteBookAuthorAsync(Id);
        }



    }
}
