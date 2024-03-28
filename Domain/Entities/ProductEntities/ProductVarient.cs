namespace Domain.Entities;

public class ProductVarient : BaseEntity
{
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public double Discount { get; set; }
    public double Price => UnitPrice; //* Quantity;



    #region RelationShip Mapping

    public int ProductId { get; set; }
    public int ColorId { get; set; }

    public virtual ColoredProduct ColoredProduct { get; set; } = null!;
    public int SizeId { get; set; }
    public virtual Size Size { get; set; } = null!;

    public virtual ICollection<CartItem> CartItems { get; set; } = null!;
 
    public virtual ICollection<ProductVarientBelongToOrder> ProductBelongToOrders { get; set; } = null!;

    #endregion
}
