using JeopardyApi.Models;
using JeopardyService.Models;
using JeopardyService.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static JeopardyApi.Models.GameBoardDto;
using static JeopardyApi.Models.GameBoardDto.CategoryDto;

namespace JeopardyService.Service
{
    public class TriviaService : ITriviaService
    {
        private readonly ITriviaRepo _repo;
        public TriviaService(ITriviaRepo repo)
        {
            _repo = repo;
        }
        public async Task<GameBoardDto> GetGameBoardByRound(int roundId)
        {
            try
            {
                var MyGameBoard = new GameBoardDto()
                {
                    RoundId = roundId,
                    Categories = new List<CategoryDto>()
                };

                //get random categories by round id where count > 5
                var SelectedCats = await _repo.GetCategoriesByRound(roundId);
                MyGameBoard.Categories.AddRange(SelectedCats);

                foreach (var cat in MyGameBoard.Categories)
                {
                    cat.Questions = new List<QuestionDto>();
                    var CategoryQuestions = await _repo.GetQuestionsByCategory(cat.CategoryId);
                    cat.Questions.AddRange(CategoryQuestions);

                }

                return MyGameBoard;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
