using AdventureWorks.Core.Abstractions.Operations;
using AdventureWorks.Core.BusinessModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdventureWorks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserOperations _userOperations;
        public UsersController(IUserOperations userOperations)
        {
            _userOperations = userOperations;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                await _userOperations.Login(model, HttpContext);
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                await _userOperations.Register(model, HttpContext);
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _userOperations.Logout(HttpContext);
            return Ok();
        }
    }
}
