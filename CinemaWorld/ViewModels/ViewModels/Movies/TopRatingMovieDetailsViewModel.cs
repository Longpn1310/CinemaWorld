﻿namespace CinemaWorld.ViewModels.ViewModels.Movies
{
    using System;
    using System.Linq;
    using AutoMapper;
    using CinemaWorld.Models;
    using CinemaWorld.Services.Services.Data.Mapping;
       public class TopRatingMovieDetailsViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string CoverPath { get; set; }

        public string Name { get; set; }

        public int StarRatingsSum { get; set; }

        public DateTime DateOfRelease { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Movie, TopRatingMovieDetailsViewModel>()
                .ForMember(x => x.StarRatingsSum, options =>
                {
                    options.MapFrom(m => m.Ratings.Sum(st => st.Rate));
                });
        }
    }
}
