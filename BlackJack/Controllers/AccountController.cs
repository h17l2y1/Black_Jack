using BlackJackServices.Services.Interfaces;
using BlackJackViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlackJack.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id)
		{
            var player = await _service.GetById(id);
            return Ok(player);
        }

		[HttpGet]
		public async Task<IActionResult> GetUsers()
		{
			var users = await _service.GetUsers();
			return Ok(users);
		}

		[HttpPost]
		public async Task<IActionResult> LogIn([FromBody] SignUpAccountRequestView model)
		{
			var token = await _service.LogIn(model.UserName);
			return Ok(token);
		}

		[HttpPost]
		public async Task<IActionResult> SignUp([FromBody] SignUpAccountRequestView model)
		{
			var player = await _service.SignUp(model.UserName);
			return Ok(player);
		}
	}
}
