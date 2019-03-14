using BlackJackServices.Services.Interfaces;
using BlackJackViewModels.Game;
using Microsoft.AspNetCore.Mvc;

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

        // POST: api/Game/StartGame
        [HttpPost]
        public IActionResult StartGame([FromBody] RequestStartGame model)
        {
            var result = _service.StartGame(model.UserId, model.CountBots);
            return Ok(result);
        }

        public class RequestStartGame
        {
            public int UserId { get; set; }
            public int CountBots { get; set; }
        }



    }
}