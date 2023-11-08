using CinemaWorld.Data.Common.Models;
using CinemaWorld.Data.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Models.DataValidation.Movie;

namespace CinemaWorld.Models;

public class Movie : BaseDeletableModel<int>
{
    public Movie() { 
    
        this.MovieGenres = new HashSet<MovieGenre>();
        this.MovieReviews = new HashSet<MovieReview>();
        this.MovieCountries = new HashSet<MovieCountry>();
        this.MovieActors = new HashSet<MovieActor>();
        this.MovieProjections = new HashSet<MovieProjection>();
        this.MovieComments = new HashSet<MovieComment>();
    }
    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    public DateTime DateOfRelease { get; set; }

    public string Resolution { get; set; }

    public decimal Rating { get; set; }

    [Required]
    [MaxLength(DescriptionMaxLength)]
    public string Description { get; set; } = null!;

    [Required]
    [MaxLength(LanguageMaxLength)]
    public string Language { get; set; } = null!;

    [Required]
    public CinemaCategory CinemaCategory { get; set; } //A, B, C ,D

    [MaxLength(TrailerPathMaxLength)]
    public string? TrailerPath { get; set; }

    [Required]
    [MaxLength(CoverPathMaxLength)]
    public string CoverPath { get; set; } = null!;

    [Required]
    [MaxLength(WallpaperPathMaxLength)]
    public string WallpaperPath { get; set; } = null!;

    [MaxLength(ImdbLinkMaxLength)]
    public string? Imdblink { get; set; }

    public int Length { get; set; }

    public int DirectorId { get; set; }

    public virtual Director Director { get; set; } = null!;

    public virtual ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();

    public virtual ICollection<MovieComment> MovieComments { get; set; } = new List<MovieComment>();

    public virtual ICollection<MovieCountry> MovieCountries { get; set; } = new List<MovieCountry>();

    public virtual ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();

    public virtual ICollection<MovieProjection> MovieProjections { get; set; } = new List<MovieProjection>();

    public virtual ICollection<MovieReview> MovieReviews { get; set; } = new List<MovieReview>();

    public virtual ICollection<StarRating> StarRatings { get; set; } = new List<StarRating>();
}
