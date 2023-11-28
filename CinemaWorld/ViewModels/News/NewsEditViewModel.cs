using CinemaWorld.Global.Common.Atrributes;
using CinemaWorld.Services.Services.Data.Mapping;
using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Global.Common.ModelValidation;
using static CinemaWorld.Global.Common.ModelValidation.News;
namespace CinemaWorld.ViewModels.News
{
    using News = CinemaWorld.Models.News;
    public class NewsEditViewModel : IMapFrom<News>
    {
        public int Id { get; set; }

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

        [DataType(DataType.Upload)]
        [MaxFileSize(ImageMaxSize)]
        [AllowedExtension]
        [Display(Name = NewImageDisplayName)]
        public IFormFile Image { get; set; }
    }
}
