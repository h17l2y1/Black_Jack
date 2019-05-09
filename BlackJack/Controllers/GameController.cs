using BlackJackServices.Exceptions;
using BlackJackServices.Services.Interfaces;
using BlackJackViewModels;
using BlackJackViewModels.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlackJack.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _service;

        public GameController(IGameService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> StartGame([FromBody] StartGameRequestView model)
        {
            if (ModelState.IsValid)
            {
                var stardGameModel = await _service.Start(model.UserId, model.CountBots);
                return Ok(stardGameModel);
            }
            throw new ModelNotValidException("RequestStartGameView");
        }

        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetCard(string userId, string gameId)
        {
            if (ModelState.IsValid)
            {
                var card = await _service.AddOneCard(userId, gameId);
                return Ok(card);
            }
            throw new ModelNotValidException("url error");
        }

        [HttpPost]
        public async Task<IActionResult> Stop([FromBody] StopGameRequestView model)
        {
            if (ModelState.IsValid)
            {
                var stopGameModel = await _service.Stop(model.UserId, model.GameId);
                return Ok(stopGameModel);
            }
            throw new ModelNotValidException("RequestStopGameView");
        }

    }
}
