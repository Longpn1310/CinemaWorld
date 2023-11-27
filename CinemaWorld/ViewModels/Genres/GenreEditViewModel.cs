namespace CinemaWorld.ViewModels.Genres

{
    using CinemaWorld.Services.Services.Data.Mapping;
    using System.ComponentModel.DataAnnotations;
    using Genre = CinemaWorld.Models.Genre;
    using static CinemaWorld.Global.Common.ModelValidation;
    using static CinemaWorld.Global.Common.ModelValidation.Genre;
    public class GenreEditViewModel :  IMapFrom<Genre>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = EmptyFieldLengthError)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = NameLengthError)]
        public string Name { get; set; }
    }
}
