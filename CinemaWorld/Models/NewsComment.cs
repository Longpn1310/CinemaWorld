using CinemaWorld.Data.Common.Models;
using System;
using System.Collections.Generic;

namespace CinemaWorld.Models;

public partial class NewsComment : BaseDeletableModel<int>
{
    public int NewsId { get; set; }

    public int? ParentId { get; set; }

    public string? Content { get; set; }

    public string? UserId { get; set; }

    public virtual ICollection<NewsComment> InverseParent { get; set; } = new List<NewsComment>();

    public virtual News News { get; set; } = null!;

    public virtual NewsComment? Parent { get; set; }

    public virtual AspNetUser? User { get; set; }
}
