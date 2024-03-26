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
    //[Authorize]
    public class CartController : ControllerBase
    {
        private readonly IAdminService _adminService;

        //        public CartController(IAdminService adminService)
        //        {
        //            _adminService = adminService;
        //        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var cart = _adminService.CartService.Get(id);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        [HttpGet("{customerId}")]
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
        public IActionResult AddItemToCart(int cartId, ItemDto itemDto)
        {
            _adminService.CartService.AddItemToCart(itemDto, cartId);
            return NoContent();
        }

        //[HttpPut("Update")]
        //public IActionResult UpdateCart(Cart cart)
        //{
        //    _adminService.CartService.Update(cart.CustomerId);
        //    return NoContent();
        //}

        [HttpPut("UpdateItem")]
        public IActionResult UpdateCartItem(int cartId, int productId, Dictionary<Properties, int> newValues)
        {
            _adminService.CartService.UpdateItem(cartId, productId, newValues);
            return NoContent();
        }

        [HttpDelete("DeleteItem")]
        public IActionResult DeleteCartItem(int cartId, int productId)
        {
            _adminService.CartService.DeleteItem(productId, cartId);
            return NoContent();
        }

    }
}
