using Library.DTO.Book;
using Library.DTO.BookAuthor;
using Library.Models;
using Library.Services.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [ApiController]
    [Route("books")]
    public class BookController : ControllerBase
    {
        private IBookService _service;
        public BookController(IBookService service)
        {
            _service = service;
        }
        [HttpGet()]
        public async Task<IActionResult> GetBooksAsync()
        {
            try
            {
                IList<Book> books = await _service.GetBooksAsync();
                return Ok(books);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookAsync([FromRoute] int id)
        {
            try
            {
                Book book = await _service.GetBookAsync(id);
                return Ok(book);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }
        }


        [HttpPost()]
        public async Task<IActionResult> CreateBookAsync([FromBody] BookPostModel bookPostModel)
        {
            Book book = bookPostModel.ToBook();
            try
            {
                int commits = await _service.CreateBookAsync(book);
                return Ok("Book created successfully");

            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditBookAsync([FromBody] BookPutModel bookPutModel, [FromRoute] int id)
        {
            if (bookPutModel.Id != id)
                return BadRequest("Id can't be changed");
            Book book = bookPutModel.ToBook();
            try
            {
                book = await _service.UpdateBookAsync(id, book);
                return Ok(book);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookAsync([FromRoute] int id)
        {
            try
            {
                 await _service.DeleteBookAsync(id);
                return Ok("Book deleted successfully");
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }
        }
    }
}
