using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Global.Common.ModelValidation;
using static CinemaWorld.Global.Common.ModelValidation.Director;

namespace CinemaWorld.InputModels.AdministratorInputModels.Directors
{
    public class DirectorCreateInputModel
    {
        [Display(Name = FirstNameDisplayName)]
        [Required(ErrorMessage = EmptyFieldLengthError)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = NameLengthError)]
        public string FirstName { get; set; }

        [Display(Name = LastNameDisplayName)]
        [Required(ErrorMessage = EmptyFieldLengthError)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = NameLengthError)]
        public string LastName { get; set; }
    }
}
