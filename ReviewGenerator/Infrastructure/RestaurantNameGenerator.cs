using System;

namespace ReviewGenerator.Infrastructure
{
    public class RestaurantNameGenerator
    {
        private Random _rand = new Random();
        private const string Restaurant1 = "Barbeque Nation";
        private const string Restaurant2 = "Sigree";
        private const string Restaurant3 = "Mainland China";
        private const string Restaurant4 = "Global Punjab";
        private const string Restaurant5 = "Northern Frontier";

        private const int MenuItemCount = 5;

        public string Generate()
        {
            var randNum = _rand.Next(1, MenuItemCount);
            switch (randNum)
            {
                case 1:
                    return Restaurant1;
                case 2:
                    return Restaurant2;
                case 3:
                    return Restaurant3;
                case 4:
                    return Restaurant4;
                default:
                    return Restaurant5;
            }
        }
    }
}
