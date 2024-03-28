﻿namespace Domain.Entities
{
    public class ProductVarientBelongToOrder : BaseEntity
    {
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
      
        public int OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;
        public int ProductId { get; set; }
        public int SizeId {  get; set; }
        public int ColorId { get; set; }

        public virtual ProductVarient ProductVarient { get; set; } = null!;
    }
}
