using Microsoft.AspNetCore.Mvc;
using SADIG_API.Application.Interfaces;

namespace SADIG_API.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CorrespondenceTypesController : Controller
    {
        private readonly ICorrespondenceTypeService _correspondenceTypeService;

        public CorrespondenceTypesController(ICorrespondenceTypeService correspondenceTypeService)
        {
            _correspondenceTypeService = correspondenceTypeService;
        }

        [HttpGet("GetCorrespondenceTypes")]
        public async Task<IActionResult> GetCorrespondenceTypes([FromQuery] bool available = false)
        {
            var correspondenceTypes = await _correspondenceTypeService.GetCorrespondenceTypes(available);
            return Ok(correspondenceTypes);
        }

        [HttpPost("AddCorrespondenceType")]
        public async Task<IActionResult> AddCorrespondenceType([FromForm] string correspondenceType, [FromForm] string description, [FromForm] bool available)
        {
            if (string.IsNullOrWhiteSpace(correspondenceType))
                return BadRequest("El tipo de correspondencia es requerido");

            var result = await _correspondenceTypeService.AddCorrespondenceType(correspondenceType, description, available);

            return Ok(new
            {
                success = result,
                message = result
                ? "Tipo de correspondencia registrado correctamente"
                : "No se insertó ningún registro. Puede que ya exista o no haya cambios."
            });
        }
    }
}
