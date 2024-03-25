using Services.Abstraction.DataServices;
using Microsoft.AspNetCore.Mvc;
using Contract.Order;


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
        var order = _adminService.OrderService.GetAll();

        if (order == null) NotFound("No order in System");
        return Ok(order);
    }

    [HttpGet("GetOrderById")]
    public IActionResult GetOrder(int id)
    {
        var order = _adminService.OrderService.Get(id);

        if (order == null) NotFound("this order Not Found");
        return Ok(order);
    }

    [HttpGet("GetOrderByCustomerName")]
    public IActionResult GetOrder(string name)
    {
        var order = _adminService.OrderService.Get(name);

        if (order == null) NotFound($"No order with {name} Name Found");
        return Ok(order);
    }

    [HttpPost("AddOrder")]
    public IActionResult Add(OrderDtoNew order)
    {
        _adminService.OrderService.Add(order);

        return Ok();
    }


    [HttpDelete("DeleteOrder")]
    public IActionResult Delete(int id)
    {
        _adminService.OrderService.Delete(id);

        return Ok();
    }


    [HttpDelete("UpdateOrderStatus")]
    public IActionResult Update(int id, int status)
    {
        _adminService.OrderService.Updatestatus(id, status);

        return Ok();
    }
}
