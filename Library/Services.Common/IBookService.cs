using Library.Models;

namespace Library.Services.Common
{
    public interface IBookService
    {
        Task<IList<Book>> GetBooksAsync();
        Task<Book> GetBookAsync(int id);
        Task <int> CreateBookAsync(Book book);
        Task <Book>UpdateBookAsync(int id,Book editedBook);
        Task <int> DeleteBookAsync(int id); 
    }
}
