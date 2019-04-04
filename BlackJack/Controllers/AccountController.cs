using BlackJackServices.Services.Interfaces;
using BlackJackViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlackJack.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            var player = await _service.Remove(id);
            return Ok(player);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var player = await _service.Get(id);
            return Ok(player);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var players = await _service.GetAllAsync();
            return Ok(players);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] RequestSignUpAccountView model)
        {
            var player = await _service.AddAsync(model);
            var jwt = _service.GetToken(model);
            var str = _service.GetTokenString(jwt);
            return Ok(player);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody] RequestSignUpAccountView model)
        {
            if (_service.UserIsExist(model.Name) == false)
            {
                return await SignUp(model);
            }
            return Ok("You are autorized user");
        }

    }
}