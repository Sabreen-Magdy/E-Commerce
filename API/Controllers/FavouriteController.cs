using Microsoft.AspNetCore.Mvc;
using Contract;
using Domain.Exceptions;
using Services.Abstraction;
namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public FavouriteController(IAdminService adminService) =>
            _adminService = adminService;

        [HttpGet("GetByProductCustomer")]
        public IActionResult GetByProductCustomer(int customerId, int productId)
        {
            try
            {
                var fav = _adminService.FavouriteService.GetById(customerId, productId);
                if (fav == null)
                {
                    return NotFound();
                }
                return Ok(fav);
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
       

        [HttpGet("GetByCustomerId")]
        public IActionResult GetByCustomerId(int customerId)
        {
            try
            {
                var fav = _adminService.FavouriteService.GetAllByCustomerId(customerId);
                if (fav == null)
                {
                    return NotFound();
                }
                return Ok(fav);
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
        [HttpPost("AddFavorite")]
        public IActionResult AddFavorite(FavoriteNewDto favourite)
        {
            try
            {
                _adminService.FavouriteService.AddFavorite(favourite);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("DeleteFavorite")]
        public IActionResult DeleteFavorite(int customerId, int productId)
        {
            try
            {
                _adminService.FavouriteService.DeleteItem(customerId, productId);
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
