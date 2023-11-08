using CinemaWorld.Data.Common.Models;
using System;
using System.Collections.Generic;

namespace CinemaWorld.Models;

public partial class MovieReview : IDeletableEntity
{
    public int MovieId { get; set; }

    public int ReviewId { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual Movie Movie { get; set; } = null!;

    public virtual Review Review { get; set; } = null!;
}
