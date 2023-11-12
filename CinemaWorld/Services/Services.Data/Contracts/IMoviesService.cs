using CinemaWorld.InputModels.AdministratorInputModels.Movies;
using CinemaWorld.ViewModels.ViewModels.Movies;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWorld.Services.Services.Data.Contract
{
    public interface IMoviesService : IBaseDataService
    {
        Task<MovieDetailsViewModel> CreateAsync(MovieCreateInputModel movieCreateInputModel);

        Task EditAsync(MovieEditViewModel movieEditViewModel);

        Task<IEnumerable<TViewModel>> GetAllMoviesAsync<TViewModel>();

        Task<IEnumerable<TViewModel>> GetTopImdbMoviesAsync<TViewModel>(decimal rating = 0, int count = 0);

        Task<IEnumerable<TViewModel>> GetTopRatingMoviesAsync<TViewModel>(decimal rating = 0, int count = 0);

        Task<IEnumerable<TViewModel>> GetRecentlyAddedMoviesAsync<TViewModel>(int count = 0);

        Task<IEnumerable<TViewModel>> GetMostPopularMoviesAsync<TViewModel>(int count = 0);

        Task<IEnumerable<TViewModel>> GetAllMovieGenresAsync<TViewModel>();

        Task<IEnumerable<TViewModel>> GetAllMovieCountriesAsync<TViewModel>();

        IQueryable<TViewModel> GetAllMoviesAsQueryeable<TViewModel>();

        IQueryable<MovieDetailsViewModel> GetByGenreNameAsQueryable(string name);

        IQueryable<TViewModel> GetAllMoviesByFilterAsQueryeable<TViewModel>(string letter = null);
    }
}
