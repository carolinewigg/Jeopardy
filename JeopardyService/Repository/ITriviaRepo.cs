using JeopardyApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using static JeopardyApi.Models.GameBoardDto;
using static JeopardyApi.Models.GameBoardDto.CategoryDto;

namespace JeopardyService.Repository
{
    public interface ITriviaRepo
    {
        Task<List<CategoryDto>> GetCategoriesByRound(int roundId);
        Task<List<QuestionDto>> GetQuestionsByCategory(int categoryId);
    }
}
