using Contract;
using Contract.Favorite;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction.DataServices
{
    public interface IFavouriteService
    {
        List<FavoriteDto> GetAll();
        List<FavoriteDto> GetAllByCustomerId(int customerId);
        FavoriteDto GetById(int customerId, int productId);
        void AddFavorite(FavoriteNewDto FavDto);
        Favourite UpdateFav(Favourite favourite, Dictionary<Properties, int> newValues);
        void Update(int customerId, int productId, Dictionary<Properties, int> newValues);
        void DeleteItem(int customerId, int productId);

    }
}
