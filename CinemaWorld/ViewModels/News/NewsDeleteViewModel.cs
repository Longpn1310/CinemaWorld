using CinemaWorld.Services.Services.Data.Mapping;
using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Global.Common.ModelValidation.News;
namespace CinemaWorld.ViewModels.News
{
    using News = CinemaWorld.Models.News;
    public class NewsDeleteViewModel : IMapFrom<News>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        [Display(Name = CreationDateDisplayName)]
        public string CreationDate => this.CreatedOn.ToShortDateString();

        [Display(Name = ImagePathDisplayName)]
        public string ImagePath { get; set; }
    }
}
