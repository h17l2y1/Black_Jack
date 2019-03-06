using BlackJackServices.Services;
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
        private readonly IRegisterService _service;

        public AccountController(IRegisterService service)
        {
            _service = service;
        }

        // POST: api/Users/Register/
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            await _service.RegisterAsync(model);
            //jwt token
            //GenerateToken for User
            //if erroirt return badRequest
            return Ok(/*token*/);
        }

        [HttpPost]
        public IActionResult Login([FromBody] RegisterViewModel model)
        {
            _service.RegisterAsync(model);
            //jwt token
            //GenerateToken for User
            return Ok(/*token*/);
        }


        [HttpPost]
        [Authorize]
        public IActionResult Test()
        {
            //_service.Register(model);
            //jwt token
            //GenerateToken for User
            return Ok("You are autorize user");
        }


    }
}