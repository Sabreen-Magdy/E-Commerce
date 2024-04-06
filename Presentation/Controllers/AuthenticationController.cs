using Contract;
using Domain.Entities.Other;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction.External;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private readonly IExrernalService _service;
        public AuthenticationController(IExrernalService service)
        {
            _service = service;
        }

        [HttpGet("ConfirmEmail")]
        public IActionResult Confirm(string email)
        {
            try
            { 

                var redirectUrl = Request.Headers["RedirectUrl"];
                if (string.IsNullOrEmpty(redirectUrl))
                    return BadRequest("Must send RedirectUrl header");

                _service.EmailService.SendEmailConfirmation(new()
                {
                    To = email,
                    Body = redirectUrl!,
                    Subject = "تأكيد البريد الاكتروني"
                }, "./wwwroot/Html/confirm.html");
                return Ok();
            }
            catch (NotAllowedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(505, ex.InnerException);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto login) 
        {
            try { var user = await _service.AuthenticationService.Login(login);
                return Ok(user);
            }
            catch(UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException);
            }
        }

        [HttpPost("UpdatePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto passwordDto)
        {
            try
            {
                 await _service.AuthenticationService.ChangePassword(passwordDto);
                return Ok();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException);
            }
        }
        
        
        [HttpPost("ForgetPassword")] 
        public async Task<IActionResult> ResetPassword(string email)
        {
            try
            {
               var tokenOtp = await _service.AuthenticationService.RestPassword(email);
                
                _service.EmailService.SendEmailReset(new()
                {
                    To = email,
                    Body = tokenOtp.Otp,
                    Subject = "اعادة تعيين كلمة المرور"
                }, "./wwwroot/Html/forget.html");
                
                return Ok(tokenOtp);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException);
            }
        }
        
        [HttpPost("ResetPassword")] 
        public async Task<IActionResult> ResetPassword(ForgetPasswordDto passwordDto)
        {
            try
            {
                await _service.AuthenticationService.RestPassword(passwordDto);
                
                return Ok();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException);
            }
        }

        [HttpPost("Registeration")]
        public  async Task<IActionResult> Register(CustomerAddDto customer)
        {
            try
            {
                var user = await _service.AuthenticationService.Register(customer);
              
                return Ok(user);
            }
            catch(AlreadyExistException ex)
            {
                return Conflict(ex.Message); 
            }
            catch(NotAllowedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException);
            }
        }
     
        [HttpDelete("DeleteAccount")]
        public async Task<IActionResult> Delete(int customerId)
        {
            try
            {
                await _service.AuthenticationService.DeleteCustomer(customerId);

                return Ok();
            }
            catch (AlreadyExistException ex)
            {
                return Conflict(ex.Message);
            }
            catch (NotAllowedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException);
            }
        }

    }
}
