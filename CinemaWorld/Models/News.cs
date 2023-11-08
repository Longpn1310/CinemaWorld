using CinemaWorld.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Models.DataValidation.News;

namespace CinemaWorld.Models;

public partial class News : BaseDeletableModel<int>
{
    public News()
    {
        this.NewsComments = new HashSet<NewsComment>();
    }

    [Required]
    [MaxLength(TitleMaxLength)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(DescriptionMaxLength)]
    public string Description { get; set; } = null!;

    [Required]
    [MaxLength(ImagePathMaxLength)]
    public string ShortDescription { get; set; } = null!;
    [Required]
    [MaxLength(ImagePathMaxLength)]
    public string ImagePath { get; set; } = null!;
    [Required]
    public string UserId { get; set; } = null!;

    public int ViewsCounter { get; set; }

    public bool IsUpdated { get; set; }

    public virtual ICollection<NewsComment> NewsComments { get; set; } = new List<NewsComment>();

    public virtual AspNetUser User { get; set; } = null!;
}
