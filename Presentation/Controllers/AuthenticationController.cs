using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services.Abstraction.DataServices;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration; 
        private readonly ILoginService _loginService;

        public AuthenticationController(IConfiguration configuration, ILoginService loginService)
        {
            _configuration = configuration; 
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult Login(string email, string password) 
        {
            var user = _loginService.Login(email, password);

            if(user == null)
                return Unauthorized();
            
            return Ok(new { token = _loginService.GenerateJSONWebToken(user) });
        }
    }
}
