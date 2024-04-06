using Contract;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Services.Abstraction.External;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IExrernalService _exrernalService;
        public PaymentController(IExrernalService exrernalService)  =>
            _exrernalService = exrernalService;


        [HttpGet("PaymentToken")]
        [Consumes("application/json")]
        public IActionResult Get()
        {
            try
            {
                var getWay = _exrernalService.PaymentService.CreateGetWay();

                return Ok(getWay.ClientToken.Generate());
            }
            catch (Exception ex)
            {
                return StatusCode(505, ex.Message);
            }
        }

        [HttpPost("Pay")]
        public IActionResult Pay(PaymentDto payment)
        {
            try
            {
               var paymentEnity = _exrernalService.PaymentService.GreateTransaction(payment);
        
                return Ok();
            }
            catch(PaymentFailedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(505, ex.Message);
            }
        }
    }
}
