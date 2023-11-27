using CinemaWorld.Data.Common.Models;
using System;
using System.Collections.Generic;

namespace CinemaWorld.Models;

public class MovieCountry : IDeletableEntity
{
    public int MovieId { get; set; }

    public virtual Movie Movie { get; set; }

    public int CountryId { get; set; }

    public virtual Country Country { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedOn { get; set; }
}
