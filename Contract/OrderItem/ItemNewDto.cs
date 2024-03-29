using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.OrderItem
{
    public record ItemNewDto
    {
        public int ProductVarientId { get; set; }
        //public int CustomerId { get; set; }
        public int State { get; set; }
        public int Quantity { get; set; }
    }
}
