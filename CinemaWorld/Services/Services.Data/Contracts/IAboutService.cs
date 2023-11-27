using CinemaWorld.InputModels.About;
using CinemaWorld.Services.Services.Data.Contract;
using CinemaWorld.Services.Services.Data.Mappings;
using CinemaWorld.ViewModels.About;

namespace CinemaWorld.Services.Services.Data.Contracts
{
    public interface IAboutService : IBaseDataService
    {
        Task<FaqDetailsViewModel> CreateAsync(FaqCreateInputModel faqCreateInputModel);

        Task EditAsync(FaqEditViewModel faqEditViewModel);

        Task<IEnumerable<TEntity>> GetAllFaqsAsync<TEntity>();
    }
}
