using CinemaWorld.Models;
using CinemaWorld.Services.Services.Data.Mapping;
using Ganss.Xss;

namespace CinemaWorld.ViewModels.About
{
    public class FaqDetailsViewModel : IMapFrom<FaqEntry>
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

        public string SanitizedAnswer => new HtmlSanitizer().Sanitize(this.Answer);
    }
}
