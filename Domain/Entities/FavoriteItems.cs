using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FavoriteItems
    {
        // Foreign key to reference the product
        public int ProductVarientId { get; set; }
        public ProductVarient ProductVarient { get; set; } = null!;

        // Quantity of the product in this Favourite
        public int Quantity { get; set; }

        // Foreign key to reference the Favourite
        public int FavouriteId { get; set; }
        public Favourite Favourite { get; set; } = null!;
    }
}
