﻿using CinemaWorld.Global.Common.Atrributes;
using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Global.Common.ModelValidation;
using static CinemaWorld.Global.Common.ModelValidation.ContactFormEntry;

namespace CinemaWorld.InputModels.Contacts
{
    public class ContactFormEntryViewModel
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength, ErrorMessage = FirstNameLengthError)]
        [Display(Name = FirstNameDisplayName)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength, ErrorMessage = LastNameLengthError)]
        [Display(Name = LastNameDispalyName)]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(SubjectMaxLength, MinimumLength = SubjectMinLegth, ErrorMessage = SubjectLengthError)]
        public string Subject { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLegth, ErrorMessage = ContentLengthError)]
        public string Content { get; set; }

        [GoogleReCaptchaValidation]
        public string RecaptchaValue { get; set; }
    }
}
