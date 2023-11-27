using CinemaWorld.Data.Common.Models;
using System;
using System.Collections.Generic;

namespace CinemaWorld.Models;

public class MovieActor : IDeletableEntity
{
    public int MovieId { get; set; }

    public virtual Movie Movie { get; set; }

    public int ActorId { get; set; }

    public virtual Actor Actor { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedOn { get; set; }
}
