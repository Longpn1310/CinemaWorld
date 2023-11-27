using CinemaWorld.InputModels.AdministratorInputModels.Halls;
using CinemaWorld.Services.Services.Data.Contract;
using CinemaWorld.ViewModels.Halls;
using CinemaWorld.ViewModels.ViewModels.Halls;

namespace CinemaWorld.Services.Services.Data.Contracts
{
    public interface IHallsService : IBaseDataService
    {
        Task<HallDetailsViewModel> CreateAsync(HallCreateInputModel hallCreateInputModel);

        Task EditAsync(HallEditViewModel hallEditViewModel);

        Task<IEnumerable<TViewModel>> GetAllHallsAsync<TViewModel>();
    }
}
