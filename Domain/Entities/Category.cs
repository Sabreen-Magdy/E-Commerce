namespace Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Icon { get; set; }

    public ICollection<ProductCategory> ProductCategories { get; set; } = null!;
}
