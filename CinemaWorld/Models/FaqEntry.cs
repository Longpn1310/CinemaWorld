using CinemaWorld.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Global.Common.DataValidation.FaqEntry;

namespace CinemaWorld.Models;

public class FaqEntry : BaseDeletableModel<int>
{

    [Required]
    [MaxLength(QuestionMaxLength)]
    public string Question { get; set; } = null!;

    [Required]
    [MaxLength(AnswerMaxLength)]
    public string Answer { get; set; } = null!;
}
