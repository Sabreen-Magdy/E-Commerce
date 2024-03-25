using Contract;
using Domain.Enums;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction.DataServices;


namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductController : ControllerBase
    {
        private const int count = 20;
        private readonly IAdminService _adminService;

        public ProductController(IAdminService adminService) =>
            _adminService = adminService;

        private Range GetRange(int pageNumber)
        {
            int start = pageNumber * count;
            return new(start, start + count);
        }

        #region Get
        
        [HttpGet("GetAll")]
        public IActionResult GetAll(int pageNumber) {
            try
            {
                var result = _adminService.ProductService.GetAll();
                if(result == null) return NotFound();

                return Ok(result.Take(GetRange(pageNumber)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        #region Filtering

        [HttpGet("GetDetailsById")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _adminService.ProductService.GetVarients(id);
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetByName")]
        public IActionResult Get(string name)
        {
            try
            {
                var result = _adminService.ProductService.Get(name);
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetByColorName")]
        public IActionResult GetByColor(string name)
        {
            try
            {
                var result = _adminService.ProductService.GetByColorName(name);
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetByColorCode")]
        public IActionResult GetByColorCode(string code)
        {
            try
            {
                var result = _adminService.ProductService.GetByColorCode(code);
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetByGetegory")]
        public IActionResult GetByGetegory(string gategory)
        {
            try
            {
                var result = _adminService.ProductService.GetByGetegory(gategory);
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetByPrice")]
        public IActionResult GetByPrice(double price)
        {
            try
            {
                var result = _adminService.ProductService.GetByPrice(price);
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetByQuantity")]
        public IActionResult GetByQuantity(int quantity)
        {
            try
            {
                var result = _adminService.ProductService.GetByQuantity(quantity);
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetByRate")]
        public IActionResult GetByRate(int rate)
        {
            try
            {
                var result = _adminService.ProductService.GetByRate(rate);
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        #endregion

        [HttpGet("GetProductImages")]
        public IActionResult GetImages(int id)
        {
            try
            {
                var result = _adminService.ProductService.GetColoresImages(id);
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetProductReviews")]
        public IActionResult GetReviews(int id)
        {
            try
            {
                var result = _adminService.ProductService.GetReviews(id);
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        #endregion   
    }
}
