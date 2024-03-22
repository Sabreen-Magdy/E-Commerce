using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Favourite:BaseEntity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public ICollection<ProductVarient> ProductVarients { get; set; } = null!;
        public List<FavoriteItems> FavoriteItems{ get; set; } = null!;

    }
}
