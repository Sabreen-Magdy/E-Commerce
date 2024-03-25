using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Order
{
    public record ProductBToOrderDto
    {
       //public int  OrderId { get; set; }
       // public int ProductId { get; set; }
       // public int ColorId { get; set; }
        public int Quantity { get; set; }
        public ProductVariantDto? products { get; set; }
        public double TotalCostPerQuantity { get; set; }
    }
}
