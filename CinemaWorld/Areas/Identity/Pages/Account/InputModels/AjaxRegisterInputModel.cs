using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Models.DataValidation;
namespace CinemaWorld.Areas.Identity.Pages.Account.InputModels
{
    public class AjaxRegisterInputModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name ="Username")]
        public string Username { get; set; }

        [Required]
        [MaxLength(FullNameMaxLength, ErrorMessage = "The {0} must be {1} chartacter long")]
        [Display(Name ="Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string SelectedGender { get; set; }

        public IEnumerable<string> GenderNames { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at leats {2} and max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password must be contain ")]
        public string ConfirmPassword { get; set;}

        
        
    }
}
