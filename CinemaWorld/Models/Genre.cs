using CinemaWorld.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Models.DataValidation.Genre;
namespace CinemaWorld.Models;

public class Genre : BaseDeletableModel<int>
{
    public Genre() {
    
        this.MovieGenres = new HashSet<MovieGenre>();
    
    }

    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;

    public virtual ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
}
