using Microsoft.AspNetCore.Mvc;
using Contract.Order;
using Domain.Exceptions;
using Services.Abstraction;
using Services.Abstraction.External;
using Services.External;


namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IAdminService _adminService;
    private readonly IExrernalService _exrernalService;

    public OrderController(IAdminService adminService, IExrernalService exrernalService)
    {
        _adminService = adminService;
        _exrernalService = exrernalService;
    }


    [HttpGet("GetAllOrders")]
    public IActionResult GetAll()
    {
        try
        {
            var order = _adminService.OrderService.GetAll();

            if (order == null) NotFound("No order in System");
            return Ok(order);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("GetOrderById")]
    public IActionResult GetOrder(int id)
    {
        try
        {
            var order = _adminService.OrderService.Get(id);

            if (order == null) NotFound("this order Not Found");
            return Ok(order);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("GetOrderByCustomerName")]
    public IActionResult GetOrder(string name)
    {
        try {
            var order = _adminService.OrderService.Get(name);

            if (order == null) NotFound($"No order with {name} Name Found");
            return Ok(order);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
  
    [HttpPost("AddOrder")]
    public IActionResult Add(OrderPaymentDto order)
    {
        try
        {
            int orderId = _adminService.OrderService.Add(order.Order);

            var paymentEnity = _exrernalService.PaymentService
                     .CreateTransaction(order.Payment);

            _adminService.OrderService.AddPayment(orderId, paymentEnity);

            return Ok();
        }
        catch (PaymentFailedException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (NotAllowedException ex)
        {
            return StatusCode(400, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }


    //[HttpDelete("DeleteOrder")]
    //public IActionResult Delete(int id)
    //{
    //    try { 
    //    _adminService.OrderService.Delete(id);

    //    return Ok();
    //    }
    //    catch (NotFoundException ex)
    //    {
    //        return StatusCode(404, ex.Message);
    //    }
    //    catch (Exception ex)
    //    {
    //        return StatusCode(500, ex.Message);
    //    }
    }


    //[HttpPut("UpdateOrderStatus")]
    //public IActionResult Update(int id, int status, string comment)
    //{
    //    try
    //    {
    //        _adminService.OrderService.UpdateState(id, (Or)status, comment);

    //        return Ok();
    //    }
    //    catch (NotFoundException ex)
    //    {
    //        return StatusCode(404, ex.Message);
    //    }
    //    catch (Exception ex)
    //    {
    //        return StatusCode(500, ex.Message);
    //    }
    //}
}
