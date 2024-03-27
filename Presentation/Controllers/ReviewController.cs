﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Domain.Repositories;
using Domain.Entities;
using Persistence.Repositories;
using Services.Abstraction.DataServices;
using Contract;
using Domain.Enums;
using Services.Extenstions;
namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public ReviewController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpPost]
        public IActionResult AddReview(CustomerReviewDto review)
        {
            _adminService.ReviewService.Add(review);
            return Ok();
        }
      
        //}
        [HttpGet("product")]
        public IActionResult GetByProductId(int productId)
        {
            var reviews = _adminService.ReviewService.GetAllReviewsOfProduct(productId);
            if (reviews == null)
            {
                return NotFound();
            }
            return Ok(reviews);
        }
        //[HttpPut]
        //public IActionResult UpdateReview(int customerId, int productId, Dictionary<Properties, object> newValues)
        //{
        //    _adminService.ReviewService.Update_Review(customerId, productId, newValues);
        //    return NoContent();
        //}
        //[HttpDelete]
        //public IActionResult DeleteReview(Review review)
        //{
        //    _adminService.ReviewService.Delete_Review(review.CustomerId, review.ProductId);
        //    return NoContent();
        //}
    }
}
