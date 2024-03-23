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
        public double TotalPrice { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int ProductsVerientId { get; set; }

        public virtual ProductVarient ProductsVerient { get; set; }
    }
}
