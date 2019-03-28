using BlackJackEntities.Entities;
using BlackJackServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        // GET: api/Users/GetAll
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            return Ok(result);
        }

        // GET: api/Users/Get
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _service.Get(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: api/Users/Add/
        [HttpPost]
        public IActionResult Add([FromBody] Player user)
        {
            _service.Add(user);
            return Ok(User);
        }

        // PUT: api/Users/Update/5
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Player user)
        {
            _service.Update(user);
            return NoContent();
        }

        // DELETE: api/Users/Remove/5
        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] string id)
        {
            var result = _service.Get(id);
            _service.Remove(id);

            return Ok(result);
        }
    }
}