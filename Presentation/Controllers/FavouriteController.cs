using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Domain.Repositories.Favourite;
namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteController: ControllerBase
    {
        private readonly IFavouriteRepository _favouriteRepository;

        public FavouriteController(IFavouriteRepository favouriteRepository)
        {
            _favouriteRepository = favouriteRepository;
        }
    }
}
