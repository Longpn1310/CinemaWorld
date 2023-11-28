using CinemaWorld.ViewModels.MovieProjections;
using CinemaWorld.ViewModels.ViewModels.Cinemas;
using CinemaWorld.ViewModels.ViewModels.Movies;

namespace CinemaWorld.ViewModels.Schedules
{
    public class ScheduleDetailsViewModel
    {
        public PaginatedList<MovieProjectionDetailsViewModel> MovieProjections { get; set; }

        public IEnumerable<RecentlyAddedMovieDetailsViewModel> LatestMovies { get; set; }

        public IEnumerable<CinemaDetailsViewModel> Cinemas { get; set; }

        public int CinemaName { get; set; }
    }
}
