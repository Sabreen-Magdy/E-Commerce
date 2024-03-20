namespace Contract.Customer;

public record CustomerAddDto
{
    public string Name { get; set; } = null!;
    public string? Image { get; set; }
    public string Phono { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
