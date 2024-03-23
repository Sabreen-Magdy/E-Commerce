using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CartItem:BaseEntity
    {
        // Foreign key to reference the product
        public int ProductVarientId { get; set; }
        public ProductVarient ProductVarient { get; set; } =null!;
        public int Quantity { get; set; }
        public double TotalPrice { 
            get {
                return Quantity * this.ProductVarient.UnitPrice;
            } }

        // Foreign key to reference the cart
        public int CartId { get; set; }
        public Cart Cart { get; set; } = null!;
    }
}
