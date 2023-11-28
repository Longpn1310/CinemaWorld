using CinemaWorld.InputModels.Tickets;

namespace CinemaWorld.ViewModels.MovieProjections
{
    public class MovieProjectionViewModel
    {
        public MovieProjectionDetailsViewModel MovieProjection { get; set; }

        public IEnumerable<string> SoldSeats { get; set; }

        public IEnumerable<string> AvailableSeats { get; set; }

        public TicketInputModel Ticket { get; set; }    

        public object ChoosenSeats { get; set; }
    }
}
