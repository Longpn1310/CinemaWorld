using CinemaWorld.Data.Common.Models;
using CinemaWorld.Data.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaWorld.Models;

public partial class SaleTransaction : BaseDeletableModel<string>
{
    public SaleTransaction() { 
    this.Id = Guid.NewGuid().ToString();
    }
    [Required]
    public DateTime Date { get; set; }

    public string? UserId { get; set; }

    public int? PromotionId { get; set; }

    public int MovieProjectionId { get; set; }

    public int TicketId { get; set; }

    public PaymentMethod PaymentMethod { get; set; }

    public virtual MovieProjection MovieProjection { get; set; } = null!;

    public virtual Promotion? Promotion { get; set; }

    public virtual Ticket Ticket { get; set; } = null!;

    public virtual AspNetUser? User { get; set; }
}
