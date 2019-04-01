using BlackJackServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlackJack.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Authorize]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticService _service;

        public StatisticController(IStatisticService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> GetAllPGamesFromPlayer([FromBody] RequestStop model)
        {
            var story = await _service.GetAllPGamesFromPlayer(model.PlayerId);
            return Ok(story);
        }

        [HttpPost]
        public async Task<IActionResult> GetAllPlayersFromGame([FromBody] RequestStop model)
        {
            var story = await _service.GetAllPlayersFromGame(model.GameId);
            return Ok(story);
        }

        [HttpPost]
        public async Task<IActionResult> GetAllMovesFromGame([FromBody] RequestStop model)
        {
            var moves = await _service.GetAllMovesFromGame(model.GameId);
            return Ok(moves);
        }

        public class RequestStop
        {
            public string PlayerId { get; set; }
            public string GameId { get; set; }
        }

    }
}