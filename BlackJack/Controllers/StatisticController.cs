using BlackJackServices.Exceptions;
using BlackJackServices.Services.Interfaces;
using BlackJackViewModels.Statistic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlackJack.Controllers
{
    [Route("api/[controller]/[action]")]
    //[ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
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
                var game = await _service.GetGame(model.GameId, model.PlayerId);
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
    }
}
