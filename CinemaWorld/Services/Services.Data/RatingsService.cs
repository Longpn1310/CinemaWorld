using CinemaWorld.Global.Common;
using CinemaWorld.Global.Common.Repositories;
using CinemaWorld.Models;
using CinemaWorld.Services.Services.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CinemaWorld.Services.Services.Data
{
    public class RatingsService : IRatingsService
    {
        private readonly IDeletableEntityRepository<StarRating> starRatingsRepository;

        public RatingsService(IDeletableEntityRepository<StarRating> starRatingsRepository)
        {
            this.starRatingsRepository = starRatingsRepository;
        }

        public async Task VoteAsync(int movieId, string userId, int rating)
        {
            var starRating = await this.starRatingsRepository
                .All()
                .FirstOrDefaultAsync(x => x.MovieId == movieId && x.UserId == userId);

            if (starRating != null)
            {
                if (DateTime.UtcNow < starRating.NextVoteDate)
                {
                    throw new ArgumentException(ExceptionMessages.AlreadySentVote);
                }

                starRating.Rate += rating;
                starRating.NextVoteDate = DateTime.UtcNow.AddDays(1);
            }
            else
            {
                starRating = new StarRating
                {
                    MovieId = movieId,
                    UserId = userId,
                    Rate = rating,
                    NextVoteDate = DateTime.UtcNow.AddDays(1),
                };

                await this.starRatingsRepository.AddAsync(starRating);
            }

            await this.starRatingsRepository.SaveChangesAsync();
        }

        public async Task<int> GetStarRatingsAsync(int movieId)
        {
            var starRatings = await this.starRatingsRepository
                .All()
                .Where(x => x.MovieId == movieId)
                .SumAsync(x => x.Rate);

            return starRatings;
        }

        public async Task<DateTime> GetNextVoteDateAsync(int movieId, string userId)
        {
            var starRating = await this.starRatingsRepository
                .All()
                .FirstAsync(x => x.MovieId == movieId && x.UserId == userId);

            return starRating.NextVoteDate;
        }
    }
}
