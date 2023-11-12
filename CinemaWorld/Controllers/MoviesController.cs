using CinemaWorld.Helper;
using CinemaWorld.Services.Services.Data.Contract;
using CinemaWorld.ViewModels;
using CinemaWorld.ViewModels.ViewModels.Movies;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWorld.Controllers
{
    public class MoviesController : Controller
    {
        private const int pageSize = 10;
        private readonly IMoviesService moviesService;  

        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }
        public async Task<IActionResult> All(string searchString, string currentFilter,string selectedLetter, int? pageNumber)
        {
            this.ViewData["Current"] = nameof(this.All);
            if(searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            var movies = this.moviesService
                .GetAllMoviesByFilterAsQueryeable<MovieDetailsViewModel>(selectedLetter);
            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(m => m.Name.ToLower().Contains(searchString.ToLower()));  
            }
            var moviesPaginated = await PaginatedList<MovieDetailsViewModel>.CreateAsync(movies, pageNumber ?? 1, pageSize);

            var alphabeticalPagingViewModel = new AlphabeticalPagingViewModel()
            {
                SelectedLetter = selectedLetter
            };
            var viewModel = new MovieListingViewModel
            {
                Movies = moviesPaginated,
                AlphabeticalPagingViewModel = alphabeticalPagingViewModel
            };

            return this.View(viewModel);

        }
        public async Task<IActionResult> Details(int id)
        {
            var movie = await this.moviesService.GetViewModelByIdAsync<MovieDetailsViewModel>(id);
            var topRatingMovies = await this.moviesService.GetAllMoviesAsync<TopRatingMovieDetailsViewModel>();

            string videoId = ExtractVideoHelper.ExtractVideoId(movie.TrailerPath);
            movie.TrailerPath = videoId;

            var viewModel = new DetailsListingViewModel
            {
                movieDetailsViewModel = movie,
                AllMovies = topRatingMovies
            };
            return this.View(viewModel);
        }
    }
}
