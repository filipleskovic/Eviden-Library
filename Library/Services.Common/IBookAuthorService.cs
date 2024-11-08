using Library.Models;

namespace Library.Services.Common
{
    public interface IBookAuthorService
    {
        Task<IList<BookAuthor>> GetBookAuthorsAsync();
        Task<int> PostBookAuthorAsync(BookAuthor bookAuthor);
    }
}
