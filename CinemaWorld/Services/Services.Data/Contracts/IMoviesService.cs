using CinemaWorld.InputModels.AdministratorInputModels.Movies;
using CinemaWorld.ViewModels.ViewModels.Movies;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWorld.Services.Services.Data.Contract
{
    public interface IMoviesService : IBaseDataService
    {
        Task<MovieDetailsViewModel> CreateAsync(MovieCreateInputModel movieCreateInputModel);

        //Iqueryable khong thuc hien ngay lap tuc ma doi den khi ket qua cu the duoc yeu cau
        //  
        IQueryable<TViewModel> GetAllMoviesAsQueryeable<TViewModel>();
    }
}
