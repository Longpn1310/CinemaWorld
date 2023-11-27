using Ganss.Xss;

namespace CinemaWorld.ViewModels.NewsComments
{
    public class PostNewsCommentViewModel
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public DateTime CreatedOn { get; set; }

        public string UserUserName { get; set; }

        public string UserFullName { get; set; }
    }
}
