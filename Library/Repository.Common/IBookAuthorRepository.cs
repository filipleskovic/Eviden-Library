using Library.Models;

namespace Library.IBookAuthorRepoistory.cs
{
    public interface IBookAuthorRepository
    {
        Task<IList<BookAuthor>> GetBookAuthorsAsync();
        Task<BookAuthor> GetBookAuthorAsync(int id);
        Task<BookAuthor> UpdateBookAuthorAsync(int Id, BookAuthor bookAuthor);
        Task<int> CreateBookAuthorAsync(BookAuthor bookAuthor);
        Task<int> DeleteBookAuthorAsync(int Id);


    }
}
