using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BasketCustomer
    {
        public string Id { get; set; }
        public List<BasketItem> Items { get; set; }=new List<BasketItem>();
        public BasketCustomer(string id)
        {
            Id=id;
        }
    }
}
