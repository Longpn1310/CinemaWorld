﻿using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Global.Common.ModelValidation;

namespace CinemaWorld.InputModels.Comments
{
    public class CreateMovieCommentInputModel
    {
        public int MovieId { get; set; }

        public int ParentId { get; set; }

        [Required(ErrorMessage = EmptyFieldLengthError)]
        public string Content { get; set; }
    }
}
