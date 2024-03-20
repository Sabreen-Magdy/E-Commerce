namespace Contract.Product;

public record ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }

    public string Image = null!;

}
