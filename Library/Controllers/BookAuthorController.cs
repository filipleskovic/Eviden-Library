using Library.DTO.BookAuthor;
using Library.Models;
using Library.Services.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Library.Controllers
{
    [ApiController]
    [Route("book-authors")]
    public class BookAuthorController : ControllerBase
    {
        private IBookAuthorService _service;
        public BookAuthorController(IBookAuthorService service)
        {
            _service = service;
        }
        [HttpGet()]
        public async Task<IActionResult> GetBookAuthorsAsync()
        {
            try
            {
                IList<BookAuthor> bookAuthors = await _service.GetBookAuthorsAsync();
                return Ok(bookAuthors);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookAuthorAsync([FromRoute] int id)
        {
            try
            {
                BookAuthor bookAuthor = await _service.GetBookAuthorAsync(id);
                return Ok(bookAuthor);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }
        }


        [HttpPost()]
        public async Task<IActionResult> CreateBookAuthorAsync(BookAuthorPostModel bookAuthorPostModel)
        {
            BookAuthor bookAuthor = bookAuthorPostModel.ToBookAuthor();
            try
            {
                BookAuthor addedBookAuthor = await _service.CreateBookAuthorAsync(bookAuthor);
                return Ok(addedBookAuthor);

            }
            catch (DbUpdateException ex) {
                return BadRequest(ex.InnerException?.Message);
            }
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateBookAuthorAsync([FromBody] BookAuthorPutModel bookAuthorPutModel, [FromRoute] int Id)
        {
 
            try
            {
                BookAuthor bookAuthor = bookAuthorPutModel.ToBookAuthor();
                BookAuthor edited = await _service.UpdateBookAuthorAsync(Id, bookAuthor);
                return Ok(edited);

            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteBookAuthorAsync([FromRoute] int Id)
        {
            try
            {
                int commits =await _service.DeleteBookAuthorAsync(Id);
                return Ok("BookAuthor deleted successfully");

          
            }
            catch(DbUpdateException ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }
        }
    };
}

