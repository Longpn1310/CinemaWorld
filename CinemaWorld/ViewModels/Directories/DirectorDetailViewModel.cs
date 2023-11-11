using CinemaWorld.Models;
using CinemaWorld.ViewModels.Mapping;
using System.ComponentModel.DataAnnotations;

namespace CinemaWorld.ViewModels.Directories
{
    public class DirectorDetailViewModel : IMapFrom<Director>
    {
        public int Id { get; set; }
        [Display(Name = "FirstNameDisplayName")]

        public string FirstName { get; set; }

        [Display(Name ="LastNameDisplayName")]
        public string LastName { get; set; }

        [Display(Name = "FullNameDisplayName")]
        public string FullName => string.Concat(this.FirstName, this.LastName);
    }
}
