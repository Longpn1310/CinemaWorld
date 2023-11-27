using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Global.Common.ModelValidation.Privacy;
using static CinemaWorld.Global.Common.ModelValidation;
namespace CinemaWorld.InputModels.Privacy
{
    public class PrivacyCreateInputModel 
    {

        [Display(Name = PageContentDisplayName)]
        [Required(ErrorMessage = EmptyFieldLengthError)]
        [StringLength(PageContentMaxLength, MinimumLength = PageContentMinLength, ErrorMessage = PageContentLengthError)]
        public string PageContent { get; set; }
    }
}
