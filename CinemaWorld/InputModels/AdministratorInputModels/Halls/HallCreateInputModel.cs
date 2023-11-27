using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Global.Common.ModelValidation;
using static CinemaWorld.Global.Common.ModelValidation.Hall;
namespace CinemaWorld.InputModels.AdministratorInputModels.Halls
{
    public class HallCreateInputModel
    {
        [Required(ErrorMessage = EmptyFieldLengthError)]
        public string Category { get; set; }

        [Range(CapacityMinLength, CapacityMaxLength)]
        public int Capacity { get; set; }
    }
}
