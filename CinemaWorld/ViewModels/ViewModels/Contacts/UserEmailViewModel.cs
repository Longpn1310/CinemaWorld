using CinemaWorld.Models;
using CinemaWorld.Services.Services.Data.Mapping;

namespace CinemaWorld.ViewModels.ViewModels.Contacts
{
    public class UserEmailViewModel : IMapFrom<ContactFormEntry>
    {
        public int Id { get; set; }

        public string Email { get; set; }
    }
}
