using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JeopardyService.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<JeopardyQuestion> Questions { get; set; } 
    }

    public class GetValidCategoriesByRoundResult
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    public class GetQuestionsByCategoryResult
    {
        public string Question { get; set; }
        public int? DollarValue { get; set; }
        public string Answer { get; set; }
    }
}
