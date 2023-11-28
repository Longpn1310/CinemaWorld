namespace CinemaWorld.ViewModels.News
{
    public class NewsIndexViewModel
    {
        public PaginatedList<AllNewsListingViewModel> News { get; set; }

        public IEnumerable<UpdatedNewsDetailsViewModel> UpdatedNews { get; set; }

        public IEnumerable<TopNewsViewModel> TopNews { get; set; }
    }
}
