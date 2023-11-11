using CinemaWorld.Data.Common;
using CinemaWorld.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static CinemaWorld.Global.Common.DataValidation;
using static CinemaWorld.Global.Common.DataValidation.ContactFormEntry;

namespace CinemaWorld.Models
{

    public partial class AdminContactFormEntry : BaseModel<int>
    {
        [Required]
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(SubjectMaxLength)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; }
    }

}