using Contract;
using Contract.Favorite;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Repositories;
using Services.Abstraction.DataServices;
using Services.Extenstions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataServices
{
    public class FavouriteService : IFavouriteService
    {
        private readonly IAdminRepository _repository;

        public FavouriteService(IAdminRepository repository)
            => _repository = repository;

        public void AddFavorite(FavoriteDto FavDto)
        {
            _repository.FavouriteRepository.Add(FavDto.ToFavoriteEntity());
            _repository.SaveChanges();
        }

        public void DeleteItem(int customerId, int productId)
        {
            var fav = _repository.FavouriteRepository.GetByCustomerProduct(customerId,productId);
            if (fav is null)
                throw new NotFoundException("Favorite");
            else
            {
                _repository.FavouriteRepository.Delete(fav);
                _repository.SaveChanges();
            }
        }

        public List<FavoriteDto> GetAll()
        {
         return   _repository.FavouriteRepository.GetAll().ToFavoriteDto();
        }
        public Favourite UpdateFav(Favourite favourite,
         Dictionary<Properties, int> newValues)
        {
            foreach (var item in newValues)
            {
                switch (item.Key)
                {
                    case Properties.CustomerId:
                        favourite.CustomerId = item.Value;
                        break;
                    case Properties.ProductId:
                        favourite.ProductId = item.Value;
                        break;
                    default:
                        throw new PropertyException(item.Key.ToString());
                }
            }
            return favourite;
        }
        public void Update(int customerId, int productId, Dictionary<Properties, int> newValues)
        {
            var fav = _repository.FavouriteRepository.GetByCustomerProduct(customerId,productId);
            if (fav is null)
                throw new NotFoundException("Favorite");
            else
            {
                _repository.FavouriteRepository.Update(UpdateFav(fav, newValues));
                _repository.SaveChanges();
            }
        }

        public List<FavoriteDto> GetAllByCustomerId(int customerId)
        {
            return _repository.FavouriteRepository.GetByCustomer(customerId).ToFavoriteDto();
        }

        public  FavoriteDto GetById(int customerId, int productId)
        {
            return _repository.FavouriteRepository.GetByCustomerProduct(customerId,productId).ToFavoriteDto();
        }
    }
}
