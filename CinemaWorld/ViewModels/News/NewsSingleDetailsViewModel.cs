using CinemaWorld.ViewModels.ViewModels.Movies;

namespace CinemaWorld.ViewModels.News
{
    public class NewsSingleDetailsViewModel
    {
        public NewsDetailsViewModel News { get; set; }

        public IEnumerable<RecentlyAddedMovieDetailsViewModel> LatestMovies { get; set; }

        public IEnumerable<TopNewsViewModel> TopNews { get; set; }
    }
}
