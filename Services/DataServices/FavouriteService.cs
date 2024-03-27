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

        public void AddFavorite(FavoriteNewDto FavDto)
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
            var favs = _repository.FavouriteRepository.GetByCustomer(customerId);
            var dtos = favs.ToFavoriteDto();
            FillImage(dtos);
            return dtos; 
        }

        public  FavoriteDto GetById(int customerId, int productId)
        {
            var fav =  _repository.FavouriteRepository.GetByCustomerProduct(customerId, productId);
            if (fav == null)
                throw new NotFoundException("Fav");
            var dto = fav.ToFavoriteDto();
            FillImage(dto); 
            return dto;
        }

        private void FillImage(FavoriteDto favorite) =>
            favorite.Image = _repository.ProductColerdRepository
            .GetByProduct(favorite.ProductId).FirstOrDefault()?.Image;

        private void FillImage(List<FavoriteDto> favorites) {
            foreach (var item in favorites) FillImage(item);
        }        
    }
}
