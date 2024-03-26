using Contract;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction.DataServices;
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
                return StatusCode(500, ex.Message);
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
                return StatusCode(500, ex.Message);
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
                return StatusCode(500, ex.Message);
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
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("AddColor")]
        //[Authorize(Roles = "Saller")]
        public IActionResult Add(string name, string code)
        {
            try
            {
                _adminService.GeneralService.AddColor(name, code);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("AddSize")]
        //[Authorize(Roles = "Saller")]
        public IActionResult Add(string name)
        {
            try
            {
                _adminService.GeneralService.AddSize(name);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
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
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteSize")]
        //[Authorize(Roles = "Saller")]
        public IActionResult DeleteSize(int id)
        {
            try
            {
                _adminService.GeneralService.RemoveSize(id);
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


        [HttpPut("UpdateSize")]
        //[Authorize(Roles = "Saller")]
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
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateColor")]
        //[Authorize(Roles = "Saller")]
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
                return StatusCode(500, ex.Message);
            }
        }
    }
}
