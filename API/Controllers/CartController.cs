using Microsoft.AspNetCore.Mvc;

using Domain.Entities;
using Contract;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Domain.Exceptions;
using Contract.OrderItem;
using Services.Abstraction;
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

        [HttpGet("CartItem")]
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
            try
            {
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


        [HttpPost("AddItem")]
        public IActionResult AddItem(int customerId, ItemNewDto itemDto)
        {
            try
            {
                _adminService.CartService.AddItem(customerId, itemDto);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (NotAllowedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("AddItems")]
        public IActionResult AddItem(int customerId, List<ItemNewDto> itemDto)
        {
            try
            {
                _adminService.CartService.AddCart(customerId, itemDto);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (NotAllowedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut("UpdateItem")]
        public IActionResult UpdateCartItem(int costomerId, int productId, Dictionary<Properties, int> newValues)
        {
            try
            {
                _adminService.CartService.Update(costomerId, productId, newValues); return Ok();
            }
            catch (NotAllowedException ex)
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

        [HttpDelete("DeleteItem")]
        public IActionResult DeleteCartItem(int costomerId, int productVarientId)
        {
            try
            {
                _adminService.CartService.DeleteItem(costomerId, productVarientId);
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

        [HttpDelete("DeleteItemById")]
        public IActionResult DeleteCartItem(int id)
        {
            try
            {
                _adminService.CartService.DeleteItem(id);
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
