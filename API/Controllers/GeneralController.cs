using Contract;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using System.Drawing;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class GeneralController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public GeneralController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("GetAllColor")]
        public IActionResult GetAllColor()
        {
            try
            {
                var result = _adminService.GeneralService.GetAllColor();
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException);
            }
        }
       
        [HttpGet("GetAllSize")]
        public IActionResult GetAllSize()
        {
            try
            {
                var result = _adminService.GeneralService.GetAllSize();
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException);
            }
        }


        [HttpGet("GetColor")]
        public IActionResult GetColor(int id)
        {
            try
            {
                var result = _adminService.GeneralService.GetColor(id);
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException);
            }
        }

        [HttpGet("GetSize")]
        public IActionResult GetSize(int id)
        {
            try
            {
                var result = _adminService.GeneralService.GetSize(id);
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException);
            }
        }

        [HttpPost("AddColor")]
       // // [Authorize(Roles = "Saller")]
        public IActionResult Add(string name, string code)
        {
            try
            {
                _adminService.GeneralService.AddColor(name, code);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException);
            }
        }

        [HttpPost("AddSize")]
     //   [Authorize(Roles = "Saller")]
        public IActionResult Add(string name)
        {
            try
            {
                _adminService.GeneralService.AddSize(name);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException);
            }
        }

        [HttpDelete("DeleteColor")]
        // [Authorize(Roles = "Saller")]
        public IActionResult DeleteColor(int id)
        {
            try
            {
                _adminService.GeneralService.RemoveColor(id);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (NotAllowedException ex)
            {
                return StatusCode(405, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException);
            }
        }

        [HttpDelete("DeleteSize")]
        // [Authorize(Roles = "Saller")]
        public IActionResult DeleteSize(int id)
        {
            try
            {
                _adminService.GeneralService.RemoveSize(id);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (NotAllowedException ex)
            {
                return StatusCode(405, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException);
            }
        }


        [HttpPut("UpdateSize")]
        // [Authorize(Roles = "Saller")]
        public IActionResult UpdateSize(SizeDto size)
        {
            try
            {
                _adminService.GeneralService.UpdateSize(size);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException);
            }
        }

        [HttpPut("UpdateColor")]
        // [Authorize(Roles = "Saller")]
        public IActionResult UpdateColor(ColorDto color)
        {
            try
            {
                _adminService.GeneralService.UpdaterColor(color);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException);
            }
        }
    }
}
