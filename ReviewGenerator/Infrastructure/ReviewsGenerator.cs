using ReviewGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReviewGenerator.Infrastructure
{
    public class ReviewsGenerator
    {
        private RestaurantNameGenerator _restaurantGenerator;
        private MenuItemGenerator _menuItemGenerator;
        private FeedbackGenerator _feedbackGenerator;
        private Random _rand = new Random();

        public ReviewsGenerator()
        {
            _restaurantGenerator = new RestaurantNameGenerator();
            _menuItemGenerator = new MenuItemGenerator();
            _feedbackGenerator = new FeedbackGenerator();
        }

        public List<Review> Generate(int positiveCount, int negativeCount)
        {
            var allReviews = new List<Review>();

            allReviews.AddRange(GeneratePositiveReviews(positiveCount));
            allReviews.AddRange(GenerateNegativeReviews(negativeCount));

            return allReviews;
        }

        private List<Review> GeneratePositiveReviews(int count)
        {
            var positiveReviews = new List<Review>();
            for (int i = 0; i < count; i++)
            {
                positiveReviews.Add(GeneratePositiveReview());
            }

            return positiveReviews;
        }

        private Review GeneratePositiveReview()
        {
            var review = new Review();
            review.Rating = GeneratePositiveRating();
            review.Comment = GeneratePostiveComment();
            return review;
        }

        private double GeneratePositiveRating()
        {
            var mantissa = _rand.Next(3, 4);
            var ordinate = _rand.Next(0, 9);
            var rating = mantissa + 0.1*ordinate;
            return rating;
        }

        private string GeneratePostiveComment()
        {
            return _restaurantGenerator.Generate() + " " + _menuItemGenerator.Generate() + " " +
                   _feedbackGenerator.GeneratePositive();
        }

        private List<Review> GenerateNegativeReviews(int count)
        {
            var negativeReviews = new List<Review>();
            for (int i = 0; i < count; i++)
            {
                negativeReviews.Add(GenerateNegativeReview());
            }

            return negativeReviews;
        }

        private Review GenerateNegativeReview()
        {
            var review = new Review();
            review.Rating = GenerateNegativeRating();
            review.Comment = GenerateNegativeComment();
            return review;
        }

        private double GenerateNegativeRating()
        {
            var mantissa = _rand.Next(1, 2);
            var ordinate = _rand.Next(0, 9);
            var rating = mantissa + 0.1 * ordinate;
            return rating;
        }

        private string GenerateNegativeComment()
        {
            return _restaurantGenerator.Generate() + " " + _menuItemGenerator.Generate() + " " +
                   _feedbackGenerator.GenerateNegative();
        }
    }
}
