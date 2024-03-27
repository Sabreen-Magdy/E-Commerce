using Microsoft.AspNetCore.Mvc;

using Domain.Entities;
using Services.Abstraction.DataServices;
using Contract;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Domain.Exceptions;
using Contract.OrderItem;
namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CartController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public CartController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                var cart = _adminService.CartService.Get(id);

                return Ok(cart);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetByCustomerId")]
        public IActionResult GetByCustomerId(int customerId)
        {
            try { 
            var cart = _adminService.CartService.GetByCustomerId(customerId);

            return Ok(cart);
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


        [HttpPost]
        public IActionResult AddItemToCart(ItemNewDto itemDto)
        {
            try
            {
                _adminService.CartService.AddItemToCart(itemDto);
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

        [HttpPut("UpdateItem")]
        public IActionResult UpdateCartItem(int cartId, int productId, Dictionary<Properties, int> newValues)
        {
            try
            {
                _adminService.CartService.UpdateItem(cartId, productId, newValues); return Ok();
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

        [HttpDelete("DeleteItem")]
        public IActionResult DeleteCartItem(int cartId, int productId)
        {
            try
            {
                _adminService.CartService.DeleteItem(productId, cartId);
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
}
