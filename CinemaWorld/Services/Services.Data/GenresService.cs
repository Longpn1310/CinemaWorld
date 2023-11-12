using CinemaWorld.Global.Common;
using CinemaWorld.Global.Common.Repositories;
using CinemaWorld.InputModels.AdministratorInputModels.Genres;
using CinemaWorld.Models;
using CinemaWorld.Services.Services.Data.Contracts;
using CinemaWorld.ViewModels.ViewModels.Genre;
using Microsoft.EntityFrameworkCore;

namespace CinemaWorld.Services.Services.Data
{
    public class GenresService : IGenresService
    {
        private readonly IDeletableEntityRepository<Genre> genresRepository;
        
        public GenresService(IDeletableEntityRepository<Genre> genresRepository)
        {
            this.genresRepository = genresRepository;
        }

        public async Task<GenreDetailsViewModel> CreateAsync(GenreCreateInputModel genreCreateInputModel)
        {
            var genre = new Genre
            {
                Name = genreCreateInputModel.Name,
            };
            bool doesGenreExist = await this.genresRepository
                .All()
                .AnyAsync(x => x.Name == genre.Name);
            if(doesGenreExist)
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.GenreAlreadyExists, genre.Name));
            }
            await this.genresRepository.AddAsync(genre);
            await this.genresRepository.SaveChangesAsync();

            var viewModel = await this.GetViewModelByIdAsync<GenreDetailsViewModel>(genre.Id);
            return viewModel;
        }

        public Task<GenreDetailsViewModel> CreateAsync(GenreDetailsViewModel genreDetailsViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var genre = await this.genresRepository.All().FirstOrDefaultAsync(x => x.Id == id);
            if(genre == null)
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.GenreNotFound, id));
            }
            genre.IsDeleted = true;
            genre.DeletedOn = DateTime.Now;
            this.genresRepository.Update(genre);
            await this.genresRepository.SaveChangesAsync();
        }

        public Task EditAsync(GenreDetailsViewModel genreDetailsViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAllGenresAsync<TEntity>()
        {
            throw new NotImplementedException();
        }

        public Task<TViewModel> GetViewModelByIdAsync<TViewModel>(int id)
        {
            throw new NotImplementedException();
        }
    }
}
