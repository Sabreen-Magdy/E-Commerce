namespace Contract
{
    public record CartItemDto
    {
        public int Id { get; set; }
        public int ProductVarientId { get; set; }
        public string? Image { get; set; }
        public string Name { get; set; } = null!;
        public string Size { get; set; } = null!;
        public string Color { get; set; } = null!;
        public double UnitPrice { get; set; }
        public double Discount { get; set; }
        public int State { get; set; }
        public int Quantity { get; set; }
    }
}
