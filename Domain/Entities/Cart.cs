﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cart:BaseEntity
    {
        public int TotalQuantity
        {
            get
            {
                return CartItems.Sum(ci => ci.Quantity);
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return CartItems.Sum(ci => ci.Price * ci.Quantity);
            }
        }

        #region RelationShip Mapping
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public ICollection<ProductVarient> ProductVarients { get; set; } = null!;
        public List<CartItem> CartItems { get; set; } = null!;
        #endregion
    }
}
