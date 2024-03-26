using Contract;
using Domain.Enums;
using Services.Abstraction.DataServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class CustomerController : ControllerBase
{
    private readonly IAdminService _adminService;

    public CustomerController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    
    [HttpGet("GetAllCustomers")]
    public IActionResult GetAll()
    {
        var customer = _adminService.CustomerService.GetAll();

        if (customer == null) NotFound("No Cudtomers in System");
        return Ok(customer);
    }

    [HttpGet("GetCustomerById")]
    public IActionResult GetCustomer(int id)
    {
        var customer = _adminService.CustomerService.Get(id);

        if (customer == null) NotFound("this Customer Not Found");
        return Ok(customer);
    }
    
    [HttpGet("GetCustomerByName")]
    public IActionResult GetCustomer(string name)
    {
        var customers = _adminService.CustomerService.Get(name);

        if (customers == null) NotFound($"No Cudtomers with {name} Name Found");
        return Ok(customers);
    }

    [HttpGet("GetFavourites")]
    public IActionResult GetFavourites(int id)
    {
        var favourites = _adminService.CustomerService.GetFavourites(id);

        if (favourites == null) NotFound("Empty List");
        return Ok(favourites);
    }

    [HttpGet("GetOrders")]
    public IActionResult GetOrders(int id)
    {
        var orders = _adminService.CustomerService.GetOrders(id);

        if (orders == null) NotFound("Empty Orders");
        return Ok(orders);
    }
    
    [HttpGet("GetCart")]
    public IActionResult GetCart(int id)
    {
       
        var carts = _adminService.CustomerService.GetCart(id);

        if (carts == null) NotFound("Empty Carts");
        return Ok(carts);
    }

    [HttpGet("GetReviews")]
    public IActionResult GetReviews(int id)
    {

        var reviews = _adminService.CustomerService.GetReviews(id);

        if (reviews == null) NotFound("Empty Reviews");
        return Ok(reviews);
    }


    [HttpPost("AddCustomers")]
    public IActionResult Add(CustomerAddDto customer)
    {
        _adminService.CustomerService.Add(customer);
       
        return Ok();
    }

   
    [HttpDelete("DeleteCustomers")]
    public IActionResult Delete(int id)
    {
        _adminService.CustomerService.Delete(id);

        return Ok();
    }


    [HttpPut("UpdateCustomers")]
    public IActionResult Update(CustomerDto customerDto)
    {
        _adminService.CustomerService.Update(customerDto);

        return Ok();
    }
}
