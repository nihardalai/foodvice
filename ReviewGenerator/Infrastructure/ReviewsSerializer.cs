using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using ReviewGenerator.Converters;
using ReviewGenerator.Models;
using System.Collections.Generic;

namespace ReviewGenerator.Infrastructure
{
    public class ReviewsSerializer
    {
        public string Save(List<Review> reviews)
        {
            try
            {
                var json = JsonConvert.SerializeObject(reviews.ToArray(), new DecimalFormatConverter());
                var filePath = GetFilePath();
                File.WriteAllText(filePath, json);
                return "Json data written to '" + filePath + "'.";
            }
            catch (Exception ex)
            {
                return "Error while saving reviews";
            }
        }

        private string GetFilePath()
        {
            var appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return Path.Combine(appPath, "data.txt");
        }
    }
}
