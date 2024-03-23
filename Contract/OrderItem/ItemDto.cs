namespace Contract
{
    public record ItemDto
    {
        public string? Image { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
