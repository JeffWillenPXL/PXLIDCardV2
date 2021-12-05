using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PXLIDCardV2.business.Contracts;
using PXLIDCardV2.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PXLIDCardV2.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectorController : ControllerBase
    {
        private readonly ILectorService _lectorService;

        public LectorController(ILectorService lectorService)
        {
            _lectorService = lectorService;
        }

        [HttpGet ("evaluations")]
        public async Task<IActionResult> GetLectorEvaluations([FromQuery] int lectorId)
        {
            var evaluations = await _lectorService.GetLectorEvaluations(lectorId);
            if (evaluations != null) return Ok(evaluations);
            return NotFound();
        }

        [HttpGet("evaluations/{evaluationId}")]
        public async Task<IActionResult> GetStudentEvaluationsForEvaluations([FromRoute]int evaluationId)
        {
            var studentEvaluations = await _lectorService.GetStudentsForEvaluation(evaluationId);
            if (studentEvaluations != null) return Ok(studentEvaluations);
            return NotFound();
        }

        [HttpPut("register")]
        public async Task<IActionResult> RegisterStudent([FromBody] StudentEvaluation studentEvaluation)
        {
            await _lectorService.RegisterStudent(studentEvaluation);
            return Ok();
        }
    }
}
