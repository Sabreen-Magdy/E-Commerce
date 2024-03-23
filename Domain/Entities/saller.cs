namespace Domain.Entities;

public class  Saller :BaseEntity
{
    public int NId { get; set; }
    public string Name { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;

    public List<Product> Products { get; set; } = null!;
}
