namespace Contract;

public record ProductNewDto
{
    public int SallerId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public List<int> Categories { get; set; } = null!;
    public List<KeyValuePair<int, string>> Images { get; set; } = null!;
    public List<ProductVariantNewDto> ProductVariants { get; set; } = null!;
}

public record ProductVariantNewDto
{
    public int ProductId { get; set; }
    public int ColorId { get; set; }
    public double UnitPrice { get; set; }
    public double Discount { get; set; }
    public int Quantity { get; set; }
    public int SizeId  { get; set; }
}

public record ProductColoredNewDto(int ProductId, int ColorId, string Image) { }