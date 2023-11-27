using CinemaWorld.Data.Models;
using CinemaWorld.Global.Common;
using CinemaWorld.Models;
using CinemaWorld.Models.Enumerations;
using Microsoft.AspNetCore.Identity;

namespace CinemaWorld.Middlewares
{
    public class AdminMiddleware
    {
        private readonly RequestDelegate next;

        public AdminMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, UserManager<CinemaWorldUser> userManager)
        {
            await this.SeedUserInRoles(userManager);
                await this.next(context);
        }
        public async Task SeedUserInRoles(UserManager<CinemaWorldUser> userManager)
        {
            if(!userManager.Users.Any(x => x.UserName == GlobalConstants.AdministratorFullName))
            {
                var user = new CinemaWorldUser
                {
                    UserName = GlobalConstants.AdministratorUsername,
                    Email = GlobalConstants.AdministratorEmail,
                    FullName = GlobalConstants.AdministratorFullName,
                    Gender = Gender.Male,
                };
                var result = await userManager.CreateAsync(user, GlobalConstants.AdministratorPassword);

                if(result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);
                }
                else
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(x => x.Description)));
                }
            }
        }
    }
}
