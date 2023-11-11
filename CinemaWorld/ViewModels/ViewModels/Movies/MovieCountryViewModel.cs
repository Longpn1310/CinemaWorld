using CinemaWorld.Models;
using CinemaWorld.ViewModels.Mapping;

namespace CinemaWorld.ViewModels.ViewModels.Movies
{
    public class MovieCountryViewModel : IMapFrom<MovieCountry>, IMapFrom<Country>
    {
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
    }
}
