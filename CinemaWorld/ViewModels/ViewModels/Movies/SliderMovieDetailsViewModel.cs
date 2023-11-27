using CinemaWorld.Models;
using CinemaWorld.Services.Services.Data.Mapping;

namespace CinemaWorld.ViewModels.ViewModels.Movies
{
    public class SliderMovieDetailsViewModel : IMapFrom<Movie>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ShortDescription
        {
            get
            {
                var shortDescription = this.Description;
                return shortDescription.Length > 400
                        ? shortDescription.Substring(0, 400) + " ..."
                        : shortDescription;
            }
        }

        public string WallpaperPath { get; set; }
    }
}
