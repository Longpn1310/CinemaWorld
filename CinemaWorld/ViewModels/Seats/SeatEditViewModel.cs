using static CinemaWorld.Global.Common.ModelValidation;
using static CinemaWorld.Global.Common.ModelValidation.Seat;
using static CinemaWorld.Global.Common.ModelValidation.Hall;

namespace CinemaWorld.ViewModels.Seats
{
    using CinemaWorld.Models;
    using CinemaWorld.Services.Services.Data.Mapping;
    using CinemaWorld.ViewModels.ViewModels.Halls;
    using System.ComponentModel.DataAnnotations;

    public class SeatEditViewModel : IMapFrom<Seat>
    {
        public int Id { get; set; }

        [Display(Name = NumberDisplayName)]
        [Range(1, int.MaxValue, ErrorMessage = SeatNumberIdError)]
        public int Number { get; set; }

        [Display(Name = RowNumberDisplayName)]
        [Range(1, int.MaxValue, ErrorMessage = RowNumberIdError)]
        public int RowNumber { get; set; }

        [Display(Name = nameof(Hall))]
        [Range(1, int.MaxValue, ErrorMessage = HallIdError)]
        public int HallId { get; set; }

        public IEnumerable<HallDetailsViewModel> Halls { get; set; }

        public string Category { get; set; }
    }
}
