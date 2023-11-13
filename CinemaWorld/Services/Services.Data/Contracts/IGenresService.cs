using CinemaWorld.InputModels.AdministratorInputModels.Genres;
using CinemaWorld.Services.Services.Data.Contract;
using CinemaWorld.ViewModels.ViewModels.Genre;
using CinemaWorld.ViewModels.ViewModels.Genres;

namespace CinemaWorld.Services.Services.Data.Contracts
{
    public interface IGenresService : IBaseDataService
    {
        Task<GenreDetailsViewModel> CreateAsync(GenreCreateInputModel genreCreateInputVModel);

        Task EditAsync(GenreEditViewModel genreEditViewModel);

        Task<IEnumerable<TEntity>> GetAllGenresAsync<TEntity>();
    }
}
