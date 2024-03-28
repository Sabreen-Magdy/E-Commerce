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
    public class CartService : ICartService
    {
        private readonly IAdminRepository _repository;

        public CartService (IAdminRepository repository)
            => _repository = repository;

        private void FillProductImages(int productId, CartItemDto item)
        {
            var product = _repository.ProductRepository.Get(productId);
            if (product == null)
                throw new NotFoundException("Product");
            item.Name = product.Name;
        }

        private CartItem ToCartItemEntity(int customerId, int varientId, ItemNewDto item)
        {
            var varient = _repository.ProductVarientRepository.Get(varientId);
            if (varient == null)
                throw new NotFoundException("Product Varient");
       
            return new()
            {
                CustomerId = customerId,
                State = item.State,
                Quantity = item.Quantity,
                ProductId = varient.ProductId,
                 ColorId  = varient.ColorId,
                SizeId   = varient.SizeId
            };
        }
   
        public void DeleteItem(int customerId, int productVarientId)
        {
            var existProduct = _repository.ProductVarientRepository.Get(productVarientId);

            if (existProduct != null)
            {
               var item =  _repository.CardRepositry.GetItem(customerId, productVarientId);
                if (item == null)
                    throw new NotFoundException("Cart Item");

                _repository.ProductVarientRepository
                    .UpdateQuntity(existProduct, item.Quantity * -1);

                _repository.CardRepositry.Delete(item);
                _repository.SaveChanges();
            }
            else throw new NotFoundException("Product Varient");
        }

        public CartItemDto Get(int id)
        {
            var cart = _repository.CardRepositry.Get(id);
            if (cart == null) throw new NotFoundException("Cart Item");

            var cartItemDto = cart.ToCartItemDto();
            FillProductImages(cart.ProductId, cartItemDto);
            return cartItemDto;
        }
        public CartItemDto Get(int customerId, int productVarientId)
        {
            var cartItem = _repository.CardRepositry.GetItem(customerId, productVarientId);
            if(cartItem == null) 
                throw new NotFoundException("Cart Item");
            
            var cartItemDto = cartItem.ToCartItemDto();
            FillProductImages(cartItem.ProductId, cartItemDto);
            return cartItemDto;
        }

        public CartDto GetByCustomerId(int id)
        {
            var cart = _repository.CardRepositry.GetByCustomerId(id);
            if (cart == null) throw new NotFoundException("Cart");

            var cartDto = cart.ToCartDto();
            for (int i=0; i < cart.Count; i++)
            {
                FillProductImages(cart[i].ProductId, cartDto.items[i]);
            }
            return cartDto;
        }

        private void Update(CartItem cartItem,
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
                    case Properties.State:
                        cartItem.State = item.Value;
                        break;
                    case Properties.SizeId:
                        cartItem.SizeId = item.Value;
                        break;
                    case Properties.ProductId:
                        cartItem.ProductId = item.Value;
                        break;
                    case Properties.CustomerId:
                        cartItem.CustomerId = item.Value;
                        break;
                    default:
                        throw new PropertyException(item.Key.ToString());
                }
            }
        }
     
        public void AddCart(int customerId, List<ItemNewDto> items)
        {
            if (_repository.CustomerRepository.Get(customerId) == null)
                throw new NotFoundException("Customer");

            var itemsEntity = new List<CartItem>();
            foreach (var item in items)
                ToCartItemEntity(customerId, item.ProductVarientId, item);

            _repository.CardRepositry.AddRange(itemsEntity);
            _repository.SaveChanges();
        }

        public void AddItem(int customerId, ItemNewDto item)
        {
          if(_repository.CustomerRepository.Get(customerId) == null)
                throw new NotFoundException("Customer");

            _repository.CardRepositry.Add(ToCartItemEntity(customerId, item.ProductVarientId, item));
            _repository.SaveChanges();
        }
    
        public void Update(int customerId, int productVarientId,
            Dictionary<Properties, int> newValues)
        {
            var cartItem = _repository.CardRepositry.GetItem(customerId, productVarientId);
            if (cartItem is null)
                throw new NotFoundException("cartItem");
            else
            {
                Update(cartItem, newValues);
                _repository.SaveChanges();
            }
        }

        public void DeleteItem(int id)
        {
           var item = _repository.CardRepositry.Get(id);
            if (item is null)
                throw new NotFoundException("Cart Item");

            _repository.CardRepositry.Delete(item);
            _repository.SaveChanges();
        }
    }
}
