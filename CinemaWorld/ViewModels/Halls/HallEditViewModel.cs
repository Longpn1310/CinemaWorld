
namespace CinemaWorld.ViewModels.Halls
{
    using CinemaWorld.Models;
    using CinemaWorld.Services.Services.Data.Mapping;
    using System.ComponentModel.DataAnnotations;

    using static CinemaWorld.Global.Common.ModelValidation;
    using static CinemaWorld.Global.Common.ModelValidation.Hall;
    public class HallEditViewModel : IMapFrom<Models.Hall>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = EmptyFieldLengthError)]
        public string Category { get; set; }

        [Range(CapacityMinLength, CapacityMaxLength)]
        public int Capacity { get; set; }
    }
}
