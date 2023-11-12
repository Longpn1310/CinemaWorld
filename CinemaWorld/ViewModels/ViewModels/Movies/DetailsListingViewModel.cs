namespace CinemaWorld.ViewModels.ViewModels.Movies
{
    public class DetailsListingViewModel
    {
        public MovieDetailsViewModel movieDetailsViewModel { get; set; }
        public IEnumerable<TopRatingMovieDetailsViewModel> AllMovies { get; set; }
    }
}
