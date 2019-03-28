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
            await _service.RemoveAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var user = await _service.FindByIdAsync(id);
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string id)
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] RegisterView model)
        {
            await _service.AddAsync(model);
            var jwt = _service.GetToken(model);
            var str = _service.GetTokenString(jwt);

            return Ok(str);
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody] RegisterView model)
        {
            if (_service.UserIsExist(model.Name) == false)
            {
                return await SignUp(model);
            }

            return Ok("You are autorized user");
        }

    }
}