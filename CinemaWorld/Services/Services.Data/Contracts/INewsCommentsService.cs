namespace CinemaWorld.Services.Services.Data.Contracts
{
    public interface INewsCommentsService 
    {
        Task CreateAsync(int newsId, string userId, string content, int? parentId = null);

        Task<bool> IsInNewsId(int commentId, int newsId);
    }
}
