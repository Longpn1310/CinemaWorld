using CinemaWorld.Global.Common.Atrributes;
using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Global.Common.ModelValidation;
using static CinemaWorld.Global.Common.ModelValidation.News;
namespace CinemaWorld.InputModels.AdministratorInputModels.News
{
    public class NewsCreateInputModel
    {
        [Required(ErrorMessage = EmptyFieldLengthError)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = TitleLengthError)]
        public string Title { get; set; }

        [Required(ErrorMessage = EmptyFieldLengthError)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = DescriptionLengthError)]
        public string Description { get; set; }

        [Required(ErrorMessage = EmptyFieldLengthError)]
        [Display(Name = ShortDescriptionDisplayName)]
        [StringLength(ShortDescriptionMaxLength, MinimumLength = ShortDescriptionMinLength, ErrorMessage = ShortDescriptionLengthError)]
        public string ShortDescription { get; set; }

        [DataType(DataType.Url)]
        [StringLength(ImagePathMaxLength, MinimumLength = ImagePathMinLength, ErrorMessage = ImagePathLengthError)]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = EmptyFieldLengthError)]
        [DataType(DataType.Upload)]
        [MaxFileSize(ImageMaxSize)]
        [AllowedExtensionAttribute]
        public IFormFile Image { get; set; }
    }
}
