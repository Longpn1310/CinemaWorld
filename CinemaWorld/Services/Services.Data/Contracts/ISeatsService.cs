using CinemaWorld.InputModels.AdministratorInputModels.Seats;
using CinemaWorld.Services.Services.Data.Contract;
using CinemaWorld.ViewModels.Seats;

namespace CinemaWorld.Services.Services.Data.Contracts
{
    public interface ISeatsService : IBaseDataService
    {
        Task<SeatDetailsViewModel> CreateAsync(SeatCreateInputModel seatCreateInputModel);

        Task EditAsync(SeatEditViewModel seatEditViewModel);

        Task<IEnumerable<TViewModel>> GetAllSeatsAsync<TViewModel>();

        Task<IEnumerable<string>> GetAllSoldSeatsAsync(int hallId);

        Task<IEnumerable<string>> GetAllAvailableSeatsAsync(int hallId);

        IQueryable<TViewModel> GetAllSeatsAsQueryeable<TViewModel>();
    }
}
