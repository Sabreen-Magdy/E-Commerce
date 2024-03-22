using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Domain.Repositories;
using Domain.Entities;
namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController: ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cart = _cartRepository.GetById(id);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }
        [HttpGet("customer/{customerId}")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var cart = _cartRepository.GetByCustomerId(customerId);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }
        [HttpPost]
        public IActionResult CreateCart(Cart cart)
        {
            _cartRepository.Add(cart);
            return CreatedAtAction(nameof(GetById), new { id = cart.Id }, cart);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCart(Cart cart)
        {
            var oldCart = _cartRepository.GetById(cart.Id);
            if (oldCart == null)
            {
                return NotFound();
            }

            _cartRepository.Update(cart);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCart(int id)
        {
            var existingCart = _cartRepository.GetById(id);
            if (existingCart == null)
            {
                return NotFound();
            }

            _cartRepository.Delete(id);
            return NoContent();
        }

    }
}
