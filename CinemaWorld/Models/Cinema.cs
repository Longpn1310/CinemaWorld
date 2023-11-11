using CinemaWorld.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Global.Common.DataValidation.Cinema;
namespace CinemaWorld.Models;

public partial class Cinema : BaseDeletableModel<int>
{
    public Cinema()
    {
        this.Projections = new List<MovieProjection>();
    }

    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; }

    [Required]
    [MaxLength(AddressMaxLength)]
    public string Address { get; set; }

    public virtual ICollection<MovieProjection> Projections { get; set; } = new List<MovieProjection>();
}
