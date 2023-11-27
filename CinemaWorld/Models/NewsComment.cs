using CinemaWorld.Data.Common.Models;
using CinemaWorld.Data.Models;
using System;
using System.Collections.Generic;

namespace CinemaWorld.Models;

public partial class NewsComment : BaseDeletableModel<int>
{
    public int NewsId { get; set; }

    public virtual News News { get; set; }

    public int? ParentId { get; set; }

    public virtual NewsComment Parent { get; set; }

    public string Content { get; set; }

    public string UserId { get; set; }

    public virtual CinemaWorldUser User { get; set; }
}
