using BlackJackServices.Exceptions;
using BlackJackServices.Services.Interfaces;
using BlackJackViewModels.Statistic;
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

        [HttpPost]
        public async Task<IActionResult> GetGame([FromBody] RequestGetGameStatisticView model)
        {
            if (ModelState.IsValid)
            {
                var game = await _service.GetGame(model.GameId, model.UserName);
                return Ok(game);
            }
            throw new ModelNotValidException("RequestGetGameStatisticView");
        }

        [HttpPost]
        public async Task<IActionResult> Pagination([FromBody] RequestPaginationStatisticView model)
        {
            if (ModelState.IsValid)
            {
                var data = await _service.GetPagination(model.Page, model.Size);
                return Ok(data);
            }
            throw new ModelNotValidException("RequestPaginationStatisticView");
        }

        [HttpPost]
        public async Task<IActionResult> GetUserStat([FromBody] RequestGetUserStatStatisticView model)
        {
            if (ModelState.IsValid)
            {
                var userStat = await _service.GetUserStat(model.Page, model.Size, model.UserName);
                return Ok(userStat);
            }
            throw new ModelNotValidException("RequestGetUserStatStatisticView");
        }
    }
}
