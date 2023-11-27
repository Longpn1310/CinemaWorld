using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using CinemaWorld.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using CinemaWorld.Areas.Identity.Pages.Account.InputModels;
using CinemaWorld.Models;

namespace CinemaWorld.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {

        private readonly SignInManager<CinemaWorldUser> signInManager;
        private readonly ILogger<LoginModel> logger;

        public LoginModel(
            SignInManager<CinemaWorldUser> signInManager,
            ILogger<LoginModel> logger)
        {
            this.signInManager = signInManager;
            this.logger = logger;
        }

        [BindProperty]
        public LoginInputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                if (!string.IsNullOrEmpty(this.ErrorMessage))
                {
                    this.ModelState.AddModelError(string.Empty, this.ErrorMessage);
                }

                returnUrl = returnUrl ?? this.Url.Content("~/");

                // Clear the existing external cookie to ensure a clean login process
                await this.HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

                this.ExternalLogins = (await this.signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

                this.ReturnUrl = returnUrl;
                return this.Page();
            }
            else
            {
                return this.Redirect("/");
            }
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? this.Url.Content("~/");

            if (this.ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await this.signInManager
                    .PasswordSignInAsync(this.Input.Username, this.Input.Password, this.Input.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    this.logger.LogInformation("User logged in.");
                    return this.LocalRedirect(returnUrl);
                }

                if (result.RequiresTwoFactor)
                {
                    return this.RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = this.Input.RememberMe });
                }

                if (result.IsLockedOut)
                {
                    this.logger.LogWarning("This account has been locked out, please try again later.");
                    return this.RedirectToPage("./Lockout");
                }
                else
                {
                    this.ModelState.AddModelError(string.Empty, "The username or password supplied are incorrect. Please check your spelling and try again.");
                }
            }

            // If we got this far, something failed, redisplay form
            return this.Page();
        }
    }
}
