﻿using CinemaWorld.Data.Common.Models;
using System;
using System.Collections.Generic;

namespace CinemaWorld.Models;

public partial class MovieGenre : IDeletableEntity
{
    public int MovieId { get; set; }

    public virtual Movie Movie { get; set; }

    public int GenreId { get; set; }

    public virtual Genre Genre { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedOn { get; set; }
}
