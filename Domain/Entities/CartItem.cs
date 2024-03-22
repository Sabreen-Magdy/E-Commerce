using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CartItem
    {
        // Foreign key to reference the product
        public int ProductVarientId { get; set; }
        public ProductVarient ProductVarient { get; set; } =null!;
        public string? ProductName { get; set; }
        public string? PictureUrl { get; set; }
        public string? ProductDescription { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        // Foreign key to reference the cart
        public int CartId { get; set; }
        public Cart Cart { get; set; } = null!;
    }
}
