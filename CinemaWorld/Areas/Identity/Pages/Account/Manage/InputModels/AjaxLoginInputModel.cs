using System.ComponentModel.DataAnnotations;

namespace CinemaWorld.Areas.Identity.Pages.Account.Manage.InputModels
{
    public class AjaxLoginInputModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
