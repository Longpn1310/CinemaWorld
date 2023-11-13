using CinemaWorld.InputModels.AdministratorInputModels.MovieProjections;
using CinemaWorld.Services.Services.Data.Contracts;
using CinemaWorld.ViewModels.ViewModels.MovieProjections;

namespace CinemaWorld.Services.Services.Data
{
    public class MovieProjectionsService : IMovieProjectionsService
    {
        public Task<MovieProjectionsViewModel> CreateAsync(MovieProjectionCreateInputModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TViewModel> GetViewModelByIdAsync<TViewModel>(int id)
        {
            throw new NotImplementedException();
        }
    }
}
