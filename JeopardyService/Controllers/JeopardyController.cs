using System;
using System.Threading.Tasks;
using JeopardyApi;
using JeopardyApi.Models;
using JeopardyService.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace JeopardyService.Controllers
{
    [ApiController]
    public class InboxNotificationController : Controller, IJeopardyApi
    {
        private readonly ILogger _logger;
        private readonly ITriviaService _service;

        public InboxNotificationController(ILogger<InboxNotificationController> logger, ITriviaService service)
        {
            _logger = logger;
            _service = service;
        }


        [HttpGet, Route("api/GetGameBoardByRound/{roundId}")]
        public async Task<GameBoardDto> GetGameBoardByRound(int roundId)
        {
            _logger.LogInformation($"GET: api/GetGameBoardByRound/{roundId}");
            try
            {
                return await _service.GetGameBoardByRound(roundId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GET: api/GetGameBoardByRound/{roundId}");
                throw ex;
            }

        }


    }
}
