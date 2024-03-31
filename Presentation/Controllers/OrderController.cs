using Services.Abstraction.DataServices;
using Microsoft.AspNetCore.Mvc;
using Contract.Order;
using Domain.Exceptions;


namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IAdminService _adminService;

    public OrderController(IAdminService adminService)
    {
        _adminService = adminService;
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
    public IActionResult Add(OrderDtoNew order)
    {
        try
        {
            _adminService.OrderService.Add(order);

            return Ok();
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


    [HttpDelete("DeleteOrder")]
    public IActionResult Delete(int id)
    {
        try { 
        _adminService.OrderService.Delete(id);

        return Ok();
        }
        catch (NotFoundException ex)
        {
            return StatusCode(404, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }


    [HttpPut("UpdateOrderStatus")]
    public IActionResult Update(int id, int status, string comment)
    {
        try
        {
            _adminService.OrderService.UpdateState(id, status, comment);

            return Ok();
        }
        catch (NotFoundException ex)
        {
            return StatusCode(404, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
