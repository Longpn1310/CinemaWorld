using CinemaWorld.InputModels.AdministratorInputModels.Movies;
using CinemaWorld.Services.Services.Data.Contract;
using CinemaWorld.ViewModels.Enumerations;
using CinemaWorld.ViewModels.ViewModels.Movies;
using CinemaWorld.Services.Common;
namespace CinemaWorld.Services.Services.Data
{
    public class MovieService : IMoviesService
    {
        public const string AllPaginationFilter = "All";
        private const string DigitPaginationFilter = "0 - 9";
        private const int MostPopularMoviesRating = 40;

        public async Task<MovieDetailsViewModel> CreateAsync(MovieCreateInputModel movieCreateInputModel)
        {
            if(!Enum.TryParse(movieCreateInputModel.CinemaCategory, true,out CinemaCategory cinemaCategory))
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.InvalidCinemaCategoryType, movieCreateInputModel.CinemaCategory))
            }
            var director = await this.directorsRepository
                .All()
                .FirstOF
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(MovieEditViewModel movieEditViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TViewModel>> GetAllMovieCountriesAsync<TViewModel>()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TViewModel>> GetAllMovieGenresAsync<TViewModel>()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TViewModel> GetAllMoviesAsQueryeable<TViewModel>()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TViewModel>> GetAllMoviesAsync<TViewModel>()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TViewModel> GetAllMoviesByFilterAsQueryeable<TViewModel>(string letter = null)
        {
            throw new NotImplementedException();
        }

        public IQueryable<MovieDetailsViewModel> GetByGenreNameAsQueryable(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TViewModel>> GetMostPopularMoviesAsync<TViewModel>(int count = 0)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TViewModel>> GetRecentlyAddedMoviesAsync<TViewModel>(int count = 0)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TViewModel>> GetTopImdbMoviesAsync<TViewModel>(decimal rating = 0, int count = 0)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TViewModel>> GetTopRatingMoviesAsync<TViewModel>(decimal rating = 0, int count = 0)
        {
            throw new NotImplementedException();
        }

        public Task<TViewModel> GetViewModelByIdAsync<TViewModel>(int id)
        {
            throw new NotImplementedException();
        }
    }
}
