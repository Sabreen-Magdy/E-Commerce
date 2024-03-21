namespace Domain.Entities;

public class ColoredProduct : BaseEntity
{
    public string? Image { get; set; }
   
    #region RelationShip Mapping

    public virtual int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;
    public virtual int ColorId { get; set; }
    public virtual Color Color { get; set; } = null!;

    #endregion
}
