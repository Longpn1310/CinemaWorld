﻿using CinemaWorld.Global.Common;
using CinemaWorld.Global.Common.Atrributes;
using CinemaWorld.ViewModels.Directories;
using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Global.Common.ModelValidation;
using static CinemaWorld.Global.Common.ModelValidation.Country;
using static CinemaWorld.Global.Common.ModelValidation.Director;
using static CinemaWorld.Global.Common.ModelValidation.Genre;
using static CinemaWorld.Global.Common.ModelValidation.Movie;
using static CinemaWorld.Global.Common.Atrributes.AllowedExtensionAttribute;
using CinemaWorld.ViewModels.ViewModels.Genre;
using CinemaWorld.ViewModels.ViewModels.Countries;

namespace CinemaWorld.InputModels.AdministratorInputModels.Movies
{
    public class MovieCreateInputModel
    {
        [Required(ErrorMessage = EmptyFieldLengthError)]
        [StringLength(Movie.NameMaxLength, MinimumLength = Movie.NameMinLength, ErrorMessage = NameLengthError)]
        public string Name { get; set; }

        [Required(ErrorMessage = EmptyFieldLengthError)]
        [DataType(DataType.Date)]
        [Display(Name = DateOfReleaseDisplayName)]
        public DateTime DateOfRelease { get; set; }

        [StringLength(ResolutionMaxLength)]
        public string Resolution { get; set; }

        [Range(1, RatingMaxValue)]
        public decimal Rating { get; set; }

        [Required(ErrorMessage = EmptyFieldLengthError)]
        [DataType(DataType.MultilineText)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = DescriptionError)]
        public string Description { get; set; }

        [Required(ErrorMessage = EmptyFieldLengthError)]
        [StringLength(LanguageMaxLength, MinimumLength = LanguageMinLength, ErrorMessage = LanguageError)]
        public string Language { get; set; }

        [Required(ErrorMessage = EmptyFieldLengthError)]
        [StringLength(CinemaCategoryMaxLength)]
        [Display(Name = CinemaCategoryDisplayName)]
        public string CinemaCategory { get; set; }

        [StringLength(TrailerPathMaxLength, MinimumLength = TrailerPathMinLength, ErrorMessage = TrailerPathError)]
        [DataType(DataType.Url)]
        [Display(Name = TrailerPathDisplayName)]
        public string TrailerPath { get; set; }

        [DataType(DataType.Url)]
        [StringLength(CoverPathMaxLength, MinimumLength = CoverPathMinLength, ErrorMessage = CoverPathError)]
        public string CoverPath { get; set; }

        [Required(ErrorMessage = EmptyFieldLengthError)]
        [DataType(DataType.Upload)]
        [MaxFileSize(CoverImageMaxSize)]
        [AllowedExtensionAttribute]
        [Display(Name = CoverImageDisplayName)]
        public IFormFile CoverImage { get; set; }

        [DataType(DataType.Url)]
        [StringLength(WallpaperPathMaxLength, MinimumLength = WallpaperPathMinLength, ErrorMessage = WallpaperPathError)]
        public string WallpaperPath { get; set; }

        [Required(ErrorMessage = EmptyFieldLengthError)]
        [DataType(DataType.Upload)]
        [MaxFileSize(WallpaperMaxSize)]
        [AllowedExtensionAttribute]
        [Display(Name = WallpaperDisplayName)]
        public IFormFile Wallpaper { get; set; }

        [StringLength(ImdbLinkMaxLength, MinimumLength = ImdbLinkMinLength, ErrorMessage = ImdbLinkError)]
        [DataType(DataType.Url)]
        [Display(Name = IMDBLinkDisplayName)]
        public string IMDBLink { get; set; }

        [Range(1, LengthMaxLength)]
        public int Length { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = DirectorIdError)]
        [Display(Name = nameof(Director))]
        public int DirectorId { get; set; }

        public IEnumerable<DirectorDetailsViewModel> Directors { get; set; }

        public IEnumerable<GenreDetailsViewModel> Genres { get; set; }

        public IEnumerable<CountryDetailsViewModel> Countries { get; set; }

        [Required(ErrorMessage = GenreIdError)]
        [Display(Name = GenresDisplayName)]
        public IList<int> SelectedGenres { get; set; }

        [Required(ErrorMessage = CountryIdError)]
        [Display(Name = CountriesDisplayName)]
        public IList<int> SelectedCountries { get; set; }
    }
}
