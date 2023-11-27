using CinemaWorld.Models;
using CinemaWorld.Models.Enumerations;
using CinemaWorld.Services.Services.Data.Mapping;

namespace CinemaWorld.ViewModels.Tickets
{
    public class TicketDetailsViewModel : IMapFrom<Ticket>
    {
        public int Row { get; set; }

        public int Seat { get; set; }

        public decimal Price { get; set; }

        public TimeSlot TimeSlot { get; set; }

        public TicketType TicketType { get; set; }

        public int Quantity { get; set; }
    }
}
