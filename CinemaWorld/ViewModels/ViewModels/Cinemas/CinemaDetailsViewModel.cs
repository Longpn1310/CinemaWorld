using CinemaWorld.Models;
using CinemaWorld.Services.Services.Data.Mapping;
using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Global.Common.ModelValidation.Cinema;

namespace CinemaWorld.ViewModels.ViewModels.Cinemas
{
    public class CinemaDetailsViewModel : IMapFrom<Cinema>
    {
        public int Id { get; set; }
        [Display(Name = NameDisplayName)]
        public string Name { get; set; }

        public string Address { get; set; }
    }
}
