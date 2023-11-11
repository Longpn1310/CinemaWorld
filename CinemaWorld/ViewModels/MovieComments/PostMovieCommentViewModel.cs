using CinemaWorld.Models;
using CinemaWorld.ViewModels.Mapping;
using Ganss.Xss;

namespace CinemaWorld.ViewModels.MovieComments
{
    public class PostMovieCommentViewModel : IMapFrom<MovieComment>
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Content { get ; set; }
        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public DateTime CreatedOn { get; set; }
        public string UserUserName { get; set; }

        public string UserFullName { get; set; }
    }
}
