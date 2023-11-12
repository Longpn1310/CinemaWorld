using CinemaWorld.Data.Common.Models;
using CinemaWorld.Global.Common;
using CinemaWorld.Global.Common.Repositories;
using CinemaWorld.Models;
using CinemaWorld.Services.Services.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CinemaWorld.Services.Services.Data
{
    public class MovieCommentsService : IMovieCommentsService
    {
        private readonly IDeletableEntityRepository<MovieComment> commentsRepository;
        
        public MovieCommentsService(IDeletableEntityRepository<MovieComment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }
        public async Task CreateAsync(int movieId, string userId, string content, int? parentId = null)
        {
            var movieComment = new MovieComment
            {
                MovieId = movieId,
                UserId = userId,
                Content = content,
                ParentId = parentId
            };

            bool doesMovieCommentExist = await this.commentsRepository
                .All().AnyAsync(x => x.MovieId == movieComment.MovieId && x.UserId == movieComment.UserId);
            if (doesMovieCommentExist)
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.MovieCommentAlreadyExists, movieComment.MovieId,movieComment.Content) );
            }
            await this.commentsRepository.AddAsync(movieComment);
            await this.commentsRepository.SaveChangesAsync();
        }

        public async Task<bool> IsInMovieId(int commentId, int movieId)
        {
            var commentMovieId = await this.commentsRepository
                .All()
                .Where(x => x.Id == commentId)
                .Select(x => x.MovieId)
                .FirstOrDefaultAsync();

            return commentMovieId == movieId;
        }
    }
}
