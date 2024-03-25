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
    [Authorize]
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
                var result = _adminService.ProductService.GetByColor(name);
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetByColorCode")]
        public IActionResult GetByColor(System.Drawing.Color code)
        {
            try
            {
                var result = _adminService.ProductService.GetByColor(code);
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

        #region Delete

        [HttpDelete("DeleteProduct")]
        public IActionResult Delete(int id)
        {
            try
            {
                _adminService.ProductService.Delete(id);
                return Ok();
            }
            catch(NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteVarient")]
        public IActionResult DeleteVarient(int id)
        {
            try
            {
                _adminService.ProductService.DeleteVarient(id);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("DeleteColor")]
        public IActionResult DeleteColor(int id)
        {
            try
            {
                _adminService.ProductService.DeleteColor(id);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
        [HttpDelete("DeleteColorByProductColor")]
        public IActionResult DeleteColor(int productId, int colorId)
        {
            try
            {
                _adminService.ProductService.DeleteColor(productId, colorId);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteCategory")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                _adminService.ProductService.DeleteCategory(id);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteCategoryByProductColor")]
        public IActionResult DeleteCategory(int productId, int categoryId)
        {
            try
            {
                _adminService.ProductService.DeleteColor(productId, categoryId);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        #endregion

        #region Add

        [HttpPost("Add")]
        public IActionResult Add(ProductNewDto product)
        {
            try
            {
                _adminService.ProductService.Add(product);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("AddVarient")]
        public IActionResult Add(ProductVariantNewDto productVarient)
        {
            try
            {
                _adminService.ProductService.AddVarient(productVarient);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
       
        [HttpPost("AddColor")]
        public IActionResult Add(ProductColoredNewDto productColred)
        {
            try
            {
                _adminService.ProductService.AddColor(productColred);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("AddCategory")]
        public IActionResult AssignCategory(int productId, int categoryId)
        {
            try
            {
                _adminService.ProductService.AssignCategory(productId, categoryId);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        #endregion

        #region Update

        [HttpPut("Update")]
        public IActionResult Update(int id, Dictionary<Properties, string> productData)
        {
            try
            {
                _adminService.ProductService.Update(id, productData);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateVarient")]
        public IActionResult UpdateVarient(int id, Dictionary<Properties, string> varientData)
        {
            try
            {
                _adminService.ProductService.UpdateVarient(id, varientData);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        #endregion

        
    }
}
