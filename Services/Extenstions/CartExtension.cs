using Contract;
using Contract.OrderItem;
using Domain.Entities;

namespace Services.Extenstions
{
    public static class CartExtension
    {
        public static CartItemDto ToCartItemDto(this CartItem cartItem)
        {
            if (cartItem == null)
                throw new ArgumentNullException(nameof(cartItem));

            var varient = cartItem.ProductVarient;
            return new()
            {
                Id = cartItem.Id,
                State = cartItem.State,
                Quantity = cartItem.Quantity,
                Image = varient.ColoredProduct.Image,
                Color = varient.ColoredProduct.Color.Name,
                Size = varient.Size.Name,
                UnitPrice = varient.Price,
                ProductVarientId = varient.Id
            };
        }
        public static List<CartItemDto> ToCartItemDto(this List<CartItem> cartItems)
        {
            if (cartItems == null)
                throw new ArgumentNullException(nameof(cartItems));

            var cart = new List<CartItemDto>();
            foreach (var item in cartItems)
                cart.Add(item.ToCartItemDto());

            return cart;
        }
        public static CartDto ToCartDto(this List<CartItem> cartItems)
        {
            if (cartItems == null)
                throw new ArgumentNullException(nameof(cartItems));

           var cart = cartItems.ToCartItemDto();


            return new() { 
            items = cart,
            TotalPrice = cart.Sum(ci => ci.Quantity * ci.UnitPrice),
            TotalQuantity = cart.Sum(ci => ci.Quantity)
            };
        }

        //public static CartItem ToCartItemEntity(this ItemNewDto item)
        //{
        //    if (item == null)
        //        throw new ArgumentNullException(nameof(item));

          
        //}
        //public static List<CartItem> ToCartItemEntity(this List<ItemNewDto> cartItems)
        //{
        //    if (cartItems == null)
        //        throw new ArgumentNullException(nameof(cartItems));

        //    var cartItemsEntity = new List<CartItem>();
        //    foreach (var item in cartItems)
        //        cartItemsEntity.Add(item.ToCartItemEntity());

        //    return cartItemsEntity;
        //}
    }
}
