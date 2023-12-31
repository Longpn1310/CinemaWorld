﻿using CinemaWorld.Data.Common.Models;
using CinemaWorld.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Global.Common.DataValidation.News;

namespace CinemaWorld.Models;

public partial class News : BaseDeletableModel<int>
{
    public News()
    {
        this.NewsComments = new HashSet<NewsComment>();
    }

    [Required]
    [MaxLength(TitleMaxLength)]
    public string Title { get; set; }

    [Required]
    [MaxLength(DescriptionMaxLength)]
    public string Description { get; set; }

    [Required]
    [MaxLength(ShortDescriptionMaxLength)]
    public string ShortDescription { get; set; }

    [Required]
    [MaxLength(ImagePathMaxLength)]
    public string ImagePath { get; set; }

    [Required]
    public string UserId { get; set; }

    public virtual CinemaWorldUser User { get; set; }

    public int ViewsCounter { get; set; }

    public bool IsUpdated { get; set; }

    public virtual ICollection<NewsComment> NewsComments { get; set; }
}
