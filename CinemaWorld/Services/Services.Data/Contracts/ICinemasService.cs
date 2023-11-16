using CinemaWorld.InputModels.AdministratorInputModels.Cinemas;
using CinemaWorld.Services.Services.Data.Contract;
using CinemaWorld.ViewModels.ViewModels.Cinemas;

namespace CinemaWorld.Services.Services.Data.Contracts
{
    public interface ICinemasService : IBaseDataService
    {
        Task<CinemaDetailsViewModel> CreateAsync(CinemaCreateInputModel cinemaCreateInputModel);

        Task EditAsync(CinemaEditViewModel cinemaEditViewModel);

        Task<IEnumerable<TEntity>> GetAllCinemasAsync<TEntity>();
    }
}
