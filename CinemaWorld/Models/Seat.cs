using CinemaWorld.Data.Common.Models;
using CinemaWorld.Models.Enumerations;
using System;
using System.Collections.Generic;

namespace CinemaWorld.Models;

public class Seat : BaseDeletableModel<int>
{

    public int Number { get; set; }// Seat Number, id chi để xác định đối tượng object

    public int RowNumber { get; set; }

    public int HallId { get; set; }

    public SeatCategory Category { get; set; }

    public bool IsAvailable { get; set; }

    public bool IsSold { get; set; }

    public virtual Hall Hall { get; set; }
}
