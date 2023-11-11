using CinemaWorld.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Global.Common.DataValidation.Country;

namespace CinemaWorld.Models;

public partial class Country : BaseDeletableModel<int>
{
    public Country()
    {
        this.MovieCountries = new HashSet<MovieCountry>();
    }
    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;

    public virtual ICollection<MovieCountry> MovieCountries { get; set; } = new List<MovieCountry>();
}
