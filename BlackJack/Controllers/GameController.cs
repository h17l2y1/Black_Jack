using BlackJackServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlackJack.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Authorize]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _service;

        public GameController(IGameService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> StartGame([FromBody] RequestStartGame model)
        {
            var result = await _service.StartGame(model.UserId, model.CountBots);
            return Ok(result);
        }

        public class RequestStartGame
        {
            public string UserId { get; set; }
            public int CountBots { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> GetCard([FromBody] RequestGetCard model)
        {
            await _service.AddOneCard(model.UserId, model.GameId);
            return Ok("Card added");
        }

        public class RequestGetCard
        {
            public string UserId { get; set; }
            public string GameId { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> Stop([FromBody] RequestStop model)
        {
            var winners = await _service.Stop(model.UserId, model.GameId);
            return Ok(winners);
        }

        public class RequestStop
        {
            public string UserId { get; set; }
            public string GameId { get; set; }
        }
    }
}