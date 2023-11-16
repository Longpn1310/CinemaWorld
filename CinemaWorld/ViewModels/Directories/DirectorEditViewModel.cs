using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Global.Common.ModelValidation.Director;

namespace CinemaWorld.ViewModels.Directories
{
    public class DirectorEditViewModel
    {
        public int Id { get; set; }

        [Display(Name = FirstNameDisplayName)]
        public string FirstName { get; set; }

        [Display(Name = LastNameDisplayName)]
        public string LastName { get; set; }
    }
}
