using Contract.OrderItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Saller
{
    public record SallertDto
    {
        public int Id { get; set; }
        public int NId { get; set; }

        public string Name { get; set; } = null!;
        public string Password { get; set; }
        public string Phono{ get; set; } = null!;
        public string Email { get; set; } = null!;
        //public List<ItemDto> items { get; set; } = null!;
    }
}