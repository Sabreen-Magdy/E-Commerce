namespace Contract;

public record ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public double Price { get; set; }

    public string? Image { get; set; }
}
