using CinemaWorld.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Global.Common.DataValidation.Privacy;

namespace CinemaWorld.Models;

public partial class Privacy : BaseDeletableModel<int>
{

    [Required]
    [MaxLength(ContentPageMaxLength)]
    public string PageContent { get; set; } = null!;
}
