using System.ComponentModel.DataAnnotations;
using static CinemaWorld.Global.Common.ModelValidation;
namespace CinemaWorld.InputModels.AdministratorInputModels.News
{
    public class CreateNewsCommentsInputModel
    {
        public int NewsId { get; set; }

        public int ParentId { get; set; }

        [Required(ErrorMessage = EmptyFieldLengthError)]
        public string Content { get; set; }
    }
}
