
using Library.Models;
using Library.Repository.Common;
using Library.Services.Common;

namespace Library.Services
{
    public class GenreService:IGenreService
    {
        private IGenreRepository _repository;
        public GenreService(IGenreRepository repository)
        {
            _repository = repository;
        }
        public async Task<IList<Genre>> GetGenresAsync()
        {
            return await _repository.GetGenresAsync();
        }
        public async Task<Genre> GetGenreAsync(int Id)
        {
            return await _repository.GetGenreAsync(Id);
        }
        public async Task<Genre> CreateGenreAsync(Genre genre)
        {
            return await _repository.CreateGenreAsync(genre);
        }
        public async Task<Genre> UpdateGenreAsync(int Id, Genre genre)
        {
            return await _repository.UpdateGenreAsync(Id, genre);
        }
        public async Task<int> DeleteGenreAsync(int Id)
        {
            return await _repository.DeleteGenreAsync(Id);
        }
    }
}
