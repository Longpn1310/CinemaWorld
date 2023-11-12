using CinemaWorld.Models;
using CinemaWorld.ViewModels.Mapping;
using static CinemaWorld.Global.Common.ModelValidation.Country;
using static CinemaWorld.Global.Common.ModelValidation;
using System.ComponentModel.DataAnnotations;

namespace CinemaWorld.ViewModels.ViewModels.Countries
{
    public class CountryEditViewModel : IMapFrom<Models.Country>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = EmptyFieldLengthError)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = NameLengthError)]
        public string Name { get; set; }
    }
}
