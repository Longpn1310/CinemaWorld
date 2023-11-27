
namespace CinemaWorld.ViewModels.MovieProjections
{
    using CinemaWorld.Models;
    using CinemaWorld.Services.Services.Data.Mapping;
    using CinemaWorld.ViewModels.ViewModels.Cinemas;
    using CinemaWorld.ViewModels.ViewModels.Halls;
    using CinemaWorld.ViewModels.ViewModels.Movies;
    using System.ComponentModel.DataAnnotations;

    public class MovieProjectionDetailsViewModel : IMapFrom<MovieProjection>
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Display(Name = nameof(Movie))]
        public MovieDetailsViewModel Movie { get; set; }

        [Display(Name = nameof(Hall))]
        public HallDetailsViewModel Hall { get; set; }

        [Display(Name = nameof(Cinema))]
        public CinemaDetailsViewModel Cinema{get; set;}
        }
}
