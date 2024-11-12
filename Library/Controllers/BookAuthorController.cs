using Library.DTO.BookAuthor;
using Library.Models;
using Library.Services.Common;
using Library.Validators;
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
                if (bookAuthor == null)
                {
                    return NotFound($"Book author with Id: {id} not found ");
                }
                return Ok(bookAuthor);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }
        }


        [HttpPost()]
        public async Task<IActionResult> CreateBookAuthorAsync([FromBody] BookAuthorPostModel bookAuthorPostModel)
        {
            BookAuthor bookAuthor = bookAuthorPostModel.ToBookAuthor();
            try
            {
               BookAuthorValidator bookAuthorValidator = await _service.CreateBookAuthorAsync(bookAuthor);
                if(bookAuthorValidator.BookAuthor == null)
                {
                    BadRequest(bookAuthorValidator.Message);
                }
                return Ok(bookAuthorValidator.BookAuthor);

            }
            catch (DbUpdateException ex) {
                return BadRequest(ex.InnerException?.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookAuthorAsync([FromBody] BookAuthorPutModel bookAuthorPutModel, [FromRoute] int id)
        {
 
            try
            {

                BookAuthor bookAuthor = bookAuthorPutModel.ToBookAuthor();
                BookAuthorValidator bookAuthorValidator= await _service.UpdateBookAuthorAsync(id, bookAuthor);
                if(bookAuthorValidator.BookAuthor == null)
                {
                    return BadRequest(bookAuthorValidator.Message);
                }
                return Ok(bookAuthorValidator.BookAuthor);

            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookAuthorAsync([FromRoute] int id)
        {
            try
            {

                int commits =await _service.DeleteBookAuthorAsync(id);
                if (commits == -1)
                {
                    return NotFound($"Book author with Id: {id} not found");
                }
                return Ok("BookAuthor deleted successfully");

          
            }
            catch(DbUpdateException ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }
        }
    };
}

