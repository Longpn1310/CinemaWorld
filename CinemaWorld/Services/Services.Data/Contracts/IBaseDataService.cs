namespace CinemaWorld.Services.Services.Data.Contract
{
    public interface IBaseDataService
    {
        Task<TViewModel> GetViewModelByIdAsync<TViewModel>(int id);

        Task DeleteByIdAsync(int id);
    }
}
