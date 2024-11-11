using Library.Models;
using Library.Validators;

namespace Library.Services.Common
{
    public interface IBookService
    {
        Task<IList<Book>> GetBooksAsync();
        Task<Book> GetBookAsync(int id);
        Task <BookValidator> CreateBookAsync(Book book);
        Task <BookValidator> UpdateBookAsync(int id,Book editedBook);
        Task <int> DeleteBookAsync(int id); 
    }
}
