using System;
using System.ComponentModel.DataAnnotations;

namespace FileToDbQuestionInserter
{
    public class JeopardyQuestion
    {
        public string Category { get; set; }
        public DateTime Air_Date { get; set; }
        public string Question { get; set; }
        public string Value { get; set; }
        public string DollarValue => Value?.TrimStart('$').Replace(",", "");
        public string Answer { get; set; }
        public string Round { get; set; }
        public int Show_Number { get; set; }
        
    }

    public class DbJeopardyQuestion
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public DateTime AirDate { get; set; }
        public string Question { get; set; }
        public string DollarValue { get; set; }
        public string Answer { get; set; }
        public int RoundId { get; set; }
        public int ShowNumber { get; set; }
    }

}
