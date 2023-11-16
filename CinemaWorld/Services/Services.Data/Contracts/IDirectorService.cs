using CinemaWorld.InputModels.AdministratorInputModels.Directors;
using CinemaWorld.Services.Services.Data.Contract;
using CinemaWorld.ViewModels.Directories;

namespace CinemaWorld.Services.Services.Data.Contracts
{
    public interface IDirectorService : IBaseDataService
    {
        Task<DirectorDetailsViewModel> CreateAsync(DirectorCreateInputModel directorCreateInputModel);

        Task EditAsync(DirectorEditViewModel directorEditViewModel);

        Task<IEnumerable<TViewModel>> GetAllDirectorsAsync<TViewModel>();   
    }
}
