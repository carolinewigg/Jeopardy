using JeopardyApi.Models;
using Refit;
using System.Threading.Tasks;

namespace JeopardyApi
{
    public interface IJeopardyApi
    {
        [Get("/api/GetGameBoardByRound/{roundId}")]
        Task<GameBoardDto> GetGameBoardByRound(int roundId);
    }
}
