using CinemaWorld.InputModels.Countries;
using CinemaWorld.Services.Services.Data.Contract;
using CinemaWorld.ViewModels.ViewModels.Countries;

namespace CinemaWorld.Services.Services.Data.Contracts
{
    public interface ICountriesService : IBaseDataService
    {
        Task<CountryDetailsViewModel> CreateAsync(CountryCreateInputModel countryCreateInputModel);

        Task EditAsync(CountryEditViewModel countryEditViewModel);

        Task<IEnumerable<TEntity>> GetAllCountriesAsync<TEntity>();
    }
}
