using Library.IBookAuthorRepoistory.cs;
using Library.Models;
using Library.Services.Common;
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
        public async Task<int> PostBookAuthorAsync(BookAuthor bookAuthor)
        {
            return await _repository.PostBookAuthorAsync(bookAuthor);
        }
        public async Task<BookAuthor> PutBookAuthorAsync(int Id,BookAuthor bookAuthor)
        {
            return await _repository.PutBookAuthorAsync(Id,bookAuthor);
        }
        public async Task<int> DeleteBookAuthorAsync(int Id)
        {
            return await _repository.DeleteBookAuthorAsync(Id);
        }



    }
}
