namespace Domain.Entities;

public class  Saller :BaseEntity
{
    public int NId { get; set; }
    public string Name { get; set; } = null!;
    public string Password { get; set; }
    public string Phono { get; set; } = null!;
    public string Email { get; set; } = null!;
}
