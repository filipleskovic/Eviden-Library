using Library.Models;

namespace Library.IBookAuthorRepoistory.cs
{
    public interface IBookAuthorRepository
    {
        Task<IList<BookAuthor>> GetBookAuthorsAsync();
        Task<BookAuthor> GetBookAuthorAsync(int id);
        Task<BookAuthor> PutBookAuthorAsync(int Id, BookAuthor bookAuthor);
        Task<int> PostBookAuthorAsync(BookAuthor bookAuthor);
        
    }
}
