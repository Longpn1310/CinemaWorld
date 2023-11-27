using CinemaWorld.Services.Services.Data.Contract;
using CinemaWorld.ViewModels;
using CinemaWorld.ViewModels.ViewModels.Movies;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWorld.Controllers
{
    public class GenresController : Controller
    {
        private const int GenresPerPage = 12;
        private readonly IMoviesService moviesService;

        public GenresController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        public async Task<IActionResult> ByName(int? pageNumber, string name)
        {
            var moviesByGenreName = await Task.Run(() => this.moviesService.GetByGenreNameAsQueryable(name));

            if(moviesByGenreName.Count() == 0)
            {
                return this.NotFound();
            }

            this.TempData["GenreName"] = name;
            var moviesByGenreNamePaginated = await PaginatedList<MovieDetailsViewModel>
                .CreateAsync(moviesByGenreName, pageNumber ?? 1, GenresPerPage);

            return this.View(moviesByGenreNamePaginated);
        }
    }
}
