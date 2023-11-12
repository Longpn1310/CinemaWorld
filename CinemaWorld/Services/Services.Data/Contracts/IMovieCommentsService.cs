namespace CinemaWorld.Services.Services.Data.Contracts
{
    public interface IMovieCommentsService
    {
        Task CreateAsync(int movieId, string userId, string content, int? parentId = null);

        Task<bool> IsInMovieId(int commentId, int movieId);
    }
}
