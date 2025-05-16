using Microsoft.AspNetCore.Mvc;
using SADIG_API.Application.Interfaces;

namespace SADIG_API.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectionsController : Controller
    {
        private readonly IDirectionService _directionService;

        public DirectionsController(IDirectionService directionService)
        {
            _directionService = directionService;
        }

        [HttpGet("GetAllDirections")]
        public async Task<IActionResult> GetAllDirections([FromQuery] bool available = true)
        {
            var directions = await _directionService.GetAllDirections(available);
            return Ok(directions);
        }
        
    }
}
