using CinemaWorld.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Global.Common.DataValidation;
using static CinemaWorld.Global.Common.DataValidation.ContactFormEntry;


namespace CinemaWorld.Models;

public partial class ContactFormEntry : BaseModel<int>
{

    [Required]
    [MaxLength(NameMaxLength)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(NameMaxLength)]
    public string LastName { get; set; } = null!;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Required]
    [MaxLength(SubjectMaxLength)]
    public string Subject { get; set; } = null!;

    [Required]
    [MaxLength(ContentMaxLength)]
    public string Content { get; set; } = null!;
}
