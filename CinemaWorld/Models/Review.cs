using CinemaWorld.Data.Common.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Global.Common.DataValidation.Review;
namespace CinemaWorld.Models;

public partial class Review : BaseDeletableModel<int>
{ 
    public Review()
    {
        this.MovieReviews = new HashSet<MovieReview>();
        this.ReviewAuthors = new HashSet<ReviewAuthor>();
    }
    [Required]
    [MaxLength(TitleMaxLength)]
    public string Title { get; set; }

    [Required]
    [MaxLength(DescriptionMaxLength)]
    public string Description { get; set; }

    public DateTime Date { get; set; }

    public virtual ICollection<MovieReview> MovieReviews { get; set; } = new List<MovieReview>();

    public virtual ICollection<ReviewAuthor> ReviewAuthors { get; set; } = new List<ReviewAuthor>();
}
