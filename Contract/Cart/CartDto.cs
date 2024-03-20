﻿using Contract.OrderItem;

namespace Contract.Cart;

public record CartDto
{
    public double TotalPrice { get; set; }
    public List<ItemDto> items { get; set; } = null!;
}
