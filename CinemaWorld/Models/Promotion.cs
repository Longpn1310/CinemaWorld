using CinemaWorld.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Models.DataValidation.Promotion;
namespace CinemaWorld.Models;

public partial class Promotion : BaseDeletableModel<int>
{
    public Promotion()
    {
        this.SaleTransactions = new HashSet<SaleTransaction>();
    }
    [Required]
    [MaxLength(DescriptionMaxLength)]
    public string Description { get; set; } = null!;

    public decimal Discount { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }

    public virtual ICollection<SaleTransaction> SaleTransactions { get; set; } = new List<SaleTransaction>();
}
