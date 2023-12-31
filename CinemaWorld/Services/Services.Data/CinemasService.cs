﻿using CinemaWorld.Global.Common;
using CinemaWorld.Global.Common.Repositories;
using CinemaWorld.InputModels.AdministratorInputModels.Cinemas;
using CinemaWorld.Models;
using CinemaWorld.Services.Services.Data.Contracts;
using CinemaWorld.Services.Services.Data.Mapping;
using CinemaWorld.ViewModels.ViewModels.Cinemas;
using Microsoft.EntityFrameworkCore;

namespace CinemaWorld.Services.Services.Data
{
    public class CinemasService : ICinemasService
    {
        private readonly IDeletableEntityRepository<Cinema> cinemasRepository;

        public CinemasService(IDeletableEntityRepository<Cinema> cinemasRepository)
        {
            this.cinemasRepository = cinemasRepository;
        }

        public async Task<CinemaDetailsViewModel> CreateAsync(CinemaCreateInputModel cinemaCreateInputModel)
        {
            var cinema = new Cinema
            {
                Name = cinemaCreateInputModel.Name,
                Address = cinemaCreateInputModel.Address,
            };

            bool doesCinemaExists = await this.cinemasRepository.All().AnyAsync(x => x.Name == cinema.Name);
            if (doesCinemaExists)
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.CinemaAlreadyExists, cinema.Name, cinema.Address));
            }

            await this.cinemasRepository.AddAsync(cinema);
            await this.cinemasRepository.SaveChangesAsync();

            var viewModel = await this.GetViewModelByIdAsync<CinemaDetailsViewModel>(cinema.Id);

            return viewModel;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var cinema = this.cinemasRepository.All().FirstOrDefault(x => x.Id == id);
            if (cinema == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.CinemaNotFound, id));
            }

            cinema.IsDeleted = true;
            cinema.DeletedOn = DateTime.UtcNow;
            this.cinemasRepository.Update(cinema);
            await this.cinemasRepository.SaveChangesAsync();
        }

        public async Task EditAsync(CinemaEditViewModel cinemaEditViewModel)
        {
            var cinema = this.cinemasRepository.All().FirstOrDefault(g => g.Id == cinemaEditViewModel.Id);

            if (cinema == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.CinemaNotFound, cinemaEditViewModel.Id));
            }

            cinema.Name = cinemaEditViewModel.Name;
            cinema.Address = cinemaEditViewModel.Address;
            cinema.ModifiedOn = DateTime.UtcNow;

            this.cinemasRepository.Update(cinema);
            await this.cinemasRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TViewModel>> GetAllCinemasAsync<TViewModel>()
        {
            var cinemas = await this.cinemasRepository
                .All()
                .OrderBy(x => x.Name)
                .To<TViewModel>()
                .ToListAsync();

            return cinemas;
        }

        public async Task<TViewModel> GetViewModelByIdAsync<TViewModel>(int id)
        {
            var cinemaViewModel = await this.cinemasRepository
                .All()
                .Where(m => m.Id == id)
                .To<TViewModel>()
                .FirstOrDefaultAsync();

            if (cinemaViewModel == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CinemaNotFound, id));
            }

            return cinemaViewModel;
        }
    }
}