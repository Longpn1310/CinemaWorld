using static CinemaWorld.Global.Common.ModelValidation;
using static CinemaWorld.Global.Common.ModelValidation.Seat;

namespace CinemaWorld.ViewModels.Seats
{
    using CinemaWorld.Models;
    using CinemaWorld.Models.Enumerations;
    using CinemaWorld.Services.Services.Data.Mapping;
    using CinemaWorld.ViewModels.ViewModels.Halls;
    using System.ComponentModel.DataAnnotations;
    public class SeatDetailsViewModel : IMapFrom<Seat>
    {
        public int Id { get; set; }

        [Display(Name = NumberDisplayName)]
        public int Number { get; set; }

        [Display(Name = RowNumberDisplayName)]
        public int RowNumber { get; set; }

        [Display(Name = HallIdDisplayName)]
        public HallDetailsViewModel Hall { get; set; }

        public SeatCategory Category { get; set; }

        [Display(Name = IsAvailableDisplayName)]
        public bool IsAvailable { get; set; }

        [Display(Name = IsSoldDisplayName)]
        public bool IsSold { get; set; }
    }
}
