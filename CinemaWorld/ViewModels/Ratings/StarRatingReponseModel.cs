namespace CinemaWorld.ViewModels.Ratings
{
    public class StarRatingReponseModel
    {
        public int StarRatingsSum { get; set; }

        public string ErrorMessage { get; set; }

        public string AuthenticateErrorMessage { get; set; }

        public DateTime NextVoteDate { get; set; }
    }
}
