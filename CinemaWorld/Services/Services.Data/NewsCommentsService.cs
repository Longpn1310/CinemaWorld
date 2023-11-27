using CinemaWorld.Global.Common.Repositories;
using CinemaWorld.Models;
using CinemaWorld.Services.Common;
using CinemaWorld.Services.Services.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CinemaWorld.Services.Services.Data
{
    public class NewsCommentsService :  INewsCommentsService
    {
        private readonly IDeletableEntityRepository<NewsComment> newsCommentsRepository;

        public NewsCommentsService(IDeletableEntityRepository<NewsComment> newsCommentsRepository)
        {
            this.newsCommentsRepository = newsCommentsRepository;
        }

        public async Task CreateAsync(int newsId, string userId, string content, int? parentId = null)
        {
            var newsComment = new NewsComment
            {
                NewsId = newsId,
                UserId = userId,
                Content = content,
                ParentId = parentId,
            };

            bool doesNewsCommentExist = await this.newsCommentsRepository
                .All()
                .AnyAsync(x => x.NewsId == newsComment.NewsId && x.UserId == userId && x.Content == content);
            if (doesNewsCommentExist)
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.NewsCommentAlreadyExists, newsComment.NewsId, newsComment.Content));
            }

            await this.newsCommentsRepository.AddAsync(newsComment);
            await this.newsCommentsRepository.SaveChangesAsync();
        }

        public async Task<bool> IsInNewsId(int commentId, int newsId)
        {
            var commentNewsId = await this.newsCommentsRepository
                .All()
                .Where(x => x.Id == commentId)
                .Select(x => x.NewsId)
                .FirstOrDefaultAsync();

            return commentNewsId == newsId;
        }
    }
}
