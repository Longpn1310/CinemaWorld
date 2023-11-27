using CinemaWorld.Models;
using CinemaWorld.Services.Services.Data.Mapping;

namespace CinemaWorld.ViewModels.Genres
{
    public class NavbarGenreViewModel : IMapFrom<Genre>
    {
        public string Name { get; set; }
    }
}
