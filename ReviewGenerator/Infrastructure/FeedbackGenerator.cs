using System;

namespace ReviewGenerator.Infrastructure
{
    public class FeedbackGenerator
    {
        private Random _rand = new Random();
        private const string Feedback1 = "Good";
        private const string Feedback2 = "Very Good";
        private const string Feedback3 = "Awesome";

        private const string Feedback4 = "Bad";
        private const string Feedback5 = "Very Bad";
        private const string Feedback6 = "Horrible";

        private const int FeedbackCountPerCategory = 3;

        public string GeneratePositive()
        {
            var randNum = _rand.Next(1, FeedbackCountPerCategory);
            switch (randNum)
            {
                case 1:
                    return Feedback1;
                case 2:
                    return Feedback2;
                default:
                    return Feedback3;
            }
        }

        public string GenerateNegative()
        {
            var randNum = _rand.Next(1, FeedbackCountPerCategory);
            switch (randNum)
            {
                case 1:
                    return Feedback4;
                case 2:
                    return Feedback5;
                default:
                    return Feedback6;
            }
        }
    }
}
