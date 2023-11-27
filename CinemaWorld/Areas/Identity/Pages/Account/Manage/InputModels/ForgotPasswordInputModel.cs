using System.ComponentModel.DataAnnotations;

namespace CinemaWorld.Areas.Identity.Pages.Account.Manage.InputModels
{
    public class ForgotPasswordInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
