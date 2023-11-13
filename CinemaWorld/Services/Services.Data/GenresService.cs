namespace CinemaWorld.Services.Services.Data
{
    using CinemaWorld.Global.Common;
    using CinemaWorld.Global.Common.Repositories;
    using CinemaWorld.InputModels.AdministratorInputModels.Genres;
    using CinemaWorld.Models;
    using CinemaWorld.Services.Services.Data.Contracts;
    using CinemaWorld.ViewModels.ViewModels.Genre;
    using CinemaWorld.ViewModels.ViewModels.Genres;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper.QueryableExtensions;
    using CinemaWorld.Services.Services.Data.Mapping;

    public class GenresService : IGenresService
    {
        private readonly IDeletableEntityRepository<Genre> genresRepository;
        
        public GenresService(IDeletableEntityRepository<Genre> genresRepository)
        {
            this.genresRepository = genresRepository;
        }

        //Tạo mới một dữ liệu đầu vào của GenreInput
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

        //Xoá dựa trên Id
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

        //Chỉnh sửa
        public async Task EditAsync(GenreEditViewModel genreEditViewModel)
        {
            var genre = await this.genresRepository.All().FirstOrDefaultAsync( g => g.Id == genreEditViewModel.Id);
            if(genre == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.GenreNotFound, genreEditViewModel.Id));
            }
            genre.Name = genreEditViewModel.Name;
            genre.ModifiedOn = DateTime.UtcNow;

            this.genresRepository.Update(genre);
            await this.genresRepository.SaveChangesAsync();
        }
        //Trả về tất cả các thể loại
        public async Task<IEnumerable<TViewModel>> GetAllGenresAsync<TViewModel>()
        {
            var genres = await this.genresRepository
                .All()
                .OrderBy(x => x.Name)
                .To<TViewModel>()
                .ToListAsync();

            return genres;
        }

        public async Task<TViewModel> GetViewModelByIdAsync<TViewModel>(int id)
        {
            var genreViewModel = await this.genresRepository
                .All()
                .Where(m => m.Id == id)
                .To<TViewModel>()
                .FirstOrDefaultAsync();
            if(genresRepository == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.GenreNotFound, id));
            }
            return genreViewModel;
        }   
    }
}
