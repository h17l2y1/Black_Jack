using BlackJackServices.Services.Interfaces;
using BlackJackViewModels;
using BlackJackViewModels.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlackJack.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Authorize]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _service;

        public GameController(IGameService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> StartGame([FromBody] RequestStartGameView model)
        {
            var result = await _service.Start(model.UserId, model.CountBots);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> GetCard([FromBody] RequestGetCardGameView model)
        {
            var card = await _service.AddOneCard(model.UserId, model.GameId);
            return Ok(card);
        }

        [HttpPost]
        public async Task<IActionResult> Stop([FromBody] RequestStopGameView model)
        {
            var winners = await _service.Stop(model.UserId, model.GameId);
            return Ok(winners);
        }

    }
}