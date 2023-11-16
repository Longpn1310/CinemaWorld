using static CinemaWorld.Global.Common.ModelValidation.Country;
using static CinemaWorld.Global.Common.ModelValidation;
using System.ComponentModel.DataAnnotations;

namespace CinemaWorld.InputModels.Countries
{
    public class CountryCreateInputModel
    {
        [Required(ErrorMessage = EmptyFieldLengthError)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = NameLengthError)]
        public string Name { get; set; }
    }
}
