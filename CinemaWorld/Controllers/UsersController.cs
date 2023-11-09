using CinemaWorld.Areas.Identity.Pages.Account.InputModels;
using CinemaWorld.Data.Models;
using CinemaWorld.Data.Models.Enumerations;
using CinemaWorld.Global.Common;
using CinemaWorld.Helper;
using CinemaWorld.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;
using System.Text.Encodings.Web;

namespace CinemaWorld.Controllers
{
    public class UsersController : Controller
    {
        private readonly SignInManager<CinemaWorldUser> signInManager;
        private readonly UserManager<CinemaWorldUser> userManager;
        private readonly ILogger<UsersController> logger;
        private readonly IEmailSender emailSender;

        public UsersController(
            SignInManager<CinemaWorldUser> signInManager,
            UserManager<CinemaWorldUser> userManager,
            ILogger<UsersController> logger,
            IEmailSender emailSender)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.logger = logger;
            this.emailSender = emailSender;
        }
        [TempData] 
        public string ErrorMessage { get; set; }
        public string returlUrl { get; set; }
        public string LoginProvider { get; set; }

        [HttpPost]
        public async Task<IActionResult> AjaxLogin(AjaxLoginInputModel loginInput, string returnUrl = null)
        {
            returnUrl = returnUrl ?? this.Url.Content("/~");

            var ajaxObject = new AjaxObject();
            if (this.ModelState.IsValid)
            {
                //Dung cai nay de khong dem so lan login sai sau do khoa tai khoan
                //De kich hoat lai thi dung set lockoutOnfailure : true;

                var result = await this.signInManager
                    .PasswordSignInAsync(loginInput.Username, loginInput.Password, loginInput.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    this.logger.LogInformation("User logged in");
                    ajaxObject.Success = true;
                    ajaxObject.Message = "Logged-in";
                    ajaxObject.Action = returnUrl;
                }
                if(result.IsLockedOut)
                {
                    this.logger.LogWarning("This account has been locked out!");
                    return this.RedirectToPage("/Lockout");
                }
                else
                {
                    this.ModelState.AddModelError(string.Empty, "The username or password are in correct");
                }
            }
            if(!ajaxObject.Success)
            {
                ajaxObject.Message = ModelErrorsHelper.GetModelErrors(this.ModelState);
            }
            var jsonResult = new JsonResult(ajaxObject);
            return jsonResult;
        }
        [HttpPost]
        public async Task<IActionResult> AjaxRegister(AjaxRegisterInputModel registerInput, string returnUrl = null)
        {
            returnUrl = returnUrl ?? this.Url.Content("~/");
            var ajaxObject = new AjaxObject();
            if(this.ModelState.IsValid)
            {
                Enum.TryParse<Gender>(registerInput.SelectedGender, out Gender gender);

                var user = new CinemaWorldUser
                {
                    UserName = registerInput.Username,
                    Email = registerInput.Email,
                    FullName = registerInput.FullName,
                    Gender = gender
                };
                var result = await this.userManager.CreateAsync(user, registerInput.Password);
                if(result.Succeeded)
                {
                    this.logger.LogInformation("User created a new accoutn with password.");
                    await this.userManager.AddToRoleAsync(user, GlobalConstants.UserRoleName);

                    ajaxObject.Success = true;
                    ajaxObject.Message = "Registerd-in";
                    ajaxObject.Action = returnUrl;

                    //Phuong thuc bat dong bo de tao ma xac nhan qua email, lay tham so la user
                    var code = await this.userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code)); //ma hoa xac nhan truoc khi truyen qua url

                    //Gui mot email den dia chi email duoc cung cap
                    var callbackUrl = this.Url.Page("/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", user.Id, code = code},
                        protocol: this.Request.Scheme
                        );

                    await this.emailSender.SendEmailAsync(
                        registerInput.Email,
                        "Confirm your email",
                        htmlMessage: $"Please confirm your account by <a href ='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>");
                    //Neu xac nhan duoc kich hoat se chuyen huong den RegisterConfrimation

                    if(this.userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return this.RedirectToPage("RegisterConfirmation", new
                        {
                            email = registerInput.Email
                        });
                    }
                    else
                    {
                        await this.signInManager.SignInAsync(user, isPersistent: false);
                    }
                }
                foreach(var error in result.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            if (!ajaxObject.Success)
            {
                ajaxObject.Message = ModelErrorsHelper.GetModelErrors(this.ModelState);
            }

            var jsonResult = new JsonResult(ajaxObject);
            return jsonResult;
        }
        
    }
}
