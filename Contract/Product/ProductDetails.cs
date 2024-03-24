using System.Drawing;

namespace Contract;

public record ProductDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public float AvgRating {  get; set; }
    public int NumberReviews { get; set; }
    public string? Description { get; set; } 
}

public record ProductVariantDto
{
    public int Id { get; set; }

    public double Price { get; set; }
    public double Discount { get; set; }
    public double OfferPrice => Price * Discount;
    public double PriceAfter => Price - OfferPrice;

    public int Quantity { get; set; }
    public Color Code { get; set; }
    public string? coloredimage { get; set; }
    public string Size { get; set; } = null!;
}

public record ColoredProuctDto(int Id, Color ColorCode, 
    string ColorName, string? Image)
{
}
public record ProductCategoryDto(int Id, string CategorName)
{}