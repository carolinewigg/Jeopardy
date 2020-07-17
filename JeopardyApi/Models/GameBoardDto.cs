using System.Collections.Generic;

namespace JeopardyApi.Models
{
    public class GameBoardDto
    {
        public int RoundId { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public class CategoryDto
        {
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }
            public List<QuestionDto> Questions { get; set; }
            public class QuestionDto
            {
                public string Question { get; set; }
                public int? DollarValue { get; set; }
                public string Answer { get; set; }
            }
        }
    }
}
