using Library.IBookAuthorRepoistory.cs;
using Library.Models;
using Library.Services.Common;

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
        public async Task<int> PostBookAuthorAsync(BookAuthor bookAuthor)
        {
            return await _repository.PostBookAuthorAsync(bookAuthor);
        }


    }
}
