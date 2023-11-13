using CinemaWorld.Services.Services.Data.Mapping;
using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Global.Common.ModelValidation;
using static CinemaWorld.Global.Common.ModelValidation.Genre;
namespace CinemaWorld.ViewModels.ViewModels.Genres
{
    using Genre = CinemaWorld.Models.Genre;
    public class GenreEditViewModel : IMapFrom<Genre>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = EmptyFieldLengthError)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = NameLengthError)]

        public string Name { get; set; }
    }
}
