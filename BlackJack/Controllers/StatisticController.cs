using BlackJackServices.Exceptions;
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

        [HttpGet("{userName}")]
        public async Task<IActionResult> GetGame(string userName, string gameId)
        {
            if (ModelState.IsValid)
            {
                var game = await _service.GetGame(gameId, userName);
                return Ok(game);
            }
            throw new ModelNotValidException("GetGame/ url error");
        }

        [HttpGet("{page}")]
        public async Task<IActionResult> GetPagination(int page, int size)
        {
            if (ModelState.IsValid)
            {
                var data = await _service.GetPagination(page, size);
                return Ok(data);
            }
            throw new ModelNotValidException("Pagination/ url error");
        }

        [HttpGet("{page}")]
        public async Task<IActionResult> GetUserStat(int page, int size, string userName)
        {
            if (ModelState.IsValid)
            {
                var userStat = await _service.GetUserStat(page, size, userName);
                return Ok(userStat);
            }
            return BadRequest("GetUserStat/ url error");
            //throw new ModelNotValidException("GetUserStat/ url error");
        }

    }
}
