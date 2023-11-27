using CinemaWorld.Data.Common.Models;
using System;
using System.Collections.Generic;

namespace CinemaWorld.Models;

public partial class ReviewAuthor : IDeletableEntity
{
    public int AuthorId { get; set; }

    public int ReviewId { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual Author Author { get; set;}

    public virtual Review Review { get; set; }
}
