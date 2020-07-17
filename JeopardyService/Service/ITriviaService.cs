using JeopardyApi.Models;
using System.Threading.Tasks;

namespace JeopardyService.Service
{
    public interface ITriviaService
    {
        Task<GameBoardDto> GetGameBoardByRound(int roundId);
    }
}
