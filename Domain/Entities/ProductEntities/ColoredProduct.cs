namespace Domain.Entities;

public class ColoredProduct : BaseEntity
{
    public string? Image { get; set; }
   
    public double TotalPrice
    {
        get
        {
            if (IsVarientsNull())
                return 0;
            return Varients!.Sum(v => v.UnitPrice);
        }
    }
    public double AvgPrice
    {
        get
        {
            if (IsVarientsNull())
                return 0;
            return Varients!.Average(v => v.UnitPrice);
        }
    }
    public int TotalQuntity
    {
        get
        {
            if (IsVarientsNull())
                return 0;
            return Varients!.Sum(v => v.Quantity);
        }
    }
    
    #region RelationShip Mapping

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int ColorId { get; set; }
    public Color Color { get; set; } = null!;

    #endregion

    private bool IsVarientsNull() => Varients != null || !Varients!.Any();

    // Reduce Join
    public ICollection<ProductVarient> Varients { get; set; } = null!;
}
