using CinemaWorld.Data.Common.Models;
using CinemaWorld.Global.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaWorld.Models;

public partial class Director : BaseDeletableModel<int>
{
    public Director() { 
    this.Movies = new HashSet<Movie>();
    }
    [Required]
    [MaxLength(DataValidation.NameMaxLength)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(DataValidation.NameMaxLength)]
    public string LastName { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
