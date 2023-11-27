using CinemaWorld.Global.Common.Repositories;
using CinemaWorld.Global.Common;
using CinemaWorld.InputModels.AdministratorInputModels.News;
using CinemaWorld.Services.Services.Data.Contracts;
using CinemaWorld.Services.Services.Data.Mappings;
using CinemaWorld.ViewModels.News;
using CinemaWorld.Services.Services.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using CinemaWorld.Models;

namespace CinemaWorld.Services.Services.Data
{
    public class NewsService : INewService
    {
        private readonly IDeletableEntityRepository<News> newsRepository;
        private readonly ICloudinaryService cloudinaryService;

        public NewsService(
            IDeletableEntityRepository<News> newsRepository,
            ICloudinaryService cloudinaryService)
        {
            this.newsRepository = newsRepository;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task<AllNewsListingViewModel> CreateAsync(NewsCreateInputModel newsCreateInputModel, string userId)
        {
            var imageUrl = await cloudinaryService
               .UpLoadAsync(newsCreateInputModel.Image, newsCreateInputModel.Title + Suffixes.NewsSuffix);

            var news = new News
            {
                Title = newsCreateInputModel.Title,
                Description = newsCreateInputModel.Description,
                ShortDescription = newsCreateInputModel.ShortDescription,
                ImagePath = imageUrl,
                UserId = userId,
            };

            bool doesNewsExist = await newsRepository
                .All()
                .AnyAsync(x => x.Title == news.Title && x.Description == news.Description);
            if (doesNewsExist)
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.NewsAlreadyExists, news.Title, news.Description));
            }

            await newsRepository.AddAsync(news);
            await newsRepository.SaveChangesAsync();

            var viewModel = await GetViewModelByIdAsync<AllNewsListingViewModel>(news.Id);

            return viewModel;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var news = newsRepository.All().FirstOrDefault(x => x.Id == id);
            if (news == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.NewsNotFound, id));
            }

            news.IsDeleted = true;
            news.DeletedOn = DateTime.UtcNow;
            newsRepository.Update(news);
            await newsRepository.SaveChangesAsync();
        }

        public async Task EditAsync(NewsEditViewModel newsEditViewModel, string userId)
        {
            var news = newsRepository.All().FirstOrDefault(g => g.Id == newsEditViewModel.Id);

            if (news == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.NewsNotFound, newsEditViewModel.Id));
            }

            if (newsEditViewModel.Image != null)
            {
                var newImageUrl = await cloudinaryService
                    .UpLoadAsync(newsEditViewModel.Image, newsEditViewModel.Title + Suffixes.NewsSuffix);
                news.ImagePath = newImageUrl;
            }

            news.Title = newsEditViewModel.Title;
            news.Description = newsEditViewModel.Description;
            news.ShortDescription = newsEditViewModel.ShortDescription;
            news.UserId = userId;
            news.ModifiedOn = DateTime.UtcNow;
            news.IsUpdated = true;

            newsRepository.Update(news);
            await newsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TViewModel>> GetAllNewsAsync<TViewModel>()
        {
            var news = await newsRepository
                 .All()
                 .OrderByDescending(x => x.CreatedOn)
                 .To<TViewModel>()
                 .ToListAsync();

            return news;
        }

        public async Task<IEnumerable<TViewModel>> GetTopNewsAsync<TViewModel>(int count = 0)
        {
            var topNews = await newsRepository
                 .All()
                 .Take(count)
                 .OrderByDescending(x => x.ViewsCounter)
                 .To<TViewModel>()
                 .ToListAsync();

            return topNews;
        }

        public async Task<IEnumerable<TViewModel>> GetUpdatedNewsAsync<TViewModel>()
        {
            var updatedNews = await newsRepository
                 .All()
                 .OrderByDescending(x => x.ModifiedOn)
                 .Where(x => x.IsUpdated == true)
                 .To<TViewModel>()
                 .ToListAsync();

            return updatedNews;
        }

        public async Task<NewsDetailsViewModel> SetViewsCounter(int id)
        {
            var news = await newsRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (news == null)
            {
                throw new NullReferenceException(
                       string.Format(ExceptionMessages.NewsNotFound, id));
            }

            news.ViewsCounter++;
            newsRepository.Update(news);
            await newsRepository.SaveChangesAsync();

            var viewModel = await newsRepository
                .All()
                .Where(x => x.Id == id)
                .To<NewsDetailsViewModel>()
                .FirstOrDefaultAsync(x => x.Id == id);

            return viewModel;
        }

        public async Task<TViewModel> GetViewModelByIdAsync<TViewModel>(int id)
        {
            var newsViewModel = await newsRepository
                .All()
                .Where(m => m.Id == id)
                .To<TViewModel>()
                .FirstOrDefaultAsync();

            if (newsViewModel == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.NewsNotFound, id));
            }

            return newsViewModel;
        }

        public IQueryable<TViewModel> GetAllNewsAsQueryeable<TViewModel>()
        {
            var news = newsRepository
                .All()
                .To<TViewModel>();

            return news;
        }
    }
}
