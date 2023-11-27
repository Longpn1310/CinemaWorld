using CinemaWorld.InputModels.Tickets;
using CinemaWorld.Services.Services.Data.Contract;
using CinemaWorld.ViewModels.Tickets;

namespace CinemaWorld.Services.Services.Data.Contracts
{
    public interface ITicketsService : IBaseDataService
    {
        Task<TicketDetailsViewModel> BuyAsync(TicketInputModel ticket, int movieProjectionId);
    }
}
