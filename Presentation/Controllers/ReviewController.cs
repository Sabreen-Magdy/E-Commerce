using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Domain.Repositories;
using Domain.Entities;
using Persistence.Repositories;
namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController: ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        [HttpPost]
        public IActionResult AddReview(Review review)
        {
            _reviewRepository.Add(review);
            return CreatedAtAction(nameof(GetByCustomerId), new { id = review.ProductId }, review);
        }
        [HttpGet("customer/{customerId}")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var reviews = _reviewRepository.GetAllReviewByCustomerId(customerId);
            if (reviews == null)
            {
                return NotFound();
            }
            return Ok(reviews);
        }
        [HttpGet("product/{productId}")]
        public IActionResult GetByProductId(int productId)
        {
            var reviews = _reviewRepository.GetAllReviewByProductId(productId);
            if (reviews == null)
            {
                return NotFound();
            }
            return Ok(reviews);
        }
        [HttpPut]
        public IActionResult UpdateReview(Review review)
        {
            _reviewRepository.Update(review);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteReview(Review review)
        {
            _reviewRepository.Delete(review);
            return NoContent();
        }
    }
}
