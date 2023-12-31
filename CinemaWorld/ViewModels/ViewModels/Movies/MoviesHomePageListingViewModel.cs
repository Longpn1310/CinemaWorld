﻿namespace CinemaWorld.ViewModels.ViewModels.Movies
{
    public class MoviesHomePageListingViewModel
    {
        public IEnumerable<TopRatingMovieDetailsViewModel> AllMovies { get; set; }

        public IEnumerable<SliderMovieDetailsViewModel> TopMoviesInSlider { get; set; }

        public IEnumerable<TopRatingMovieDetailsViewModel> TopRatingMovies { get; set; }

        public IEnumerable<RecentlyAddedMovieDetailsViewModel> RecentlyAddedMovies { get; set; }

        public IEnumerable<MostPopularDetailsViewModel> MostPopularMovies { get; set; }
    }
}
