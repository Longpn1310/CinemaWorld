using CinemaWorld.Services.Services.Data.Mapping;

namespace CinemaWorld.ViewModels.News
{
    using News = CinemaWorld.Models.News;
    public class TopNewsViewModel : IMapFrom<News>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedOnBefore => (int)Math.Round((DateTime.UtcNow - this.CreatedOn).TotalHours);

        public string UserUserName { get; set; }

        public int ViewsCounter { get; set; }
    }
}
