using Microsoft.AspNetCore.Mvc;
using SADIG_API.Application.Interfaces;
using SADIG_API.Infrastructure.Services;

namespace SADIG_API.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShiftTypesController : Controller
    {
        private readonly IShiftTypeService _shiftTypeService;

        public ShiftTypesController(IShiftTypeService shiftTypeService)
        {
            _shiftTypeService = shiftTypeService;
        }

        [HttpGet("GetShiftTypes")]
        public async Task<IActionResult> GetShiftTypes([FromQuery] bool available = true)
        {
            var shiftTypes = await _shiftTypeService.GetShiftTypes(available);

            return Ok(shiftTypes);
        }
    }
}
