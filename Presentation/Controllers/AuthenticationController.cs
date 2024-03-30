using Contract;
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

        [HttpPost("Login")]
        public IActionResult Login(LoginDto login) 
        {
            var user = _loginService.Login(login);

            if(user == null)
                return Unauthorized();
            
            return Ok(new {message="success", id = user.Id,token = _loginService.GenerateJSONWebToken(user) });
        }
    }
}
