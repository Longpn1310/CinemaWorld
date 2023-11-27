using System.ComponentModel.DataAnnotations;

namespace CinemaWorld.Areas.Identity.Pages.Account.Manage
{
    public class EmailInputModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "New email")]
        public string NewEmail { get; set; }
    }
}
