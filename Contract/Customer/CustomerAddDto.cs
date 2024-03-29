﻿namespace Contract;

public record CustomerAddDto
{
    public string Name { get; set; } = null!;
    public string? Image { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Phone { get; set; } = null!;
}