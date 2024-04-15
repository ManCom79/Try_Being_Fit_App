namespace Models
{
    public class VideoTraining : Training
    {
        public int Id { get; set; }
        public double Rating { get; set; }

        public VideoTraining(int id, double rating, string title, string link) : base(id, title, link)
        {
            Id = id;
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
