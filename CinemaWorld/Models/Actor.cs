using CinemaWorld.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaWorld.Models;

public partial class Actor : BaseDeletableModel<int>
{
    public Actor()
    {
        this.MovieActors = new HashSet<MovieActor>();
    }
    [Required]
    [MaxLength(DataValidation.NameMaxLength)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(DataValidation.NameMaxLength)]
    public string LastName { get; set; }

    public virtual ICollection<MovieActor> MovieActors { get; set; }
}
