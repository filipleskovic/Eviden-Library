using Library.DTO.Genre;
using Library.Models;
using Library.Services.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [ApiController]
    [Route("genre")]
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
                int commits = await _service.CreateGenreAsync(genre);
                return Ok(commits);

            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateGenreAsync([FromBody] Genre genre, [FromRoute] int Id)
        {
            if (Id != genre.Id)
                return BadRequest();
            try
            {
                Genre edited = await _service.UpdateGenreAsync(Id, genre);
                return Ok(edited);

            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteGenreAuthorAsync([FromRoute] int Id)
        {
            try
            {
                int commits = await _service.DeleteGenreAsync(Id);
                return Ok(commits);


            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }
        }



    }
}
