using Contract;
using Contract.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction.DataServices
{
    public interface IOrderService 
    {
        public List<OrderDto> GetAll();
        public OrderDto Get(int id);
        public List<OrderDto> Get(string Name);
        public void Add(OrderDtoNew DTO);
        public void Update(OrderDto DTO);
        public void Delete(int id);
        public void Updatestatus(int id, int status);
    }
}
