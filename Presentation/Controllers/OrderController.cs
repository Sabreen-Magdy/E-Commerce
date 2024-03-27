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


   

    

    [HttpPost("AddOrder")]
    public IActionResult Add(OrderDtoNew order)
    {
        _adminService.OrderService.Add(order);

        return Ok();
    }


    
}
