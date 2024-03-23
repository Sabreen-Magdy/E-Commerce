﻿namespace Domain.Entities;

public class ProductVarient : BaseEntity
{
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public double Discount { get; set; }

    #region RelationShip Mapping

    public int ColoredProductId { get; set; }
    public virtual ColoredProduct ColoredProduct { get; set; } = null!;
    public int SizeId { get; set; }
    public Size Size { get; set; } = null!;

    #endregion
}
