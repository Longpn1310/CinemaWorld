using CinemaWorld.Models;
using CinemaWorld.Services.Services.Data.Mapping;
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
