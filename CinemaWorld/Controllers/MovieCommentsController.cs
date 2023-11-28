using CinemaWorld.InputModels.Comments;
using CinemaWorld.Models;
using CinemaWorld.Services.Services.Data.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWorld.Controllers
{
    public class MovieCommentsController : Controller
    {
        private readonly IMovieCommentsService movieCommentsService;
        private readonly UserManager<CinemaWorldUser> userManager;

        public MovieCommentsController(
            IMovieCommentsService commentsService,
            UserManager<CinemaWorldUser> userManager)
        {
            this.movieCommentsService = commentsService;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize]

        public async Task<IActionResult> Create(CreateMovieCommentInputModel input)
        {
            //Nếu input 0 thì parentId sẽ được gán bằng Null
            var parentId = input.ParentId == 0 ? (int?)null : input.ParentId;

            if(parentId.HasValue)
            {
                if(!await this.movieCommentsService.IsInMovieId(parentId.Value, input.MovieId))
                {
                    return this.BadRequest();
                }
            }
            var userId = this.userManager.GetUserId(this.User);

            try
            {
                await this.movieCommentsService.CreateAsync(input.MovieId, userId,input.Content, parentId);

            } catch(ArgumentException ex) {

                return this.BadRequest(ex.Message);
            }

            return this.RedirectToAction("Details", "Movies", new { id = input.MovieId });
        }
    }
}
