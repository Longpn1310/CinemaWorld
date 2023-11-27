using System.ComponentModel.DataAnnotations;

namespace CinemaWorld.Areas.Identity.Pages.Account.Manage
{
    public class IndexInputModel
    {
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
    }
}
