using System.ComponentModel;
using _3rdLineQuestions.Model;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Runtime.CompilerServices;

namespace _3rdLineQuestions
{
    public class DataBaseHelper : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string NewQuestion
        {
            get => newQuestion;
            set
            {
                newQuestion = value;
                OnPropertyChanged();
            }
        }

        private string newQuestion;
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

            var newQ = dataContext.Questions.Max(q => q.QuestionId);
            NewQuestion = GetQuestion(newQ);
        }

        public string GetQuestion(int questionId)
        {
            var kinds = dataContext.Enums.Where(e => e.Kind.Equals("Kind"));
            var question = from qus in dataContext.Questions
                join kind in kinds on qus.Kind equals kind.Value
                where qus.QuestionId == questionId
                select new Tuple<DateTime,string,short>(qus.QuestionTime, kind.Name, qus.Duration);
            var q = question.FirstOrDefault();
            var duration = q.Item3.Equals(1) ? "Short" : "Long";
            return $"Entry added: {q.Item1} from {q.Item2} duration: {duration}";
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
