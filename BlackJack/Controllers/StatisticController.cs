using BlackJackServices.Services.Interfaces;
using BlackJackViewModels.Statistic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlackJack.Controllers
{
  [Route("api/[controller]/[action]")]
  [ApiController]
  //[Authorize(AuthenticationSchemes = "Bearer")]
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
      var allGames = await _service.GetAllGames(model.PlayerId);
      return Ok(allGames);
    }

    [HttpPost]
    public async Task<IActionResult> GetGame([FromBody] RequestGetGameStatisticView model)
    {
      var game = await _service.GetGame(model.GameId, model.PlayerId);
      return Ok(game);
    }

    [HttpPost]
    public async Task<IActionResult> Pagination([FromBody] RequestPaginationStatisticView model)
    {
      var data = await _service.GetPagination(model.Page, model.Size);
      return Ok(data);
    }
  }
}
