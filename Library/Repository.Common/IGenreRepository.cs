using Library.Models;

namespace Library.Repository.Common
{
    public interface IGenreRepository
    {
        Task<IList<Genre>> GetGenresAsync();
        Task<Genre> GetGenreAsync(int Id);
        Task<Genre> UpdateGenreAsync(int Id, Genre genre);

        Task<Genre> CreateGenreAsync(Genre genre);
        Task<int> DeleteGenreAsync(int Id);
    }
}
