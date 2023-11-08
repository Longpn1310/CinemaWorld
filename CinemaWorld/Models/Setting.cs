using CinemaWorld.Data.Common.Models;
using System;
using System.Collections.Generic;

namespace CinemaWorld.Models;

public partial class Setting : BaseDeletableModel<int>
{
    public string Name { get; set; }

    public string Value { get; set; }
}
