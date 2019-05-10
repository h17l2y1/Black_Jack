using BlackJackServices.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlackJack.Controllers
{
	[Route("api/[controller]/[action]")]
	[Authorize(AuthenticationSchemes = "Bearer")]
	//[ApiController]
	public class StatisticController : ControllerBase
	{
		private readonly IStatisticService _service;

		public StatisticController(IStatisticService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetGame(string userName, string gameId)
		{
			var game = await _service.GetGame(gameId, userName);
			return Ok(game);
		}

		[HttpGet]
		public async Task<IActionResult> GetPagination(int page, int size)
		{
			var data = await _service.GetPagination(page, size);
			return Ok(data);
		}

		[HttpGet]
		public async Task<IActionResult> GetUserStat(int page, int size, string userName)
		{
			var userStat = await _service.GetUserStat(page, size, userName);
			return Ok(userStat);
		}

	}
}
