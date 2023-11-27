using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Global.Common.ModelValidation.Genre;
namespace CinemaWorld.ViewModels.Genres
{
    public class GenreDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = NameDisplayName)]
        public string Name { get; set; }
    }
}
