namespace Contract
{
    public record FavoriteDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public string? Image { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public double Price { get; set; }
    }
    public record FavoriteNewDto
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
    }
}
