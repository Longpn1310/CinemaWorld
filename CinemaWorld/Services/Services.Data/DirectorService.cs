using CinemaWorld.Global.Common;
using CinemaWorld.Global.Common.Repositories;
using CinemaWorld.InputModels.AdministratorInputModels.Directors;
using CinemaWorld.Models;
using CinemaWorld.Services.Services.Data.Contracts;
using CinemaWorld.Services.Services.Data.Mapping;
using CinemaWorld.ViewModels.Directories;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace CinemaWorld.Services.Services.Data
{
    public class DirectorService : IDirectorService
    {
        private readonly IDeletableEntityRepository<Director> directorsRepository;

        public DirectorService(IDeletableEntityRepository<Director> directorsRepository)
        {
            this.directorsRepository = directorsRepository;
        }

            public async Task<DirectorDetailsViewModel> CreateAsync(DirectorCreateInputModel directorCreateInputModel)
        {
            var director = new Director
            {
                FirstName = directorCreateInputModel.FirstName,
                LastName = directorCreateInputModel.LastName,
            };
            bool doesDirectorExist = await this.directorsRepository
                .All()
                .AnyAsync(x => x.FirstName == director.FirstName && x.LastName == director.LastName);
            if(doesDirectorExist)
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.DirectorAlreadyExists, director.FirstName, director.LastName));
            }

            await this.directorsRepository.AddAsync(director);  
            await this.directorsRepository .SaveChangesAsync();

            var viewModel = await this.GetViewModelByIdAsync<DirectorDetailsViewModel>(director.Id);

            return viewModel;
        }

        public async Task DeleteByIdAsync(int id)
        {
           var director = this.directorsRepository.All().FirstOrDefault(x => x.Id == id);
            if(director == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.DirectorNotFound, id));    
            }
           director.IsDeleted = true;
           director.DeletedOn = DateTime.UtcNow;
           this.directorsRepository.Update(director);
           await this.directorsRepository.SaveChangesAsync();
        }

        public async Task EditAsync(DirectorEditViewModel directorEditViewModel)
        {
            var director = this.directorsRepository.All().FirstOrDefault(x => x.Id == directorEditViewModel.Id);
            if(director == null )
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.DirectorNotFound, directorEditViewModel.Id));
            }

            director.FirstName = directorEditViewModel.FirstName;
            director.LastName = directorEditViewModel.LastName;
            director.ModifiedOn = DateTime.UtcNow;

            this.directorsRepository.Update(director);
            await directorsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TViewModel>> GetAllDirectorsAsync<TViewModel>()
        {
            var directors = await this.directorsRepository
                .All()
                .OrderBy(x => x.FirstName)
                .To<TViewModel>()
                .ToListAsync();

            return directors;
        }

        public async Task<TViewModel> GetViewModelByIdAsync<TViewModel>(int id)
        {
            var director = await this.directorsRepository
                .All()
                .Where(x => x.Id == id)
                .To<TViewModel>()
                .FirstOrDefaultAsync();

            if(director == null) {
            throw new NullReferenceException(string.Format(ExceptionMessages.DirectorNotFound, id));
            }

            return director;
        }
    }
}
