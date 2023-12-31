﻿using CinemaWorld.Global.Common;
using CinemaWorld.Global.Common.Repositories;
using CinemaWorld.InputModels.AdministratorInputModels.Halls;
using CinemaWorld.Models;
using CinemaWorld.Models.Enumerations;
using CinemaWorld.Services.Services.Data.Contracts;
using CinemaWorld.Services.Services.Data.Mapping;
using CinemaWorld.ViewModels.Halls;
using CinemaWorld.ViewModels.ViewModels.Halls;
using Microsoft.EntityFrameworkCore;

namespace CinemaWorld.Services.Services.Data
{
    public class HallsService : IHallsService
    {
        private readonly IDeletableEntityRepository<Hall> hallsRepository;

        public HallsService(IDeletableEntityRepository<Hall> hallsRepository)
        {
            this.hallsRepository = hallsRepository;
        }

        public async Task<HallDetailsViewModel> CreateAsync(HallCreateInputModel hallCreateInputModel)
        {
            if (!Enum.TryParse(hallCreateInputModel.Category, true, out HallCategory hallCategory))
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.InvalidHallCategoryType, hallCreateInputModel.Category));
            }

            var hall = new Hall
            {
                Category = hallCategory,
                Capacity = hallCreateInputModel.Capacity,
            };

            bool doesHallExist = await this.hallsRepository
                .All()
                .AnyAsync(x => x.Category == hall.Category && x.Capacity == hall.Capacity);
            if (doesHallExist)
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.HallAlreadyExists, hall.Category, hall.Capacity));
            }

            await this.hallsRepository.AddAsync(hall);
            await this.hallsRepository.SaveChangesAsync();

            var viewModel = await this.GetViewModelByIdAsync<HallDetailsViewModel>(hall.Id);

            return viewModel;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var hall = await this.hallsRepository.All().FirstOrDefaultAsync(x => x.Id == id);
            if (hall == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.HallNotFound, id));
            }

            hall.IsDeleted = true;
            hall.DeletedOn = DateTime.UtcNow;
            this.hallsRepository.Update(hall);
            await this.hallsRepository.SaveChangesAsync();
        }

        public async Task EditAsync(HallEditViewModel hallEditViewModel)
        {
            if (!Enum.TryParse(hallEditViewModel.Category, true, out HallCategory hallCategory))
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.InvalidHallCategoryType, hallEditViewModel.Category));
            }

            var hall = await this.hallsRepository.All().FirstOrDefaultAsync(g => g.Id == hallEditViewModel.Id);

            if (hall == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.HallNotFound, hallEditViewModel.Id));
            }

            hall.Category = hallCategory;
            hall.Capacity = hallEditViewModel.Capacity;
            hall.ModifiedOn = DateTime.UtcNow;

            this.hallsRepository.Update(hall);
            await this.hallsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TViewModel>> GetAllHallsAsync<TViewModel>()
        {
            var halls = await this.hallsRepository
                .All()
                .To<TViewModel>()
                .ToListAsync();

            return halls;
        }

        public async Task<TViewModel> GetViewModelByIdAsync<TViewModel>(int id)
        {
            var hallViewModel = await this.hallsRepository
                .All()
                .Where(m => m.Id == id)
                .To<TViewModel>()
                .FirstOrDefaultAsync();

            if (hallViewModel == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.HallNotFound, id));
            }

            return hallViewModel;
        }
    }
}
