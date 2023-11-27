using CinemaWorld.Global.Common;
using CinemaWorld.Global.Common.Repositories;
using CinemaWorld.InputModels.AdministratorInputModels.Seats;
using CinemaWorld.Models;
using CinemaWorld.Models.Enumerations;
using CinemaWorld.Services.Services.Data.Contracts;
using CinemaWorld.Services.Services.Data.Mapping;
using CinemaWorld.ViewModels.Seats;
using Microsoft.EntityFrameworkCore;

namespace CinemaWorld.Services.Services.Data
{
    public class SeatsService : ISeatsService
    {
        private const int SeatsPerRowCount = 10;

        private readonly IDeletableEntityRepository<Seat> seatsRepository;
        private readonly IDeletableEntityRepository<Hall> hallsRepository;

        public SeatsService(
            IDeletableEntityRepository<Seat> seatsRepository,
            IDeletableEntityRepository<Hall> hallsRepository)
        {
            this.seatsRepository = seatsRepository;
            this.hallsRepository = hallsRepository;
        }

        public async Task<SeatDetailsViewModel> CreateAsync(SeatCreateInputModel seatCreateInputModel)
        {
            if (!Enum.TryParse(seatCreateInputModel.Category, true, out SeatCategory seatCategory))
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.InvalidSeatCategoryType, seatCreateInputModel.Category));
            }

            var hall = await hallsRepository
                .All()
                .FirstOrDefaultAsync(d => d.Id == seatCreateInputModel.HallId);

            if (hall == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.HallNotFound, seatCreateInputModel.HallId));
            }

            var seat = new Seat
            {
                Number = seatCreateInputModel.Number,
                RowNumber = seatCreateInputModel.RowNumber,
                Category = seatCategory,
                IsAvailable = true,
                Hall = hall,
            };

            bool doesSeatExist = await seatsRepository
                .All()
                .AnyAsync(x => x.Number == seat.Number && x.RowNumber == seat.RowNumber);
            if (doesSeatExist)
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.SeatAlreadyExists, seat.Number, seat.RowNumber));
            }

            await seatsRepository.AddAsync(seat);
            await seatsRepository.SaveChangesAsync();

            var viewModel = await GetViewModelByIdAsync<SeatDetailsViewModel>(seat.Id);

            return viewModel;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var seat = await seatsRepository.All().FirstOrDefaultAsync(x => x.Id == id);
            if (seat == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.SeatNotFound, id));
            }

            seat.IsDeleted = true;
            seat.DeletedOn = DateTime.UtcNow;
            seatsRepository.Update(seat);
            await seatsRepository.SaveChangesAsync();
        }

        public async Task EditAsync(SeatEditViewModel seatEditViewModel)
        {
            if (!Enum.TryParse(seatEditViewModel.Category, true, out SeatCategory seatCategory))
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.InvalidSeatCategoryType, seatEditViewModel.Category));
            }

            var seat = await seatsRepository
                .All()
                .FirstOrDefaultAsync(g => g.Id == seatEditViewModel.Id);

            if (seat == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.SeatNotFound, seatEditViewModel.Id));
            }

            var hall = await hallsRepository
                .All()
                .FirstOrDefaultAsync(h => h.Id == seatEditViewModel.HallId);

            if (hall == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.HallNotFound, seatEditViewModel.HallId));
            }

            seat.Number = seatEditViewModel.Number;
            seat.RowNumber = seatEditViewModel.RowNumber;
            seat.HallId = seatEditViewModel.HallId;
            seat.Category = seatCategory;
            seat.ModifiedOn = DateTime.UtcNow;

            seatsRepository.Update(seat);
            await seatsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TViewModel>> GetAllSeatsAsync<TViewModel>()
        {
            var seats = await seatsRepository
                .All()
                .OrderBy(x => x.Number)
                .ThenBy(x => x.RowNumber)
                .To<TViewModel>()
                .ToListAsync();

            return seats;
        }

        public async Task<IEnumerable<string>> GetAllSoldSeatsAsync(int hallId)
        {
            var soldSeats = await seatsRepository
                .All()
                .Where(x => x.IsSold == true && x.HallId == hallId)
                .Select(x => x.RowNumber.ToString() + "_" + x.Number.ToString())
                .ToListAsync();

            return soldSeats;
        }

        public async Task<IEnumerable<string>> GetAllAvailableSeatsAsync(int hallId)
        {
            var availableSeats = await seatsRepository
                .All()
                .Where(x => x.IsAvailable == true && x.HallId == hallId)
                .ToListAsync();

            var seatMap = new List<string>();
            var seatsCount = availableSeats.Count;
            int numberOfRows = 0;

            while (seatsCount > 10)
            {
                seatsCount -= 10;
                numberOfRows++;
            }

            // Fill full rows
            for (int i = 0; i < numberOfRows; i++)
            {
                string currentRow = string.Empty;
                for (int j = 0; j < SeatsPerRowCount; j++)
                {
                    currentRow += "a";
                }

                seatMap.Add(currentRow);
            }

            // Fill other seats in order to present a full seat map
            string row = string.Empty;
            for (int i = 0; i < SeatsPerRowCount; i++)
            {
                row += "a";
            }

            seatMap.Add(row);
            return seatMap;
        }

        public IQueryable<TViewModel> GetAllSeatsAsQueryeable<TViewModel>()
        {
            var seats = seatsRepository
                .All()
                .To<TViewModel>();

            return seats;
        }

        public async Task<TViewModel> GetViewModelByIdAsync<TViewModel>(int id)
        {
            var seatViewModel = await seatsRepository
                .All()
                .Where(s => s.Id == id)
                .To<TViewModel>()
                .FirstOrDefaultAsync();

            if (seatViewModel == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.SeatNotFound, id));
            }

            return seatViewModel;
        }
    }
}
