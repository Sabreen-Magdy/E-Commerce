namespace Domain.Entities;

public record Saller 
{
    public int Id { get; set; }
    public int NId { get; set; }
    public string Name { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Phono { get; set; } = null!;
    public string Email { get; set; } = null!;

    public List<Product> Products { get; set; } = null!;
}
