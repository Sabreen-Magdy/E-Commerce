using Contract;
using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;
using Services.Abstraction.DataServices;
using Services.Extenstions;
using Domain.Exceptions;
using Contract.OrderItem;

namespace Services.DataServices
{
    public class CartService:ICartService
    {
        private readonly IAdminRepository _repository;

        public CartService (IAdminRepository repository)
            => _repository = repository;

        public void AddItemToCart(ItemNewDto item)
        {
            var existProduct = _repository.ProductVarientRepository.Get(item.ProductVarientId);
            
            Get(item.CartId); // throw when Cart Not Found

            if (existProduct != null)
            {
                _repository.ProductVarientRepository
                .UpdateQuntity(existProduct, item.Quantity * -1);

                var cartitem = new CartItem
                {
                    ProductId = existProduct.ProductId,
                    ColorId = existProduct.ColorId,
                    Quantity = item.Quantity,
                    SizeId = existProduct.SizeId,
                    CartId = item.CartId
                };
                _repository.CardRepositry.AddItem(cartitem);

                _repository.SaveChanges();
            }
           else throw new NotFoundException("Product Varient");
        }

        public void DeleteItem(int productVarientId, int cartId)
        {
            var existProduct = _repository.ProductVarientRepository.Get(productVarientId);

            if (existProduct != null)
            {
               var item =  _repository.CardRepositry.GetItem(cartId, productVarientId);
                if (item == null)
                    throw new NotFoundException("Cart Item");

                _repository.ProductVarientRepository
                    .UpdateQuntity(existProduct, item.Quantity * -1);

                _repository.CardRepositry.DeletItem(item);
                _repository.SaveChanges();
            }
        }

        public CartDto Get(int id)
        {
            var cart = _repository.CardRepositry.Get(id);
            if (cart == null) throw new NotFoundException("Cart");   
           
            return cart.ToCartDto();
        }
        public CartDto GetByCustomerId(int id)
        {
            var cart = _repository.CardRepositry.GetByCustomerId(id);
            if (cart == null) throw new NotFoundException("Cart");

            return cart.ToCartDto();
        }

        public CartItem Update_Item(CartItem cartItem,
         Dictionary<Properties, int> newValues)
        {
            foreach (var item in newValues)
            {
                switch (item.Key)
                {
                    case Properties.Quantity:
                        {
                            int newQ = cartItem.Quantity - item.Value; 
                            var varient = _repository.ProductVarientRepository.Get(cartItem.ProductVarient.Id);
                            _repository.ProductVarientRepository.UpdateQuntity(
                                varient ?? throw new NotFoundException("Product Varient"),
                                newQ
                                );
                            cartItem.Quantity = item.Value;
                            break;
                        }
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
        public void UpdateItem(int cartId ,int productVarientId, Dictionary<Properties, int> newValues)
        {
            var cartItem = _repository.CardRepositry.GetItem(cartId, productVarientId);
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
