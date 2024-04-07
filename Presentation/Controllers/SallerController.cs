﻿using Contract;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Domain.Exceptions;
using Services.Abstraction;
using Services.Abstraction.External;
using Services;


namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Saller")]
public class SallerController : ControllerBase
{
    private readonly IAdminService _adminService;
    private readonly IExrernalService _externalService;


    public SallerController(IAdminService adminService, IExrernalService externalService)
    {
        _adminService = adminService;
        _externalService = externalService;
    }

    [HttpGet("GetNumberProducts")]
    public IActionResult GetNumberProducts()
    {
        try
        {
            var result = _adminService.ProductService.GetNumberProducts();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("GetNumberCustomers")]
    public IActionResult GetNumberCustomers()
    {
        try
        {
            var result = _adminService.CustomerService.GetNumberCustomers();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("GetNumberOrders")]
    public IActionResult GetNumberOrders(int state)
    {
        try
        {
            var result = _adminService.OrderService.GetNumberOrders((OrderStates)state);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("GetProfit")]
    public IActionResult GetProfit(int state)
    {
        try
        {
            var result = _adminService.OrderService.GetProfit((OrderStates)state);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("GetProfitByYear")]
    public IActionResult GetProfitByYear(int state)
    {
        try
        {
            var result = _adminService.OrderService.GetProfitByYear((OrderStates)state);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [HttpGet("GetProfitByWeek")]
    public IActionResult GetProfitByWeek(int state)
    {
        try
        {
            var result = _adminService.OrderService.GetProfitByWeek((OrderStates)state);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("GetProfitByWeekDay")]
    public IActionResult GetProfitByWeekDay(int state)
    {
        try
        {
            var result = _adminService.OrderService.GetProfitByWeekDay((OrderStates)state);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    #region Delete

    [HttpDelete("DeleteProduct")]
    public IActionResult Delete(int id)
    {
        try
        {
            _adminService.ProductService.Delete(id);
            return Ok();
        }catch(NotAllowedException ex)
        {
            return BadRequest(ex.Message);
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

    [HttpDelete("DeleteVarient")]
    public IActionResult DeleteVarient(int id)
    {
        try
        {
            _adminService.ProductService.DeleteVarient(id);
            return Ok();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("DeleteColor")]
    public IActionResult DeleteColor(int id)
    {
        try
        {
            _adminService.ProductService.DeleteColor(id);
            return Ok();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("DeleteColorByProductColor")]
    public IActionResult DeleteColor(int productId, int colorId)
    {
        try
        {
            _adminService.ProductService.DeleteColor(productId, colorId);
            return Ok();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("DeleteCategory")]
    public IActionResult DeleteCategory(int id)
    {
        try
        {
            _adminService.ProductService.DeleteCategory(id);
            return Ok();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("DeleteCategoryByProductColor")]
    public IActionResult DeleteCategory(int productId, int categoryId)
    {
        try
        {
            _adminService.ProductService.DeleteCategory(productId, categoryId);
            return Ok();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    #endregion

    #region Add

    [HttpPost("Add")]
    public IActionResult Add(ProductNewDto product)
    {
        try
        {
            _adminService.ProductService.Add(product);

            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("AddVarient")]
    public IActionResult Add(ProductVariantNewDto productVarient)
    {
        try
        {
            _adminService.ProductService.AddVarient(productVarient);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("AddColor")]
    public IActionResult Add(ProductColoredNewDto productColred)
    {
        try
        {
            _adminService.ProductService.AddColor(productColred);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("AddCategory")]
    public IActionResult AssignCategory(int productId, int categoryId)
    {
        try
        {
            _adminService.ProductService.AssignCategory(productId, categoryId);
            return Ok();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    #endregion

    #region Update

    [HttpPut("Update")]
    public IActionResult Update(int id, Dictionary<Properties, string> productData)
    {
        try
        {
            _adminService.ProductService.Update(id, productData);
            return Ok();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("UpdateVarient")]
    public IActionResult UpdateVarient(int id, Dictionary<Properties, string> varientData)
    {
        try
        {
            _adminService.ProductService.UpdateVarient(id, varientData);
            return Ok();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    #endregion


    [HttpGet("GetAllCustomers")]
    public IActionResult GetAll()
    {
        var customer = _adminService.CustomerService.GetAll();

        if (customer == null) NotFound("No Sallers in System");
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

    [HttpGet("GetOrders")]
    public IActionResult GetOrders(int id)
    {
        var orders = _adminService.CustomerService.GetOrders(id);

        if (orders == null) NotFound("Empty Orders");
        return Ok(orders);
    }

    [HttpDelete("DeleteCustomers")]
    public IActionResult DeleteCustomer(int id)
    {
        _adminService.CustomerService.Delete(id);

        return Ok();
    }


    [HttpDelete("UpdateCustomers")]
    public IActionResult UpdateCustomer(int id, CustomerAddDto customer)
    {
        _adminService.CustomerService.Update(id, customer);

        return Ok();
    }

    #region Orders

    [HttpGet("GetAllOrders")]
    public IActionResult GetAllOreders()
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

    [HttpDelete("DeleteOrder")]
    public IActionResult DeleteOrder(int id)
    {
        _adminService.OrderService.Delete(id);

        return Ok();
    }


    [HttpPut("UpdateOrderStatus")]
    public IActionResult UpdateOrderStatus(int id, int status, string comment)
    {
        OrderStates oldState = OrderStates.Pending;
        try
        {
             oldState = _adminService.OrderService.GetOrderStates(id);
            _adminService.OrderService.UpdateState(id, (OrderStates)status, comment);

            if (status == (int)OrderStates.Rejected)
            {
                var payment = _adminService.OrderService.GetPayment(id);
                string refundedTransactionId = _externalService.PaymentService
                     .RefundTransaction(payment.PayedTransactionId);

                payment.RefundTransactionId = refundedTransactionId;
                _adminService.OrderService.UpdatePayment(payment);
            }
            return Ok(status);
        }
        catch(PaymentFailedException ex)
        {
            _adminService.OrderService.UpdateState(id, oldState, comment);
            return BadRequest(ex.Message);
        }
        catch (NotAllowedException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch(Exception ex)
        {
            return StatusCode(505, ex.Message);
        }
    }

    #endregion
}
