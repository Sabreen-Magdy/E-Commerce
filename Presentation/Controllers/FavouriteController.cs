//using Microsoft.AspNetCore.Mvc;
//using Domain.Repositories;
//using Domain.Entities;
//using Services.Abstraction.DataServices;
//namespace Presentation.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class FavouriteController: ControllerBase
//    {
//        private readonly IAdminService _adminService;

//        public FavouriteController(IAdminService adminService) =>
//            _adminService = adminService;
        
//        [HttpGet("{id}")]
//        public IActionResult GetById(int id)
//        {
//            var fav = _adminService.F.GetById(id);
//            if (fav == null)
//            {
//                return NotFound();
//            }
//            return Ok(fav);
//        }
//        [HttpGet("customer/{customerId}")]
//        public IActionResult GetByCustomerId(int customerId)
//        {
//            var fav = _favouriteRepository.GetByCustomerId(customerId);
//            if (fav == null)
//            {
//                return NotFound();
//            }
//            return Ok(fav);
//        }
//        [HttpPost]
//        public IActionResult CreateFav(Favourite favourite)
//        {
//            _favouriteRepository.Add(favourite);
//            return CreatedAtAction(nameof(GetById), new { id = favourite.Id }, favourite);
//        }

//        [HttpPut]
//        public IActionResult UpdateFav(Favourite favourite)
//        {
//            var oldFav = _favouriteRepository.GetById(favourite.Id);
//            if (oldFav == null)
//            {
//                return NotFound();
//            }

//            _favouriteRepository.Update(favourite);
//            return NoContent();
//        }
//        [HttpDelete("{id}")]
//        public IActionResult DeleteFav(int id)
//        {
//            var existingFav = _favouriteRepository.GetById(id);
//            if (existingFav == null)
//            {
//                return NotFound();
//            }

//            _favouriteRepository.Delete(id);
//            return NoContent();
//        }
//    }
//}
