using System.ComponentModel.DataAnnotations;

namespace FileToDbQuestionInserter
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
