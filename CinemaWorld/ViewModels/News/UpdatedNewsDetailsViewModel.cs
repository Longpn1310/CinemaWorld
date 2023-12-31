﻿using CinemaWorld.Services.Services.Data.Mapping;

namespace CinemaWorld.ViewModels.News
{
    using News = CinemaWorld.Models.News;
    public class UpdatedNewsDetailsViewModel : IMapFrom<News>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? UpdatedSince
        {
            get
            {
                if (this.IsUpdated)
                {
                    var updatedSince = (int)Math.Round((DateTime.UtcNow - this.ModifiedOn).Value.TotalHours);
                    return updatedSince;
                }
                else
                {
                    return null;
                }
            }
        }

        public string CreationDate => this.CreatedOn.ToShortDateString();

        public bool IsUpdated { get; set; }
    }
}
