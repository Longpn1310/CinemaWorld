using CinemaWorld.Models;
using CinemaWorld.Services.Services.Data.Mapping;

namespace CinemaWorld.ViewModels.ViewModels.Movies
{
    public class MovieGenreViewModel : IMapFrom<MovieGenre>, IMapFrom<Models.Genre>
    {
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public Models.Genre Genre { get; set; }
        public int GenreId { get; set;}
    }
}
