using CinemaWorld.InputModels.AdministratorInputModels.News;
using CinemaWorld.Services.Services.Data.Contract;
using CinemaWorld.ViewModels.News;

namespace CinemaWorld.Services.Services.Data.Contracts
{
    public interface INewsService : IBaseDataService
    {
        Task<AllNewsListingViewModel> CreateAsync(NewsCreateInputModel newsCreateInputModel, string userId);

        Task EditAsync(NewsEditViewModel newsEditViewModel, string userId);

        Task<IEnumerable<TEntity>> GetAllNewsAsync<TEntity>();

        IQueryable<TViewModel> GetAllNewsAsQueryeable<TViewModel>();

        Task<IEnumerable<TViewModel>> GetTopNewsAsync<TViewModel>(int count = 0);

        Task<IEnumerable<TViewModel>> GetUpdatedNewsAsync<TViewModel>();

        Task<NewsDetailsViewModel> SetViewsCounter(int id);
    }
}
