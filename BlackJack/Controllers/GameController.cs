using BlackJackServices.Services.Interfaces;
using BlackJackViewModels;
using BlackJackViewModels.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlackJack.Controllers
{
	[Route("api/[controller]/[action]")]
	[Authorize(AuthenticationSchemes = "Bearer")]
	//[ApiController]
	public class GameController : BaseController
	{
		private readonly IGameService _service;

		public GameController(IGameService service)
		{
			_service = service;
		}

		[HttpPost]
		public async Task<IActionResult> StartGame([FromBody] StartGameRequestView model)
		{
			var stardGameModel = await _service.Start(model.UserId, model.CountBots);
			return Ok(stardGameModel);
		}

		[HttpGet]
        public async Task<IActionResult> GetCard(string userId, string gameId)
		{
            var card = await _service.AddOneCard(userId, gameId);
            return Ok(card);
        }

		[HttpPost]
		public async Task<IActionResult> Stop([FromBody] StopGameRequestView model)
		{
			var stopGameModel = await _service.Stop(model.UserId, model.GameId);
			return Ok(stopGameModel);
		}

	}
}
