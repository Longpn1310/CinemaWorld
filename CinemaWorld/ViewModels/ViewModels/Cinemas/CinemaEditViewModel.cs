using CinemaWorld.Models;
using CinemaWorld.Services.Services.Data.Mapping;
using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Global.Common.ModelValidation;
using static CinemaWorld.Global.Common.ModelValidation.Cinema;

namespace CinemaWorld.ViewModels.ViewModels.Cinemas
{
    public class CinemaEditViewModel :IMapFrom<Models.Cinema>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = EmptyFieldLengthError)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength , ErrorMessage = NameLengthError)]
        public string Name { get; set; }

        [Required(ErrorMessage = EmptyFieldLengthError)]
        [StringLength(NameMaxLength, MinimumLength = NameMaxLength , ErrorMessage = NameLengthError)]
        public string Address { get; set; }
    }
}
