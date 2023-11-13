using CinemaWorld.InputModels.AdministratorInputModels.Movies;
using CinemaWorld.Services.Services.Data.Contract;
using CinemaWorld.ViewModels.Enumerations;
using CinemaWorld.ViewModels.ViewModels.Movies;
using CinemaWorld.Services.Common;
using CinemaWorld.Global.Common.Repositories;
using CinemaWorld.Models;
using CinemaWorld.Services.Services.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using CinemaWorld.Global.Common;
using ExceptionMessages = CinemaWorld.Global.Common.ExceptionMessages;

namespace CinemaWorld.Services.Services.Data
{
    public class MoviesService : IMoviesService
    {
        public const string AllPaginationFilter = "All";
        private const string DigitPaginationFilter = "0 - 9";
        private const int MostPopularMoviesRating = 40;

        private readonly IDeletableEntityRepository<Movie> moviesRepository;
        private readonly IDeletableEntityRepository<Director> directorsRepository;
        private readonly IDeletableEntityRepository<MovieGenre> movieGenreRepository;
        private readonly IDeletableEntityRepository<MovieCountry> movieCountriesRepository;
        private readonly ICloudinaryService cloudinaryService;
        public MoviesService( 
         IDeletableEntityRepository<Movie> moviesRepository,
         IDeletableEntityRepository<Director> directorsRepository,
         IDeletableEntityRepository<MovieGenre> movieGenreRepository,
         IDeletableEntityRepository<MovieCountry> movieCountriesRepository,
         ICloudinaryService cloudinaryService
            ) {
            this.moviesRepository = moviesRepository;
            this.directorsRepository = directorsRepository;
            this.movieGenreRepository = movieGenreRepository;
            this.movieCountriesRepository = movieCountriesRepository;
            this.cloudinaryService = cloudinaryService;
        }


        public async Task<MovieDetailsViewModel> CreateAsync(MovieCreateInputModel movieCreateInputModel)
        {
            if(!Enum.TryParse(movieCreateInputModel.CinemaCategory, true,out CinemaCategory cinemaCategory))
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.InvalidCinemaCategoryType, movieCreateInputModel.CinemaCategory));
            }
            var director = await this.directorsRepository
                .All()
                .FirstOrDefaultAsync(d => d.Id == movieCreateInputModel.DirectorId);
            if(director == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.DirectorNotFound, movieCreateInputModel.DirectorId));

            }

            var coverUrl = await this.cloudinaryService.UpLoadAsync(
                movieCreateInputModel.CoverImage, movieCreateInputModel.Name);

            var wallpaperUrl = await this.cloudinaryService.
                UpLoadAsync(movieCreateInputModel.Wallpaper, movieCreateInputModel.Name + Suffixes.WallpaperSuffix);

            var movie = new Movie
            {
                Name = movieCreateInputModel.Name,
                DateOfRelease = movieCreateInputModel.DateOfRelease,
                Resolution = movieCreateInputModel.Resolution,
                Rating = movieCreateInputModel.Rating,
                Description = movieCreateInputModel.Description,
                Language = movieCreateInputModel.Language,
                CinemaCategory = cinemaCategory,
                TrailerPath = movieCreateInputModel.TrailerPath,
                CoverPath = coverUrl,
                WallpaperPath = wallpaperUrl,
                IMDBlink = movieCreateInputModel.IMDBLink,
                Length = movieCreateInputModel.Length,
                Director = director,
            };
            bool doesMovieExist = await this.moviesRepository.All().AnyAsync(x => x.Name == movieCreateInputModel.Name);
            if (doesMovieExist)
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.MovieAlreadyExists, movieCreateInputModel.Name));
            }
            foreach(var genreId in movieCreateInputModel.SelectedGenres)
            {
                var movieGenre = new MovieGenre
                {
                    MovieId = movie.Id,
                    GenreId = genreId,
                };

                await this.movieGenreRepository.AddAsync(movieGenre);
                movie.MovieGenres.Add(movieGenre);
            }
            foreach(var countryId in movieCreateInputModel.SelectedCountries)
            {
                var movieCountry = new MovieCountry
                {
                    MovieId = movie.Id,
                    CountryId = countryId,
                };
                await this.movieCountriesRepository.AddAsync(movieCountry);
                movie.MovieCountries.Add(movieCountry);
            }
            await this.moviesRepository.AddAsync(movie);
            await this.moviesRepository.AddAsync(movie);
            await this.moviesRepository.SaveChangesAsync();
            await this.movieGenreRepository.SaveChangesAsync();
            await this.movieCountriesRepository.SaveChangesAsync();

            var viewModel = await this.GetViewModelByIdAsync<MovieDetailsViewModel>(movie.Id);
            return viewModel;
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(MovieEditViewModel movieEditViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TViewModel>> GetAllMovieCountriesAsync<TViewModel>()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TViewModel>> GetAllMovieGenresAsync<TViewModel>()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TViewModel> GetAllMoviesAsQueryeable<TViewModel>()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TViewModel>> GetAllMoviesAsync<TViewModel>()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TViewModel> GetAllMoviesByFilterAsQueryeable<TViewModel>(string letter = null)
        {
            throw new NotImplementedException();
        }

        public IQueryable<MovieDetailsViewModel> GetByGenreNameAsQueryable(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TViewModel>> GetMostPopularMoviesAsync<TViewModel>(int count = 0)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TViewModel>> GetRecentlyAddedMoviesAsync<TViewModel>(int count = 0)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TViewModel>> GetTopImdbMoviesAsync<TViewModel>(decimal rating = 0, int count = 0)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TViewModel>> GetTopRatingMoviesAsync<TViewModel>(decimal rating = 0, int count = 0)
        {
            throw new NotImplementedException();
        }

        public Task<TViewModel> GetViewModelByIdAsync<TViewModel>(int id)
        {
            throw new NotImplementedException();
        }
    }
}
