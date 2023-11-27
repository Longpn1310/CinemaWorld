using CinemaWorld.InputModels.AdministratorInputModels.MovieProjections;
using CinemaWorld.Services.Services.Data.Contract;
using CinemaWorld.ViewModels.MovieProjections;
using CinemaWorld.ViewModels.ViewModels.MovieProjections;

namespace CinemaWorld.Services.Services.Data.Contracts
{
    public interface IMovieProjectionsService : IBaseDataService
    {
        Task<MovieProjectionDetailsViewModel> CreateAsync(MovieProjectionCreateInputModel model);

        Task EditAsync(MovieProjectionEditViewModel movieProjectionEditViewModel);

        Task<IEnumerable<TViewModel>> GetAllMovieProjectionsAsync<TViewModel>();

        IQueryable<TViewModel> GetAllMovieProjectionsByCinemaAsQueryeable<TViewModel>(string cinemaName = null);

        IQueryable<TViewModel> GetAllMovieProjectionsAsQueryeable<TViewModel>();
    }
}
