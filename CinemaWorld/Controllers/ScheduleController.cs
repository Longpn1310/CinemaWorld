using CinemaWorld.Services.Services.Data.Contract;
using CinemaWorld.Services.Services.Data.Contracts;
using CinemaWorld.ViewModels;
using CinemaWorld.ViewModels.MovieProjections;
using CinemaWorld.ViewModels.Schedules;
using CinemaWorld.ViewModels.ViewModels.Cinemas;
using CinemaWorld.ViewModels.ViewModels.Movies;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWorld.Controllers
{
    public class ScheduleController : Controller
    {
        private const int SchedulePageSize = 5;
        private const int LastestMoviesCount = 6;

        private readonly IMovieProjectionsService movieProjectionsService;
        private readonly IMoviesService moviesService;
       private readonly ICinemasService cinemasService;

        public ScheduleController(IMovieProjectionsService movieProjectionsService, IMoviesService moviesService, ICinemasService cinemasService)
        {
            this.movieProjectionsService = movieProjectionsService;
            this.moviesService = moviesService;
            this.cinemasService = cinemasService;
        }

        public async Task<IActionResult> Index(int? pageNumber, string cinemaName)
        {
            this.ViewData["CurrentFilter"] = cinemaName;

            var movieProjections = Enumerable.Empty<MovieProjectionDetailsViewModel>().AsQueryable();

            if(!string.IsNullOrEmpty(cinemaName))
            {
                movieProjections = await Task.Run(
                    () => this.movieProjectionsService
                    .GetAllMovieProjectionsByCinemaAsQueryeable<MovieProjectionDetailsViewModel>(cinemaName));
            }
            else
            {
                movieProjections = await Task.Run(() => this.movieProjectionsService
                .GetAllMovieProjectionsAsQueryeable<MovieProjectionDetailsViewModel>());
            }

            var movieProjectionsPaginated = await PaginatedList<MovieProjectionDetailsViewModel>.CreateAsync(movieProjections, pageNumber ?? 1, SchedulePageSize);

            var lastestMovies = await this.moviesService.GetRecentlyAddedMoviesAsync<RecentlyAddedMovieDetailsViewModel>(LastestMoviesCount);

            var cinemas = await this.cinemasService.GetAllCinemasAsync<CinemaDetailsViewModel>();

            var viewModel = new ScheduleDetailsViewModel
            {
                MovieProjections = movieProjectionsPaginated,
                LatestMovies = lastestMovies,
                Cinemas = cinemas,
            };

            return this.View(viewModel);
        }
    }
}
