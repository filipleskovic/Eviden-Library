using Library.Models;

namespace Library.IBookAuthorRepoistory.cs
{
    public interface IBookAuthorRepository
    {
        Task<IList<BookAuthor>> GetBookAuthorsAsync();
        Task<int> PostBookAuthorAsync(BookAuthor bookAuthorž);
        
    }
}
