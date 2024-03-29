namespace Contract;

public record CartDto
{
    public double TotalPrice { get; set; }
    public int TotalQuantity { get; set; }
    public List<CartItemDto> items { get; set; } = null!;
}
