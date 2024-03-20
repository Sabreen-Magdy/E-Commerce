namespace Contract.Product;

public record ProductDetails
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public List<string> Images { get; set; } = null!;
    public List<ProductVariantDto> ProductVariants { get; set; } = null!;

}
