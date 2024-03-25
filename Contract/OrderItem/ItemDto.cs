﻿namespace Contract
{
    public record ItemDto
    {
        public int Id { get; set; }
        public string? Image { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
