using Microsoft.AspNetCore.Mvc;
using SADIG_API.Application.DTOs;
using SADIG_API.Application.Interfaces;

namespace SADIG_API.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CorrespondenceController : Controller
    {
        private readonly ICorrespondenceService _correspondenceService;

        public CorrespondenceController(ICorrespondenceService correspondenceService)
        {
            _correspondenceService = correspondenceService;
        }

        [HttpPost("AddCorrespondence")]
        public async Task<IActionResult> AddCorrespondence(CorrespondenceDto correspondence)
        {
            var result = await _correspondenceService.AddCorrespondence(correspondence);

            return Ok();
        }
    }
}
