using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class ProductVarient : BaseEntity
{
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public double Discount { get; set; }

    #region RelationShip Mapping
    public virtual int ColoredProductId { get; set; }
    public virtual ColoredProduct ColoredProduct { get; set; } = null!;
    public virtual int SizeId { get; set; }
    public virtual Size Size { get; set; } = null!;
    public ICollection<Cart> Carts { get; set; } = null!;
    public List<CartItem> CartItems { get; set; } = null!;
    public ICollection<Favourite> Favourites { get; set; } = null!;

    [ForeignKey("ProductBelongToOrder")]
    public virtual int ProductBelongToOrderId { get; set; }
    public virtual ProductVarientBelongToOrder  ProductBelongToOrder { get; set; }

    #endregion
}
