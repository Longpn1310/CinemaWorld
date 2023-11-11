namespace CinemaWorld.Services.Services.Data.Contract
{
    public interface IBaseDataService
    {
        Task<TViewModel> GetViewModelByIdSync<TViewModel>(int id);

        Task DeleteByIdAsync(int id);
    }
}
