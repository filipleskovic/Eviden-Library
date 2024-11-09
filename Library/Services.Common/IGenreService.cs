using Library.Models;

namespace Library.Services.Common
{
    public interface IGenreService
    {
        Task<IList<Genre>> GetGenresAsync();
        Task<Genre> GetGenreAsync(int Id);
        Task<Genre> UpdateGenreAsync(int Id, Genre genre);

        Task<int> CreateGenreAsync(Genre genre);
        Task<int> DeleteGenreAsync(int Id);
    }
}
