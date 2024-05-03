using Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Domain.Exceptions;
using Services.Abstraction;


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
        try{
            var customer = _adminService.CustomerService.GetAll();

            if (customer == null) NotFound("No Cudtomers in System");
            return Ok(customer);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("GetCustomerById")]
    public IActionResult GetCustomer(int id)
    {
        try
        {
            var customer = _adminService.CustomerService.Get(id);

            if (customer == null) NotFound("this Customer Not Found");
            return Ok(customer);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("GetCustomerByName")]
    public IActionResult GetCustomer(string name)
    {
        try
        {
            var customers = _adminService.CustomerService.Get(name);

            if (customers == null) NotFound($"No Cudtomers with {name} Name Found");
            return Ok(customers);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("GetFavourites")]
    public IActionResult GetFavourites(int id)
    {
        try { var favourites = _adminService.CustomerService.GetFavourites(id);

            if (favourites == null) NotFound("Empty List");
            return Ok(favourites);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("GetOrders")]
    public IActionResult GetOrders(int id)
    {
        try
        {
            var orders = _adminService.CustomerService.GetOrders(id);

            if (orders == null) NotFound("Empty Orders");
            return Ok(orders);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("GetCart")]
    public IActionResult GetCart(int id)
    {

        try { var carts = _adminService.CustomerService.GetCart(id);

            if (carts == null) NotFound("Empty Carts");
            return Ok(carts);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("GetReviews")]
    public IActionResult GetReviews(int id)
    {
        try {
            var reviews = _adminService.CustomerService.GetReviews(id);

            if (reviews == null) NotFound("Empty Reviews");
            return Ok(reviews);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("CanAddReview")]
    public IActionResult CanAddReview(int id, int productId)
    {
        try
        {
            return Ok(_adminService.CustomerService.CanAddReview(id, productId));
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }


    [HttpPost("AddReview")]
    public IActionResult AddReview(int customerId, int productId, string comment, int rate )
    {
        try
        {
            _adminService.CustomerService.AddReview(customerId, productId, comment, rate);
            return Ok();

        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (NotAllowedException ex)
        {
            return StatusCode(405, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    //[HttpDelete("DeleteCustomers")]
    //public IActionResult Delete(int id)
    //{
    //    try { _adminService.CustomerService.Delete(id);

    //        return Ok();
    //    }
    //    catch (NotFoundException ex)
    //    {
    //        return NotFound(ex.Message);
    //    }
    //    catch (Exception ex)
    //    {
    //        return StatusCode(500, ex.Message);
    //    }
    //}


    [HttpPut("UpdateCustomers")]
    public IActionResult Update(int id, CustomerAddDto customer)
    {
        try
        {
            _adminService.CustomerService.Update(id, customer);

            return Ok();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
