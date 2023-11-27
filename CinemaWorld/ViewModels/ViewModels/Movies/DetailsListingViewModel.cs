namespace CinemaWorld.ViewModels.ViewModels.Movies
{
    public class DetailsListingViewModel
    {
        public MovieDetailsViewModel MovieDetailsViewModel { get; set; }
        public IEnumerable<TopRatingMovieDetailsViewModel> AllMovies { get; set; }
    }
}
