using System;

namespace ReviewGenerator.Infrastructure
{
    public class MenuItemGenerator
    {
        private Random _rand = new Random();
        private const string MenuItem1 = "Seekh Kebab";
        private const string MenuItem2 = "Tangdi Kebab";
        private const string MenuItem3 = "Reshmi Kebab";
        private const string MenuItem4 = "Banjara Kebab";
        
        private const int MenuItemCount = 4;

        public string Generate()
        {
            var randNum = _rand.Next(1, MenuItemCount);
            switch (randNum)
            {
                case 1:
                    return MenuItem1;
                case 2:
                    return MenuItem2;
                case 3:
                    return MenuItem3;
                default:
                    return MenuItem4;
            }
        }
    }
}
