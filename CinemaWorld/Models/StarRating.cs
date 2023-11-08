using CinemaWorld.Data.Common.Models;
using CinemaWorld.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaWorld.Models;

public partial class StarRating : BaseDeletableModel<int>
{

    public int Rate { get; set; }

    public int MovieId { get; set; }
    [Required]
    public string UserId { get; set; } = null!;

    public DateTime NextVoteDate { get; set; }

    public virtual Movie Movie { get; set; } = null!;
    public CinemaWorldUser User { get; set; }
}
