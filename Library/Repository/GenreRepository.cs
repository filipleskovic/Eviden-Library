using Library.Models;
using Library.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository
{
    public class GenreRepository:IGenreRepository
    {
        private readonly LibraryContext _dbContext;
        public GenreRepository(LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IList<Genre>> GetGenresAsync()
        {
            
            return await _dbContext.Genres.ToListAsync();
        }
        public async Task<Genre> GetGenreAsync(int id)
        {
            Genre genre = await _dbContext.Genres.FindAsync(id);
            if(genre == null)
            {
                return null;
            }
            return genre;
        }
        public async Task<Genre> CreateGenreAsync(Genre genre)
        {
            
            _dbContext.Genres.Add(genre);
            await _dbContext.SaveChangesAsync();
            genre = _dbContext.Genres.OrderByDescending(genre=>genre.Id).FirstOrDefault();
            return genre;
        }
        public async Task<Genre> UpdateGenreAsync(int id, Genre editedGenre)
        {
            

            Genre genre = await GetGenreAsync(id);
            if(genre == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(editedGenre.GenreName))
            {
                genre.GenreName = editedGenre.GenreName;
            }
            await _dbContext.SaveChangesAsync();
            return genre;
        }
        public async Task<int> DeleteGenreAsync(int id)
        {

            Genre genre = await GetGenreAsync(id);
            if (genre == null)
            {
                return -1;
            }
            _dbContext.Genres.Remove(genre);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
    }
}
