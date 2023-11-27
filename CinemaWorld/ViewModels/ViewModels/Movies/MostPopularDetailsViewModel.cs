using AutoMapper;
using CinemaWorld.Models;
using CinemaWorld.Services.Services.Data.Mapping;
using CinemaWorld.ViewModels.Directories;

namespace CinemaWorld.ViewModels.ViewModels.Movies
{
    public class MostPopularDetailsViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfRelease { get; set; }

        public string OnlyDate => this.DateOfRelease.ToShortDateString();

        public string Resolution { get; set; }

        public string Description { get; set; }

        public string ShortDescription
        {
            get
            {
                var shortDescription = this.Description;
                return shortDescription.Length > 200
                        ? shortDescription.Substring(0, 200) + " ..."
                        : shortDescription;
            }
        }

        public string Language { get; set; }

        public string TrailerPath { get; set; }

        public string WallpaperPath { get; set; }

        public string TrailerEmbededPath
        {
            get
            {
                var trailerPath = this.TrailerPath;
                var embededPath = trailerPath.Replace("watch?v=", "embed/");
                return embededPath;
            }
        }

        public string CoverPath { get; set; }

        public DirectorDetailsViewModel Director { get; set; }

        public IEnumerable<MovieGenreViewModel> MovieGenres { get; set; }

        public int StarRatingsSum { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Movie, MostPopularDetailsViewModel>()
                .ForMember(x => x.StarRatingsSum, options =>
                {
                    options.MapFrom(m => m.Ratings.Sum(st => st.Rate));
                });
        }
    }
}

