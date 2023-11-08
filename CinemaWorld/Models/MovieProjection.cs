using CinemaWorld.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaWorld.Models;

public class MovieProjection : BaseDeletableModel<int>
{
    public MovieProjection()
    {
        this.SaleTransactions = new HashSet<SaleTransaction>();
    }
    [Required]
    public DateTime Date { get; set; }

    public int MovieId { get; set; }

    public int HallId { get; set; }

    public int CinemaId { get; set; }

    public virtual Cinema Cinema { get; set; } = null!;

    public virtual Hall Hall { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;

    public virtual ICollection<SaleTransaction> SaleTransactions { get; set; } = new List<SaleTransaction>();
}
