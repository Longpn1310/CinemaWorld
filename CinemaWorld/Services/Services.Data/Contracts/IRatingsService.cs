namespace CinemaWorld.Services.Services.Data.Contracts
{
    public interface IRatingsService
    {
        Task VoteAsync(int movieId, string userId, int rating);

        Task<int> GetStarRatingsAsync(int movieId);

        Task<DateTime> GetNextVoteDateAsync(int movieId, string userId);
    }
}
