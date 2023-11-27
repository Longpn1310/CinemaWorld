using AutoMapper;
using CinemaWorld.Models;
using CinemaWorld.Models.Enumerations;
using CinemaWorld.Services.Services.Data.Mapping;
using CinemaWorld.ViewModels.Directories;
using CinemaWorld.ViewModels.MovieComments;
using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Global.Common.ModelValidation.Movie;
namespace CinemaWorld.ViewModels.ViewModels.Movies
{
    public class MovieDetailsViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        [Display(Name = IdDisplayName)]
        public int Id { get; set; }

        [Display(Name = NameDisplayName)]
        public string Name { get; set; }

        [Display(Name = DateOfReleaseAllMoviesDisplayName)]
        public DateTime DateOfRelease { get; set; }

        [Display(Name = OnlyDateAllMoviesDisplayName)]
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

        public IEnumerable<MovieGenreViewModel> MovieGenres { get; set; }

        public IEnumerable<MovieCountryViewModel> MovieCountries { get; set; }

        [Display(Name = nameof(Director))]
        public DirectorDetailsViewModel Director { get; set; }

        public decimal Rating { get; set; }

        public string Language { get; set; }

        public CinemaCategory CinemaCategory { get; set; }

        public string CoverPath { get; set; }

        public string TrailerPath { get; set; }

        public string WallpaperPath { get; set; }

        public int Length { get; set; }

        public int StarRatingsSum { get; set; }

        public IEnumerable<PostMovieCommentViewModel> MovieComments { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Movie, MovieDetailsViewModel>()
                .ForMember(x => x.StarRatingsSum, options =>
                {
                    options.MapFrom(m => m.Ratings.Sum(st => st.Rate));
                });
        }
    }
}
