using CinemaWorld.Models;
using System.ComponentModel.DataAnnotations;
using CinemaWorld.Models;
using static CinemaWorld.Global.Common.ModelValidation;
using CinemaWorld.Global.Common;
using static CinemaWorld.Global.Common.ModelValidation.Movie;
using CinemaWorld.Services.Services.Data.Mapping;

namespace CinemaWorld.ViewModels.ViewModels.Movies
{
    public class MovieEditViewModel : IMapFrom<Models.Movie>, IMapFrom<Models.Director>
    {
        public int Id { get; set; }
        [Required(ErrorMessage = EmptyFieldLengthError)]
        [StringLength(ModelValidation.Movie.NameMaxLength,
            MinimumLength = ModelValidation.Movie.NameMinLength,
            ErrorMessage = NameLengthError)]
        public string Name { get; set; }

        [Required(ErrorMessage = EmptyFieldLengthError)]
        [DataType(DataType.Date)]
        [Display(Name = DateOfReleaseDisplayName)]
        public DateTime DateOfRelease { get; set;}
        [StringLength(ResolutionMaxLength)]
        public string Resolution { get; set; }

        [Range(1,RatingMaxValue)]
        public decimal Rating { get; set;}

        [Required(ErrorMessage = EmptyFieldLengthError)]
        [DataType(DataType.MultilineText)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength,ErrorMessage = DescriptionError)]
        public string Description { get; set; }
    }
}
