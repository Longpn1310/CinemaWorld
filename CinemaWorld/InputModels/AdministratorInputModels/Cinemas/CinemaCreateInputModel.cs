using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Global.Common.ModelValidation;
using static CinemaWorld.Global.Common.ModelValidation.Cinema;

namespace CinemaWorld.InputModels.AdministratorInputModels.Cinemas
{
    public class CinemaCreateInputModel
    {
        [Required(ErrorMessage = EmptyFieldLengthError)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = NameLengthError)]
        public string Name { get; set; }

        [Required(ErrorMessage = EmptyFieldLengthError)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = NameLengthError)]
        public string Address {  get; set; }
    }
}
