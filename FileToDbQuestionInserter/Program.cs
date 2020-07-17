using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileToDbQuestionInserter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(@"C:\Users\Weena\source\repos\Jeopardy\FileToDbQuestionInserter\Content\JEOPARDY_QUESTIONS1.json"))
                {
                    // Read the stream to a string, and write the string to the console.
                    string line = await sr.ReadToEndAsync();

                    var MyQuestions = JsonConvert.DeserializeObject<List<JeopardyQuestion>>(line);

                    var jContext = new JeopardyContext();
                    var dbCategories = jContext.Categories.ToList();

                    var Categories = MyQuestions.Select(q => q.Category.ToUpper()).Except(dbCategories.Select(c => c.CategoryName)).Distinct().ToList();

                    InsertCategories(Categories);

                    var dbRounds = jContext.Rounds.ToList();

                    var Rounds = MyQuestions.Select(r => r.Round).Distinct().Except(dbRounds.Select(c => c.RoundName)).ToList();

                    InsertRounds(Rounds);

                    //InsertQuestions(MyQuestions, dbCategories, dbRounds);

                }
                Console.WriteLine("Goodbye World!");
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public static void InsertCategories(List<string> Categories)
        {
            Console.WriteLine("Entered InsertCategories!");

            var MyCategories = new List<Category>();
            foreach (var cat in Categories)
            {
                MyCategories.Add(new Category()
                {
                    CategoryName = cat
                });

            }

            using (var context = new JeopardyContext())
            {
                context.Categories.AddRange(MyCategories);
                context.SaveChanges();
            }
            Console.WriteLine("Categories inserted!");
        }

        public static void InsertRounds(List<string> Rounds)
        {
            Console.WriteLine("Entered InsertRounds!");

            var MyRounds = new List<Round>();
            foreach (var r in Rounds)
            {
                MyRounds.Add(new Round()
                {
                    RoundName = r
                });

            }

            using (var context = new JeopardyContext())
            {
                context.Rounds.AddRange(MyRounds);
                context.SaveChanges();
            }
            Console.WriteLine("Rounds inserted!");
        }

        public static void InsertQuestions(List<JeopardyQuestion> questions, List<Category> categories, List<Round> rounds)
        {
            Console.WriteLine("Entered InsertQuestions!");
            var MyJeopardyQuestions = new List<DbJeopardyQuestion>();
            foreach (var question in questions)
            {
                MyJeopardyQuestions.Add(new DbJeopardyQuestion()
                {
                    CategoryId = categories.Where(c => Regex.Unescape(question.Category.ToUpper()) == c.CategoryName).Select(c => c.Id).FirstOrDefault(),
                    AirDate = question.Air_Date,
                    Question = question.Question,
                    DollarValue = question.DollarValue,
                    Answer = question.Answer,
                    RoundId = rounds.Where(r => question.Round == r.RoundName).Select(r => r.Id).FirstOrDefault(),
                    ShowNumber = question.Show_Number,
                });

            }
            Console.WriteLine("Questions Converted!");
            var questionswithoutCategory = MyJeopardyQuestions.Where(q => q.CategoryId > 27916 || q.CategoryId < 1).ToList();
            using (var context = new JeopardyContext())
            {
                context.Questions.AddRange(MyJeopardyQuestions);
                context.SaveChanges();
                Console.WriteLine("Questions inserted!");
            }
        }
    }
}
