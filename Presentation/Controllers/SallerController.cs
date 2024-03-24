﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Domain.Repositories;
using Domain.Entities;
using Persistence.Repositories;
namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SallereController : ControllerBase
    {
        private readonly ISallerRepositry _SallerRepository;

        public SallereController(ISallerRepositry SallerRepository)
        {
            _SallerRepository = SallerRepository;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var fav = _SallerRepository.GetById(id);
            if (fav == null)
            {
                return NotFound();
            }
            return Ok(fav);
        }
        [HttpGet("customer/{customerId}")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var fav = _SallerRepository.GetByCustomerId(customerId);
            if (fav == null)
            {
                return NotFound();
            }
            return Ok(fav);
        }
        [HttpPost]
        public IActionResult CreateSall(Saller saller)
        {
            _SallerRepository.Add(saller);
            return CreatedAtAction(nameof(GetById), new { id = saller.Id }, saller);
        }

        [HttpPut]
        public IActionResult UpdateSaller(Saller saller)
        {
            var oldsall = _SallerRepository.GetById(saller.Id);
            if (oldsall == null)
            {
                return NotFound();
            }

            _SallerRepository.Update(saller);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Deletesall(int id)
        {
            var existingSall = _SallerRepository.GetById(id);
            if (existingSall == null)
            {
                return NotFound();
            }

            _SallerRepository.Delete(id);
            return NoContent();
        }
    }
}
