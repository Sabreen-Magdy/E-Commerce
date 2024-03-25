namespace Domain.Entities;

public class  Saller : User
{
    public int NId { get; set; }
    public List<Product> Products { get; set; } = null!;
}
