using BlackJackServices.Services.Interfaces;
using BlackJackViewModels.Statistic;
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
        public async Task<IActionResult> GetAllGames([FromBody] RequestGetAllGamesStatisticView model)
        {
            var gameStory = await _service.GetAllGames(model.PlayerId);
            return Ok(gameStory);
        }

        [HttpPost]
        public async Task<IActionResult> GetAllPlayers([FromBody] RequestGetAllPlayersStatisticView model)
        {
            var story = await _service.GetAllPlayers(model.GameId);
            return Ok(story);
        }

        [HttpPost]
        public async Task<IActionResult> GetAllMoves([FromBody] RequestGetAllMovesStatisticView model)
        {
            var moves = await _service.GetAllMoves(model.GameId);
            return Ok(moves);
        }

    }
}