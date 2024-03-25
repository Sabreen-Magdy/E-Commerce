using Microsoft.AspNetCore.Mvc;
using Services.Abstraction.DataServices;
using Contract.Favorite;
namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public FavouriteController(IAdminService adminService) =>
            _adminService = adminService;

        //[HttpGet("{Id}")]
        [HttpGet("GetByProductCustomer")]
        public IActionResult GetByProductCustomer(int customerId, int productId)
        {
            var fav = _adminService.FavouriteService.GetById(customerId, productId);
            if (fav == null)
            {
                return NotFound();
            }
            return Ok(fav);
        }
        //[HttpGet("customer/{customerId}")]
        [HttpGet("GetByCustomerId")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var fav = _adminService.FavouriteService.GetAllByCustomerId(customerId);
            if (fav == null)
            {
                return NotFound();
            }
            return Ok(fav);
        }
        [HttpPost("AddFavorite")]
        public IActionResult AddFavorite(FavoriteDto favourite)
        {
            _adminService.FavouriteService.AddFavorite(favourite);
            return Ok();
        }
        //[HttpDelete("{id}")]
        [HttpDelete("DeleteFavorite")]
        public IActionResult DeleteFavorite(int customerId, int productId)
        {
            _adminService.FavouriteService.DeleteItem(customerId, productId);
            return Ok();
        }
    }
}
