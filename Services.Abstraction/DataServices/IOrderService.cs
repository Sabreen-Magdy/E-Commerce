using Contract.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction.DataServices
{
    public interface IOrderService : IBaseService<OrderDto>
    {
    }
}
