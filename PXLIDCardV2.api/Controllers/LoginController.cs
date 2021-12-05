using Microsoft.AspNetCore.Mvc;
using PXLIDCardV2.business.Contracts;
using PXLIDCardV2.domain;
using System.Threading.Tasks;

namespace PXLIDCardV2.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] EmailPassword emailPassword)
        {
            var user = await _loginService.Login(emailPassword.Email, emailPassword.Password);
            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }
    }
}
