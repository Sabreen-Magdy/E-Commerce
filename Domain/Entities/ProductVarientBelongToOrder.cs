using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductVarientBelongToOrder : BaseEntity
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<ProductVarient> Products { get; set; }
    }
}
