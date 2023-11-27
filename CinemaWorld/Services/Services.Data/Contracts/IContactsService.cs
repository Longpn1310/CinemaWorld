using CinemaWorld.InputModels.Contacts;
using CinemaWorld.Services.Services.Data.Contract;

namespace CinemaWorld.Services.Services.Data.Contracts
{
    public interface IContactsService
    {
        Task SendContactToAdmin(ContactFormEntryViewModel contactFormEntryViewModel);

        Task SendContactToUser(SendContactInputModel sendContactInputModel);

        Task<IEnumerable<TEntity>> GetAllUserEmailsAsync<TEntity>();
    }
}
