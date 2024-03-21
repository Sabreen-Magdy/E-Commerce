using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public record Order
    {
        public DateTime Date { get; set; }
        public DateTime ConfirmDate { get; set; }
        public int State { get; set; }
        public double TotalAmount { get; set; }
        public string Address { get; set; } = null!;

        //public List<ItemDto> items { get; set; } = null!;
    }
}
