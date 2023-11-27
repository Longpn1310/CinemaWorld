
using CinemaWorld.Services.Services.Data.Mapping;
using static CinemaWorld.Global.Common.ModelValidation.Privacy;

namespace CinemaWorld.ViewModels.Privacy
{
    using CinemaWorld.Models;
    using Ganss.Xss;
    using System.ComponentModel.DataAnnotations;

    public class PrivacyDetailsViewModel : IMapFrom<Privacy>
    {
        public int Id { get; set; }

        [Display(Name = PageContentDisplayName)]
        public string PageContent { get; set; }

        public string SanitizedPageContent => new HtmlSanitizer().Sanitize(this.PageContent);
    }
}
