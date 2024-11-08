using Library.Models;

namespace Library.Services.Common
{
    public interface IBookAuthorService
    {
        Task<IList<BookAuthor>> GetBookAuthorsAsync();
        Task<BookAuthor> GetBookAuthorAsync(int id);
        Task<BookAuthor> PutBookAuthorAsync(int Id, BookAuthor bookAuthor);

        Task<int> PostBookAuthorAsync(BookAuthor bookAuthor);
    }
}
