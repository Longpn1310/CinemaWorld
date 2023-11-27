using CinemaWorld.InputModels.Privacy;
using CinemaWorld.Services.Services.Data.Contract;
using CinemaWorld.ViewModels.Privacy;

namespace CinemaWorld.Services.Services.Data.Contracts
{
    public interface IPrivacyService : IBaseDataService
    {
        Task<PrivacyDetailsViewModel> CreateAsync(PrivacyCreateInputModel privacyCreateInputModel);

        Task EditAsync(PrivacyEditViewModel privacyEditViewModel);

        Task<TViewModel> GetViewModelAsync<TViewModel>();
    }
}
