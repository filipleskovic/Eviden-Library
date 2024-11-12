using Library.Models;
using Library.Validators;

namespace Library.Services.Common
{
    public interface IBookAuthorService
    {
        Task<IList<BookAuthor>> GetBookAuthorsAsync();
        Task<BookAuthor> GetBookAuthorAsync(int Id);
        Task<BookAuthorValidator> UpdateBookAuthorAsync(int Id, BookAuthor bookAuthor);
        
        Task<BookAuthorValidator> CreateBookAuthorAsync(BookAuthor bookAuthor);
        Task<int> DeleteBookAuthorAsync(int Id);
    }
}
