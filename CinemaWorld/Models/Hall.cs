using CinemaWorld.Data.Common.Models;
using CinemaWorld.ViewModels.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Global.Common.DataValidation.Hall;

namespace CinemaWorld.Models;

public class Hall : BaseDeletableModel<int>
{
    public Hall()
    {
        this.Seats = new HashSet<Seat>();
        this.MovieProjections = new HashSet<MovieProjection>();
    }
    [Required]
    public HallCategory Category { get; set; }

    [Range(CapacityMinLength, CapacityMaxLength)]
    public int Capacity { get; set; }

    public virtual ICollection<MovieProjection> MovieProjections { get; set; } = new List<MovieProjection>();

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
}
