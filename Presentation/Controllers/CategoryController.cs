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
  //  [Authorize]
    public class CategoryController :  ControllerBase
    {
        private readonly IAdminService _adminService;
        public CategoryController(IAdminService adminService) =>
            _adminService = adminService;


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _adminService.CategoryService.GetAll();
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
}

        [HttpGet("GetById")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _adminService.CategoryService.Get(id);
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
                var result = _adminService.CategoryService.Get(name);
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost("Add")]
        public IActionResult Add(CategoryNewDto category)
        {
            try
            {
                _adminService.CategoryService.Add(category);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(CategoryDto categoryDto)
        {
           
            try
            {
                _adminService.CategoryService.Update(categoryDto);
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

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                _adminService.CategoryService.Delete(id);
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
    }
}
