using BlackJackServices.Services.Interfaces;
using BlackJackViewModels;
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
        public async Task<IActionResult> GetById(string id)
        {
            var player = await _service.GetById(id);
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
            return Ok(player);
        }

        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody] RequestSignUpAccountView model)
        {
            var jwt = _service.GetToken(model);
            var token = _service.GetTokenString(jwt);
            return Ok(new { token });
        }

    }
}