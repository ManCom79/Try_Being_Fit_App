﻿namespace Models
{
    public class VideoTraining : Training
    {
        public double Rating { get; set; }

        public VideoTraining(int id, string title, string link, double rating) : base(id, title, link)
        {
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
