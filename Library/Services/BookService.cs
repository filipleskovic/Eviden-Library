using Library.Models;
using Library.Repository.Common;
using Library.Services.Common;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private IBookRepository _repository;
        public BookService(IBookRepository repository)
        {
            _repository = repository; 
        }
        public async Task<Book> CreateBookAsync(Book book)
        {
           return await _repository.CreateBookAsync(book);
            
        }

        public async Task<int> DeleteBookAsync(int id)
        {
            return await _repository.DeleteBookAsync(id);
        }

        public async  Task<Book> GetBookAsync(int id)
        {
            return await _repository.GetBookAsync(id);
        }

        public async Task<IList<Book>> GetBooksAsync()
        {
            return await _repository.GetBooksAsync();
        }

        public async Task<Book> UpdateBookAsync(int id, Book editedBook)
        {
            return await _repository.UpdateBookAsync(id, editedBook);
        }
    }
}
