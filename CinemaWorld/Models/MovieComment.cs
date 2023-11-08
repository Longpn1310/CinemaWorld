using CinemaWorld.Data.Common.Models;
using System;
using System.Collections.Generic;

namespace CinemaWorld.Models;

public class MovieComment : BaseDeletableModel<int>
{

    public int MovieId { get; set; }

    public int? ParentId { get; set; }

    public string? Content { get; set; }

    public string? UserId { get; set; }

    public virtual ICollection<MovieComment> InverseParent { get; set; } = new List<MovieComment>();

    public virtual Movie Movie { get; set; } = null!;

    public virtual MovieComment? Parent { get; set; }

    public virtual AspNetUser? User { get; set; }
}
