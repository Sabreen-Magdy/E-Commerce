using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Domain.Repositories;
using Domain.Entities;
using Persistence.Repositories;
namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteController: ControllerBase
    {
        private readonly IFavouriteRepository _favouriteRepository;

        public FavouriteController(IFavouriteRepository favouriteRepository)
        {
            _favouriteRepository = favouriteRepository;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var fav = _favouriteRepository.GetById(id);
            if (fav == null)
            {
                return NotFound();
            }
            return Ok(fav);
        }
        [HttpGet("customer/{customerId}")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var fav = _favouriteRepository.GetByCustomerId(customerId);
            if (fav == null)
            {
                return NotFound();
            }
            return Ok(fav);
        }
        [HttpPost]
        public IActionResult CreateFav(Favourite favourite)
        {
            _favouriteRepository.Add(favourite);
            return CreatedAtAction(nameof(GetById), new { id = favourite.Id }, favourite);
        }

        [HttpPut]
        public IActionResult UpdateFav(Favourite favourite)
        {
            var oldFav = _favouriteRepository.GetById(favourite.Id);
            if (oldFav == null)
            {
                return NotFound();
            }

            _favouriteRepository.Update(favourite);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteFav(int id)
        {
            var existingFav = _favouriteRepository.GetById(id);
            if (existingFav == null)
            {
                return NotFound();
            }

            _favouriteRepository.Delete(id);
            return NoContent();
        }
    }
}
