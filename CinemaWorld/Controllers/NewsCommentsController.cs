using CinemaWorld.InputModels.AdministratorInputModels.News;
using CinemaWorld.Models;
using CinemaWorld.Services.Services.Data.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWorld.Controllers
{
    public class NewsCommentsController : Controller
    {
        private readonly INewsCommentsService newsCommentsService;
        private readonly UserManager<CinemaWorldUser> userManager;

        public NewsCommentsController(INewsCommentsService commentsService, UserManager<CinemaWorldUser> userManager)
        {
            this.newsCommentsService = commentsService;
            this.userManager = userManager;
        }
        [HttpPost]
        [Authorize]

        public async Task<IActionResult> Create(CreateNewsCommentsInputModel input)
        {
            var parentId = input.ParentId == 0 ? (int?)null : input.ParentId;

            if (parentId.HasValue)
            {
                if (!await this.newsCommentsService.IsInNewsId(parentId.Value, input.NewsId))
                {
                    return this.BadRequest();
                }
            }

            var userId = this.userManager.GetUserId(this.User);

            try
            {
                await this.newsCommentsService.CreateAsync(input.NewsId, userId, input.Content, parentId);
            }
            catch (ArgumentException aex)
            {
                return this.BadRequest(aex.Message);
            }

            return this.RedirectToAction("Details", "News", new { id = input.NewsId });
        }
    }
}
