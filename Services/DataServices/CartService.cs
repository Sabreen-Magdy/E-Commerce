using Contract;
using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;
using Services.Abstraction.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using Services.Extenstions;
using Domain.Exceptions;

namespace Services.DataServices
{
    public class CartService:ICartService
    {
        private readonly IAdminRepository _repository;

        public CartService (IAdminRepository repository)
            => _repository = repository;

        public void AddItemToCart(ItemDto item,int cart_id)
        {
            var existProduct=_repository.ProductVarientRepository.Get(item.Id);
            var cartitem= new CartItem
            {
                ProductId = item.Id,
                ColorId = existProduct.ColorId,
                Quantity = item.Quantity,
                SizeId = existProduct.SizeId,
                CartId =cart_id
        };
           _repository.CardRepositry.AddItem(cartitem);

            _repository.SaveChanges();
        }

        public void DeleteItem(int productId,int cartId)
        {
            _repository.CardRepositry.DeletItem(productId, cartId);
            _repository.SaveChanges();
        }

        public CartDto? Get(int id)
        {
            return _repository.CardRepositry.Get(id).ToCartDto();
        }
        public CartDto? GetByCustomerId(int id)
        {
            return _repository.CardRepositry.GetByCustomerId(id).ToCartDto();
        }
        public void Update(int customerId)
        {
            var cart = _repository.CardRepositry.GetByCustomerId(customerId);
            if (cart is null)
                throw new NotFoundException("Cart");
            else
            {
                _repository.CardRepositry.Update(cart);
                _repository.SaveChanges();
            }
        }
        public CartItem Update_Item(CartItem cartItem,
         Dictionary<Properties, int> newValues)
        {
            foreach (var item in newValues)
            {
                switch (item.Key)
                {
                    case Properties.Quantity:
                        cartItem.Quantity = item.Value;
                        break;
                    case Properties.ColorId:
                        cartItem.ColorId = item.Value;
                        break;
                    case Properties.SizeId:
                        cartItem.SizeId = item.Value;
                        break;
                    case Properties.ProductId:
                        cartItem.ProductId = item.Value;
                        break;
                    case Properties.CartId:
                        cartItem.CartId = item.Value;
                        break;
                    default:
                        throw new PropertyException(item.Key.ToString());
                }
            }
            return cartItem;
        }
        public void UpdateItem(int cartId ,int productId, Dictionary<Properties, int> newValues)
        {
            var cartItem = _repository.CardRepositry.GetItem(cartId, productId);
            if (cartItem is null)
                throw new NotFoundException("cartItem");
            else
            {
                _repository.CardRepositry.UpdateItem(Update_Item(cartItem, newValues));
                _repository.SaveChanges();
            }
        }

    
    }
}
