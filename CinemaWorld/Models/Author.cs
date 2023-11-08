using CinemaWorld.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaWorld.Models;

public partial class Author : BaseDeletableModel<int>
{
    public Author()
    {
        this.Reviews = new HashSet<ReviewAuthor>();
    }
    [Required]
    [MaxLength(DataValidation.NameMaxLength)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(DataValidation.NameMaxLength)]
    public string LastName { get; set; }

    public string Email { get; set; }

    public virtual ICollection<ReviewAuthor> Reviews { get; set; }
}
