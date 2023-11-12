using CinemaWorld.Models;
using CinemaWorld.ViewModels.Mapping;
using System.ComponentModel.DataAnnotations;

namespace CinemaWorld.ViewModels.ViewModels.Countries
{
    public class CountryDetailsViewModel : IMapFrom<Country>
    {
        public int Id { get; set; }
        [Display(Name = nameof(Country))]
        public string Name { get; set; }
    }
}
