using Contract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Extenstions
{
    public static class CartExtension
    {
        public static CartDto ToCartDto(this Cart cart)
        {
            if (cart == null)
                throw new ArgumentNullException(nameof(cart));

            var itemDtos = cart.CartItems.Select(ci => new ItemDto
            {
                Id=ci.Id,
                Image=ci.ProductVarient.ColoredProduct.Image,
                Name=ci.ProductVarient.ColoredProduct.Product.Name,
                Quantity = ci.Quantity,
                Price = ci.TotalPrice,
                Description=ci.ProductVarient.ColoredProduct.Product.Description
            }).ToList();

            return new()
            {
                Id = cart.Id,
                TotalPrice = cart.TotalPrice,
                TotalQuantity = cart.TotalQuantity,
                items= itemDtos
            };
        }
      
        

    }
}
