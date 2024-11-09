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
            if (_dbContext == null)
            {
                return null;
            }
            return await _dbContext.Genres.ToListAsync();
        }
        public async Task<Genre> GetGenreAsync(int Id)
        {
            if (_dbContext == null)
            {
                return null;
            }
            return await _dbContext.Genres.FindAsync(Id);
        }
        public async Task<int> CreateGenreAsync(Genre genre)
        {
            if (_dbContext == null)
            {
                return 0;
            }
            _dbContext.Genres.Add(genre);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<Genre> UpdateGenreAsync(int id, Genre editedGenre)
        {
            if (_dbContext == null)
            {
                return null;
            }

            Genre genre = await GetGenreAsync(id);
            
            if (!string.IsNullOrEmpty(editedGenre.GenreName))
            {
                genre.GenreName = editedGenre.GenreName;
            }
            await _dbContext.SaveChangesAsync();
            return genre;
        }
        public async Task<int> DeleteGenreAsync(int Id)
        {
            if (_dbContext == null)
            {
                return 0;
            }
            Genre genre = await _dbContext.Genres.FindAsync(Id);
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
