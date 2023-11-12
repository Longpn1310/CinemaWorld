using CinemaWorld.Services.Services.Data.Contract;
using CinemaWorld.ViewModels.ViewModels.Genre;

namespace CinemaWorld.Services.Services.Data.Contracts
{
    public interface IGenresService : IBaseDataService
    {
        Task<GenreDetailsViewModel> CreateAsync(GenreDetailsViewModel genreDetailsViewModel);

        Task EditAsync(GenreDetailsViewModel genreDetailsViewModel);

        Task<IEnumerable<TEntity>> GetAllGenresAsync<TEntity>();
    }
}
