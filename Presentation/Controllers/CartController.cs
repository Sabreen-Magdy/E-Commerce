using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Domain.Repositories;
namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    internal class CartController: ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
    }
}
