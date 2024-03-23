namespace Domain.Entities;

public class ColoredProduct : BaseEntity
{
    public string? Image { get; set; }
   
    #region RelationShip Mapping

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int ColorId { get; set; }
    public Color Color { get; set; } = null!;
    
    #endregion

    // Reduce Join
    public ICollection<ProductVarient>? Varients { get; set; }
}
