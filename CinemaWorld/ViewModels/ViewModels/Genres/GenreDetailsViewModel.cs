using CinemaWorld.Models;
using CinemaWorld.Services.Services.Data.Mapping;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Global.Common.ModelValidation.Genre;

namespace CinemaWorld.ViewModels.ViewModels.Genre
{
    public class GenreDetailsViewModel : IMapFrom<Models.Genre>
    {
        public int Id { get; set; }
        [Display(Name = NameDisplayName)]
        public string Name { get; set; }
    }
}
