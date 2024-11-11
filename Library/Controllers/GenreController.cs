using Library.DTO.Genre;
using Library.Models;
using Library.Services.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [ApiController]
    [Route("genres")]
    public class GenreController: ControllerBase
    {
        private IGenreService _service;
        public GenreController(IGenreService service)
        {
            _service = service;
        }
        [HttpGet()]   
        public async Task<IActionResult> GetGenresAsync()
        {
            try
            {
                IList<Genre> genres = await _service.GetGenresAsync();
                return Ok(genres);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreAsync([FromRoute] int id)
        {
            try
            {
                Genre genre = await _service.GetGenreAsync(id);
                if (genre == null)
                {
                    return NotFound($"Genre with id: {id} not found");
                }
                return Ok(genre);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }
        }


        [HttpPost()]
        public async Task<IActionResult> CreateGenreAsync(GenrePostModel genrePostModel)
        {
            Genre genre = genrePostModel.ToGenre();
            try
            {
                Genre addedGenre = await _service.CreateGenreAsync(genre);
                return Ok(addedGenre);

            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenreAsync([FromBody] GenrePutModel genrePutModel, [FromRoute] int id)
        {
            
            try
            {
                Genre genre = genrePutModel.ToGenre();
                Genre edited = await _service.UpdateGenreAsync(id, genre);
                if (edited == null)
                {
                    return NotFound($"Genre with id: {id} not found");
                }
                return Ok(edited);

            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenreAuthorAsync([FromRoute] int id)
        {
            try
            {
                int commits = await _service.DeleteGenreAsync(id);
                if (commits == -1)
                {
                    return NotFound($"Genre with id: {id} not found");
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
