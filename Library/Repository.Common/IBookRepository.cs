using Library.Models;

namespace Library.Repository.Common
{
    public interface IBookRepository
    {
        Task<IList<Book>> GetBooksAsync();
        Task<Book> GetBookAsync(int id);
        Task<Book> CreateBookAsync(Book book);
        Task<Book> UpdateBookAsync(int id, Book editedBook);
        Task<int> DeleteBookAsync(int id);
    }
}
