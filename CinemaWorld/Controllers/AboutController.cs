using CinemaWorld.Services.Services.Data.Contracts;
using CinemaWorld.ViewModels.About;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWorld.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService aboutService;

        public AboutController(IAboutService aboutService)
        {
            this.aboutService = aboutService;
        }
        public async Task<IActionResult> Index()
        {
            var faqs = await this.aboutService.GetAllFaqsAsync<FaqDetailsViewModel>();

            return this.View(faqs);
        }
    }
}
