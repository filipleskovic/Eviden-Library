using Library.Models;

namespace Library.Services.Common
{
    public interface IBookAuthorService
    {
        Task<IList<BookAuthor>> GetBookAuthorsAsync();
        Task<BookAuthor> GetBookAuthorAsync(int Id);
        Task<BookAuthor> UpdateBookAuthorAsync(int Id, BookAuthor bookAuthor);
        
        Task<BookAuthor> CreateBookAuthorAsync(BookAuthor bookAuthor);
        Task<int> DeleteBookAuthorAsync(int Id);
    }
}
