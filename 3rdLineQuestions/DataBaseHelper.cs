using Microsoft.Extensions.Configuration;
using System.IO;
using ThirdLineQs.Model;

namespace ThirdLineQs
{
    public class DataBaseHelper
    {
        private readonly ThirdLineQuestions dataContext;

        public DataBaseHelper()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json");
            var config = builder.Build();
            dataContext = new ThirdLineQuestions(config);
        }

        public void AddQuestion(short kind, short duration)
        {
            dataContext.Add(new Questions
            {
                Kind = kind,
                Duration = duration,
                QuestionTime = DateTime.Now
            });
            dataContext.SaveChanges();
        }
    }
}
