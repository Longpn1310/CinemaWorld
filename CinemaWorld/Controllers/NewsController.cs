using CinemaWorld.Services.Services.Data;
using CinemaWorld.Services.Services.Data.Contract;
using CinemaWorld.Services.Services.Data.Contracts;
using CinemaWorld.ViewModels;
using CinemaWorld.ViewModels.News;
using CinemaWorld.ViewModels.ViewModels.Movies;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWorld.Controllers
{
    public class NewsController : Controller
    {
        private const int NewsCount = 6;
        private const int LastestMoviesCount = 6;
        private const int TopMoviesCount = 10;

        private readonly INewsService newsService;
        private readonly IMoviesService moviesService;

        public NewsController(INewsService newsService, IMoviesService moviesService)
        {
            this.newsService = newsService;
            this.moviesService = moviesService;
        }
        public async Task<IActionResult> Index(int? pageNumber)
        {
            var news = await Task.Run(
                () => this.newsService.GetAllNewsAsQueryeable<AllNewsListingViewModel>());

            var newsPaginated = await PaginatedList<AllNewsListingViewModel>
                .CreateAsync(news, pageNumber ?? 1, NewsCount);
            var updatedNews = await this.newsService
                .GetUpdatedNewsAsync<UpdatedNewsDetailsViewModel>();
            var topNews = await this.newsService
                .GetTopNewsAsync<TopNewsViewModel>(TopMoviesCount);

            var viewModel = new NewsIndexViewModel
            {
                News = newsPaginated,
                UpdatedNews = updatedNews,
                TopNews = topNews,
            };
            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var news = await this.newsService.SetViewsCounter(id);
            var lastestMovies = await this.moviesService.GetRecentlyAddedMoviesAsync<RecentlyAddedMovieDetailsViewModel>(LastestMoviesCount);
            var topNews = await this.newsService.GetTopNewsAsync<TopNewsViewModel>(TopMoviesCount);

            var viewModel = new NewsSingleDetailsViewModel
            {
                News = news,
                LatestMovies = lastestMovies,
                TopNews = topNews,
            };

            return this.View(viewModel);
        }
    }
}
