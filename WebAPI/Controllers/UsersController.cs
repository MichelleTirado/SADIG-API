using Microsoft.AspNetCore.Mvc;
using SADIG_API.Application.Interfaces;

namespace SADIG_API.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers([FromQuery] bool available = true)
        {
            var users = await _userService.GetUsers(available);
            return Ok(users);
        }
    }
}
