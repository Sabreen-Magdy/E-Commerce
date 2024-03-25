namespace Contract;

public record CartDto
{
    public int Id { get; set; }
    public double TotalPrice { get; set; }
    public int TotalQuantity { get; set; }
    public List<ItemDto> items { get; set; } = null!;
}
