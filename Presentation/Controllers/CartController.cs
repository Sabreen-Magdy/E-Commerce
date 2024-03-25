using Microsoft.AspNetCore.Mvc;

using Domain.Entities;
using Services.Abstraction.DataServices;
using Contract;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public CartController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cart = _adminService.CartService.Get(id);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }
        [HttpGet("customer/{customerId}")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var cart = _adminService.CartService.GetByCustomerId(customerId);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }
        [HttpPost]
        public IActionResult AddItemToCart(ItemDto itemDto, int cartId)
        {
            _adminService.CartService.AddItemToCart(itemDto, cartId);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateCart(Cart cart)
        {
            _adminService.CartService.Update(cart.CustomerId);
            return NoContent();
        }

        [HttpPut("item/{id}")]
        public IActionResult UpdateCartItem(int id, Dictionary<Properties, int> newValues)
        {
            _adminService.CartService.UpdateItem(id,newValues);
            return NoContent();
        }

        [HttpDelete("item/{id}")]
        public IActionResult DeleteCartItem(int id)
        {
            _adminService.CartService.DeleteItem(id);
            return NoContent();
        }

    }
}
