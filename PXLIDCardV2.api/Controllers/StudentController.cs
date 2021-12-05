using Microsoft.AspNetCore.Mvc;
using PXLIDCardV2.business.Contracts;
using System.Threading.Tasks;

namespace PXLIDCardV2.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;


        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("{studentId}/evaluations")]
        public async Task<IActionResult> GetEvaluationsForStudent( [FromRoute] int studentId)
        {
            var studentEvaluations = await _studentService.GetEvaluationsForStudent(studentId);
            if (studentEvaluations != null)
            {
                return Ok(studentEvaluations);
            }

            return NotFound();
        }
    }
}
