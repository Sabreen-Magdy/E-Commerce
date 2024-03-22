using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Domain.Repositories;
namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    internal class CartController: ControllerBase
    {
        private readonly ISallerRepositry _cartRepository;

        public CartController(ISallerRepositry cartRepository)
        {
            _cartRepository = cartRepository;
        }
    }
}
