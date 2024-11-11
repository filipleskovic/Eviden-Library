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
        public async Task<BookAuthor> CreateBookAuthorAsync(BookAuthor bookAuthor)
        {
            if (BookAuthorValidator.IsValid(bookAuthor))
            {
                return await _repository.CreateBookAuthorAsync(bookAuthor);
            }
            return null;
        }
        public async Task<BookAuthor> UpdateBookAuthorAsync(int id,BookAuthor editedBookAuthor)
        {
            if (BookAuthorValidator.IsValid(editedBookAuthor))
            {
                return await _repository.UpdateBookAuthorAsync(id, editedBookAuthor);
            }
            return null;
        }
        public async Task<int> DeleteBookAuthorAsync(int Id)
        {
            return await _repository.DeleteBookAuthorAsync(Id);
        }



    }
}
