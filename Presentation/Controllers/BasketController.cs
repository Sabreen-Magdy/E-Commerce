using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Domain.Repositories;
using Domain.Entities;
namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }
        [HttpGet("{id}")] // Get: /api/basket/id
        public IActionResult GetBasketById(string id)
        {
            var basket = _basketRepository.GetBasket(id);

            return Ok(basket ?? new BasketCustomer(id));
        }
        [HttpPut] // Put: /api/basket
        public IActionResult EditBasket(BasketCustomer basket)
        {
            if (ModelState.IsValid)
            {
                _basketRepository.UpdateBasket(basket);
                return NoContent();
            }
            return BadRequest();
        }
        [HttpDelete]// Delete: /api/basket/id
        [Route("{id:string}")]
        public IActionResult DeleteBasket(string id)
        {
            var basket = _basketRepository.GetBasket(id);
            if (basket is null)
                return NotFound();
            _basketRepository.DeleteBasket(id);
            return Ok(basket);
        }

    }
}


