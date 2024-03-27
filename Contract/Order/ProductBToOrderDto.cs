using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Order
{
    public record ProductBToOrderDto
    {
        public int Quantity { get; set; }
        public int ProductVarientId { get; set; }
        public string? Image { get; set; }
        public string? ProductName { get; set; }
        public double TotalCost { get; set; }
    }
}
