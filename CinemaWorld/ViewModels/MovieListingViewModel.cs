using CinemaWorld.ViewModels.ViewModels.Movies;

namespace CinemaWorld.ViewModels
{
    public class MovieListingViewModel
    {
        public PaginatedList<MovieDetailsViewModel> Movies { get; set; }
        public AlphabeticalPagingViewModel AlphabeticalPagingViewModel { get; set; }
    }
}
