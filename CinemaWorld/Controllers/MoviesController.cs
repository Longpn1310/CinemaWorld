using CinemaWorld.Services.Services.Data.Contract;
using CinemaWorld.ViewModels.ViewModels.Movies;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWorld.Controllers
{
    public class MoviesController : Controller
    {
        private const int PageSize = 10;
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
            this.ViewData["CurrentSearchFilter"] = searchString;
            var movies = this.moviesService.GetAllMoviesAsQueryable<MovieDetailsViewModel>(selectedLetter);

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
