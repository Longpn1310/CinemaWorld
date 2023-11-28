using CinemaWorld.Global.Common;
using CinemaWorld.InputModels.Ratings;
using CinemaWorld.Models;
using CinemaWorld.Services.Services.Data.Contracts;
using CinemaWorld.ViewModels.Ratings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWorld.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingsService ratingsService;
        private readonly UserManager<CinemaWorldUser> userManager;

        public RatingsController(IRatingsService ratingsService, UserManager<CinemaWorldUser> userManager)
        {
            this.ratingsService = ratingsService;
            this.userManager = userManager;
        }
        [HttpPost]
        public async Task<ActionResult<StarRatingReponseModel>> Post(RatingInputModel input)
        {
            var userId = this.userManager.GetUserId(this.User);
            var starRatingResponseModel = new StarRatingReponseModel();

            if(userId == null)
            {
                starRatingResponseModel.AuthenticateErrorMessage = ExceptionMessages.AuthenticatedErrorMessage;
                starRatingResponseModel.StarRatingsSum = await this.ratingsService.GetStarRatingsAsync(input.MovieId);

                return starRatingResponseModel;
            }

            try
            {
                await this.ratingsService.VoteAsync(input.MovieId, userId, input.Rating);
            }
            catch(ArgumentException ex)
            {
                starRatingResponseModel.ErrorMessage = ex.Message;
                return starRatingResponseModel;
            }
            finally
            {
                starRatingResponseModel.StarRatingsSum = await this.ratingsService.GetStarRatingsAsync(input.MovieId);
                starRatingResponseModel.NextVoteDate = await this.ratingsService.GetNextVoteDateAsync(input.MovieId, userId);
            }

            return starRatingResponseModel;
        }
    }
}
