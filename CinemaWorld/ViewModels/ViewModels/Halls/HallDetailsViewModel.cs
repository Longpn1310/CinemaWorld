using CinemaWorld.Models;
using CinemaWorld.Models.Enumerations;
using CinemaWorld.Services.Services.Data.Mapping;

namespace CinemaWorld.ViewModels.ViewModels.Halls
{
    public class HallDetailsViewModel :IMapFrom<Hall>
    {
        public int Id { get; set; }

        public HallCategory Category { get; set; }

        public int Capacity { get; set; }
    }
}
