namespace Contract;

public record ProductDto
{
    public DateTime AddingDate { get; set; }
    public float AvgRating { get; set; }
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public double Price { get; set; }

    public string? Image { get; set; }
}
