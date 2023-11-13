using CinemaWorld.InputModels.AdministratorInputModels.MovieProjections;
using CinemaWorld.Services.Services.Data.Contract;
using CinemaWorld.ViewModels.ViewModels.MovieProjections;

namespace CinemaWorld.Services.Services.Data.Contracts
{
    public interface IMovieProjectionsService : IBaseDataService
    {
        Task<MovieProjectionsViewModel> CreateAsync(MovieProjectionCreateInputModel model);
    }
}
