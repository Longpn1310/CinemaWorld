using CinemaWorld.Models;
using CinemaWorld.Services.Services.Data.Mapping;
using CinemaWorld.ViewModels.ViewModels.Cinemas;
using CinemaWorld.ViewModels.ViewModels.Halls;
using CinemaWorld.ViewModels.ViewModels.Movies;
using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Global.Common.ModelValidation;
using static CinemaWorld.Global.Common.ModelValidation.Cinema;
using static CinemaWorld.Global.Common.ModelValidation.Hall;
using static CinemaWorld.Global.Common.ModelValidation.Movie;
namespace CinemaWorld.ViewModels.ViewModels.MovieProjections
{
    using Cinema = CinemaWorld.Models.Cinema;
    using Hall = CinemaWorld.Models.Hall;
    using Movie = CinemaWorld.Models.Movie;
    public class MovieProjectionEditViewModel : IMapFrom<MovieProjection>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = EmptyFieldLengthError)]
        public DateTime Date { get; set; }

        [Display(Name = nameof(Movie))]
        [Range(1, int.MaxValue, ErrorMessage = MovieIdError)]
        public int MovieId { get; set; }

        public IEnumerable<MovieDetailsViewModel> Movies { get; set; }

        [Display(Name = nameof(Hall))]
        [Range(1, int.MaxValue, ErrorMessage = HallIdError)]
        public int HallId { get; set; }

        public IEnumerable<HallDetailsViewModel> Halls { get; set; }

        [Display(Name = nameof(Cinema))]
        [Range(1, int.MaxValue, ErrorMessage = CinemaIdError)]
        public int CinemaId { get; set; }

        public IEnumerable<CinemaDetailsViewModel> Cinemas { get; set; }
    }
}
