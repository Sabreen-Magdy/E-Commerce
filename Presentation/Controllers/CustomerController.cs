using Contract.Customer;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction.DataServices;
using Microsoft.AspNetCore.Http;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    
    [HttpGet("GetAllCustomers")]
    public IActionResult GetAll()
    {
        var customer = _customerService.GetAll();

        if (customer == null) NotFound("No Cudtomers in System");
        return Ok(customer);
    }

    [HttpGet("GetCustomerById")]
    public IActionResult GetCustomer(int id)
    {
        var customer =  _customerService.Get(id);

        if (customer == null) NotFound("this Customer Not Found");
        return Ok(customer);
    }
    
    [HttpGet("GetCustomerByName")]
    public IActionResult GetCustomer(string name)
    {
        var customers = _customerService.Get(name);

        if (customers == null) NotFound($"No Cudtomers with {name} Name Found");
        return Ok(customers);
    }

    [HttpGet("GetFavourites")]
    public IActionResult GetFavourites(int id)
    {
        var favourites = _customerService.GetFavourites(id);

        if (favourites == null) NotFound("Empty List");
        return Ok(favourites);
    }

    [HttpGet("GetOrders")]
    public IActionResult GetOrders(int id)
    {
        var orders = _customerService.GetOrders(id);

        if (orders == null) NotFound("Empty Orders");
        return Ok(orders);
    }
    
    [HttpGet("GetCart")]
    public IActionResult GetCart(int id)
    {
       
        var carts = _customerService.GetCart(id);

        if (carts == null) NotFound("Empty Carts");
        return Ok(carts);
    }

    [HttpGet("GetReviews")]
    public IActionResult GetReviews(int id)
    {

        var reviews = _customerService.GetReviews(id);

        if (reviews == null) NotFound("Empty Reviews");
        return Ok(reviews);
    }


    [HttpPost("AddCustomers")]
    public IActionResult Add(CustomerAddDto customer)
    {
        _customerService.Add(customer);
       
        return Ok();
    }

   
    [HttpDelete("DeleteCustomers")]
    public IActionResult Delete(int id)
    {
        _customerService.Delete(id);

        return Ok();
    }


    [HttpDelete("UpdateCustomers")]
    public IActionResult Update(int id, Dictionary<CustomerProperties, string> newValues)
    {
        _customerService.Update(id, newValues);

        return Ok();
    }
}
