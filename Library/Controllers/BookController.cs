using Library.DTO.Book;
using Library.DTO.BookAuthor;
using Library.Models;
using Library.Services.Common;
using Library.Validators;
using Microsoft.AspNetCore.Http.Metadata;
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
                if(book==null)
                {
                    return NotFound($"Book with Id : {id} not found");
                }
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
                BookValidator bookValidator= await _service.CreateBookAsync(book);
                if(bookValidator.Book == null)
                {
                    return NotFound(bookValidator.Message);
                }
                return Ok(bookValidator.Book);
                

            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditBookAsync([FromBody] BookPutModel bookPutModel, [FromRoute] int id)
        {
            try
            {
                Book book = bookPutModel.ToBook();
                BookValidator bookValidator = await _service.UpdateBookAsync(id, book);
                if(bookValidator.Book==null)
                {
                    return NotFound(bookValidator.Message);
                }
                return Ok(bookValidator.Book);
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
                int commits =await _service.DeleteBookAsync(id);
                if (commits == -1)
                {
                    return NotFound($"Book with Id : {id} not found");
                }
                return Ok("Book deleted successfully");
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }
        }
    }
}
