using Microsoft.AspNetCore.Mvc;
using SADIG_API.Application.Interfaces;

namespace SADIG_API.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreasController : Controller
    {
        private readonly IAreaService _areaService;

        public AreasController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        [HttpGet("GetAllAreas")]
        public async Task<IActionResult> GetAllAreas([FromQuery] bool available = true)
        {
            var areas = await _areaService.GetAllAreas(available);
            return Ok(areas);
        }
    }
}
