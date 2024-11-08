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
        public async Task<IActionResult> GetBookAuthors()
        {
            try
            {
                IList<BookAuthor> bookAuthors = await _service.GetBookAuthorsAsync();
                return Ok(bookAuthors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookAuthor([FromRoute] int id)
        {
            try
            {
                BookAuthor bookAuthor = await _service.GetBookAuthorAsync(id);
                return Ok(bookAuthor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost()]
        public async Task<IActionResult> PostBookAuthor(BookAuthorPostModel bookAuthorPostModel)
        {
            BookAuthor bookAuthor = bookAuthorPostModel.ToBookAuthor();
            try
            {
                int commits = await _service.PostBookAuthorAsync(bookAuthor);
                return Ok(commits);

            }
            catch (DbUpdateException ex) {
                return BadRequest(ex.InnerException?.Message);
            }
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutBookAuthor([FromBody] BookAuthor bookAuthor, [FromRoute] int Id)
        {
            if (Id != bookAuthor.Id)
                return BadRequest();
            try
            {
                BookAuthor edited = await _service.PutBookAuthorAsync(Id, bookAuthor);
                return Ok(edited);

            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteBookAuthor([FromRoute] int Id)
        {
            try
            {
                int commits =await _service.DeleteBookAuthorAsync(Id);
                return Ok(commits);

          
            }
            catch(DbUpdateException ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }
        }
    };
}

