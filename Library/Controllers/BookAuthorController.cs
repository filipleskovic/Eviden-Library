using Library.Models;
using Library.Services.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookAuthorController : ControllerBase
    {
        private IBookAuthorService _service;
        public BookAuthorController(IBookAuthorService service)
        {
            _service = service;
        }
        [HttpGet("GetBookAuthors")]
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
        [HttpPost("PostBookAuthor")]
        public async Task<IActionResult> PostBookAuthor(BookAuthor bookAuthor)
        {
            try
            {
                 int commits = await _service.PostBookAuthorAsync(bookAuthor);
                return Ok(commits);
                   
            }
            catch(DbUpdateException ex) {
                return BadRequest(ex.InnerException?.Message);
            }
        }
    }
}
