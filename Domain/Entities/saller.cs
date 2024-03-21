using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public record saller 
    {
        public int Id { get; set; }
        public int NId { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; }
        public string Phono { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
