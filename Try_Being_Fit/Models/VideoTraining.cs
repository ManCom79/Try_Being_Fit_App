namespace Models
{
    public class VideoTraining : Training
    {
        public double Rating { get; set; }

        public VideoTraining(string title, string link, double rating) : base(title, link)
        {
            ID = GetUniqueId();
            Rating = CalculateRating(rating);
        }

        public double CalculateRating(double rating)
        {
            if(Rating == 0)
            {
                Rating = rating;
            } else
            {
                Rating = (Rating + rating) / 2;
            }
            return Rating;
        }
    }
}
