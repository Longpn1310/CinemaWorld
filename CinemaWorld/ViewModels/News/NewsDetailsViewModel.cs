
namespace CinemaWorld.ViewModels.News
{
    using CinemaWorld.Services.Services.Data.Mapping;
    using CinemaWorld.Data.Models;
    using CinemaWorld.Models;
    using Ganss.Xss;
    using CinemaWorld.ViewModels.NewsComments;

    public class NewsDetailsViewModel : IMapFrom<News>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string SanitizedDescription => new HtmlSanitizer().Sanitize(this.Description);

        public DateTime CreatedOn { get; set; }

        public string UserUserName { get; set; }

        public string ImagePath { get; set; }

        public int ViewsCounter { get; set; }

        public IEnumerable<PostNewsCommentViewModel> NewsComments { get; set; }
    }
}
