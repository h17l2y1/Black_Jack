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
            var userId = "6ae7e49b-b3ba-4c33-b7ad-4f80c4fb143a";
            var result = await _service.StartGame(userId, model.CountBots);
            return Ok(result);
        }

        public class RequestStartGame
        {
            public string UserId { get; set; }
            public int CountBots { get; set; }
        }

        [HttpPost]
        public IActionResult GetCard()
        {
            //var card = _service.(model.UserId, model.GameId);

            return Ok("resuly");
        }

        public class RequestGetCard
        {
            public string UserId { get; set; }
            public int GameId { get; set; }
        }

    }
}