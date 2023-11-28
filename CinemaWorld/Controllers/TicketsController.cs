using CinemaWorld.Services.Services.Data.Contracts;
using CinemaWorld.ViewModels.MovieProjections;
using CinemaWorld.ViewModels.ViewModels.MovieProjections;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWorld.Controllers
{
    public class TicketsController : Controller
    {
        private readonly IMovieProjectionsService movieProjectionsService;
        private readonly ITicketsService ticketsService;
        private readonly ISeatsService seatsService;

        public TicketsController(IMovieProjectionsService movieProjectionsService, ITicketsService ticketsService, ISeatsService seatsService)
        {
            this.movieProjectionsService = movieProjectionsService;
            this.ticketsService = ticketsService;
            this.seatsService = seatsService;
        }
        [Authorize]

        public async Task<IActionResult> Book(int id)
        {
            var movieProjection = await this.movieProjectionsService
                .GetViewModelByIdAsync<MovieProjectionDetailsViewModel>(id);

            var soldSeats = await this.seatsService.GetAllSoldSeatsAsync(movieProjection.Hall.Id);
            var availableSeats = await this.seatsService.GetAllAvailableSeatsAsync(movieProjection.Hall.Id);

            var viewModel = new MovieProjectionViewModel
            {
                MovieProjection = movieProjection,
                SoldSeats = soldSeats,
                AvailableSeats = availableSeats,
            };
            return this.View(viewModel);
        }
    }
}
